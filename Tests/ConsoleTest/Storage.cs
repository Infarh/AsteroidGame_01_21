using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleTest
{
    internal delegate void StorageProcessor<TItem>(TItem Item);

    internal abstract class Storage<TItem> : IEnumerable<TItem>
    {
        //public event Action<TItem> ItemAdded; 
        public event EventHandler<TItem> ItemAdded; 

        protected readonly List<TItem> _Items = new List<TItem>();

        public virtual int Count => _Items.Count;

        public virtual TItem this[int Index]
        {
            get
            {
                return _Items[Index];
            }
            set
            {
                if(_Items.Contains(value)) return;
                _Items[Index] = value;
            }
        }

        public virtual void Add(TItem item)
        {
            if (_Items.Contains(item)) return;
            _Items.Add(item);

            ItemAdded?.Invoke(this, item);
        }

        public virtual bool Remove(TItem item)
        {
            return _Items.Remove(item);
        }

        public virtual bool IsContains(TItem item) => _Items.Contains(item);

        public virtual void Clear() => _Items.Clear();

        public abstract void SaveToFile(string FileName);

        public virtual void LoadFromFile(string FileName) => Clear();

        //public void Process(StorageProcessor<TItem> Processor)
        //{
        //    foreach (var item in _Items)
        //        Processor(item);
        //}

        public void Process(Action<TItem> Processor)
        {
            //Func<string, int> get_length = str =>
            //{
            //    return str.Length;
            //}; 
            foreach (var item in _Items)
                Processor(item);
        }

        public IEnumerator<TItem> GetEnumerator() => _Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
