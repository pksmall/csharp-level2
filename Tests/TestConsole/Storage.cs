using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace TestConsole
{
    abstract class Storage<TItem> : IEnumerable<TItem>
    {
        public event Action<TItem> NewItemAdded;

        protected readonly List<TItem> _items = new List<TItem>();
        protected Action<TItem> _addObservers;
        protected Action<TItem> _removeObservers;

        public void Add(TItem item)
        {
            if (_items.Contains(item)) return;
            _items.Add(item);
            _addObservers?.Invoke(item);

            NewItemAdded?.Invoke(item);
        }

        public bool Remove(TItem item)
        {
            var result =  _items.Remove(item);
            if (result)
                _removeObservers?.Invoke(item);
            return result;
        }

        public bool IsContains(TItem item)
        {
            return _items.Contains(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public abstract void SaveToFile(string fileName);

        public virtual void LoadFromFile(string fileName)
        {
            Clear();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<TItem> GetEnumerator()
        {
            for(var i = 0; i < _items.Count; i++)
            {
                yield return _items[i];
            }
        }

        public void SubscribeToAdd(Action<TItem> Obserber)
        {
            _addObservers += Obserber;
        }
        public void SubscribeToRemove(Action<TItem> Obserber)
        {
            _removeObservers += Obserber;
        }
    }

    class Dekanat : Storage<Student>
    {
        public event Action<Student> ExelentStudentAdded;
        public Dekanat()
        {
            NewItemAdded += OnNewItemAdded;
        }
        private void OnNewItemAdded(Student student)
        {
            if (student.AvgRating > 7)
            {
                ExelentStudentAdded?.Invoke(student);
            }
        }

        public override void LoadFromFile(string fileName)
        {
            if (!File.Exists(fileName)) throw new FileNotFoundException("File not exists!", fileName);

            base.LoadFromFile(fileName);

            using(var file_reader = File.OpenText(fileName))
            {
                while(!file_reader.EndOfStream)
                {
                    var str = file_reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(str)) continue;
                    var data_elements = str.Split(',');
                    if (data_elements.Length == 0) continue;

                    var student = new Student
                    {
                        Name = data_elements[0],
                    };

                    if (data_elements.Length > 1)
                    {
                        var ratings = new List<int>();
                        for (var i = 1; i < data_elements.Length; i++)
                        {
                            ratings.Add(int.Parse(data_elements[i]));
                        }
                        student.Ratings = ratings;
                    }
                    Add(student);
                }
            }
        }

        public override void SaveToFile(string fileName)
        {
            using (var file_writer = File.CreateText(fileName))
            {
                foreach (var student in _items)
                {
                    file_writer.Write(student.Name);
                    if(student.Ratings.Count > 0)
                    {
                        var rating_string = string.Join(",", student.Ratings);
                        file_writer.Write($",{rating_string}");
                    }

                    file_writer.WriteLine();
                }
            }
        }
    }
}
