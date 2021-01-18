using System.Collections.Generic;

namespace ConsoleTest
{
    abstract class Storage<TItem>
    {
        private readonly List<TItem> _Items = new List<TItem>();

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
        }

        public virtual bool Remove(TItem item)
        {
            return _Items.Remove(item);
        }

        public virtual bool IsContains(TItem item) => _Items.Contains(item);

        public virtual void Clear() => _Items.Clear();

        public abstract void SaveToFile(string FileName);

        public virtual void LoadFromFile(string FileName)
        {
            Clear();
        }
    }
}
