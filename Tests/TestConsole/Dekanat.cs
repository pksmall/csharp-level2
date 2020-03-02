using System;
using System.Collections.Generic;
using System.IO;
using TestConsole.Extensions;

namespace TestConsole
{
    class Dekanat : Storage<Student>
    {
        private readonly List<StudentsGroup> _Groups = new List<StudentsGroup>();
        public IEnumerable<StudentsGroup> Groups => _Groups;

        public event Action<Student> ExelentStudentAdded;
        public Dekanat()
        {
            NewItemAdded += OnNewItemAdded;
        }

        public void Add(StudentsGroup group)
        {
            if (_Groups.Contains(group)) return;
            _Groups.Add(group);
            group.Id = _Groups.Count;
        }

        private static readonly Random __rnd = new Random();
        private void OnNewItemAdded(Student student)
        {
            var max_index = 0;
            foreach(var s in _items)
            {
                max_index = Math.Max(max_index, s.Id);
            }
            student.Id = max_index + 1;

            var random_group = __rnd.NextValue(_Groups.ToArray());
            student.GroupId = random_group.Id;

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
                        FirstName = data_elements[0],
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
                    file_writer.Write(student.FirstName);
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
