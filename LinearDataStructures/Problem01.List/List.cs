namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;

        public List()
            : this(DEFAULT_CAPACITY) {
        }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));

            }
            items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return items[index];
            }

            set
            {
                ValidateIndex(index);
                items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            this.Grow();
            this.items[this.Count] = item;
            this.Count++;
        }

        public bool Contains(T item)
        {
            foreach (var element in this.items.Take(this.Count))
            {
                if (item.Equals(element))
                {
                    return true;
                }
            }
            return false;
        }


        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (item.Equals(items[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);

            this.Grow();

            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
            this.items[index] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            for (int i = index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }
            items[Count - 1] = default(T);
            Count--;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void Grow()
        {
            if (this.Count == this.items.Length)
            {
                T[] itemsCopy = new T[this.items.Length * 2];

                for (int i = 0; i < this.items.Length; i++)
                {
                    itemsCopy[i] = this.items[i];
                }

                this.items = itemsCopy;
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Invalid Index Given.");
            }
        }
    }
}