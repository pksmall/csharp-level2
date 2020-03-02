using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
}
