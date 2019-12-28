using System;
using System.Collections;
using System.Collections.Generic;

namespace ArrayList
{
    public class ArrayList<T> : IList<T>
    {
        private const int DefaultCapacity = 8;

        private T[] items;

        private int count;

        public int Count
        {
            get => count;

            private set
            {
                count = value;

                if (value == items.Length)
                {
                    Capacity = items.Length * 2;
                }
            }
        }

        private int changesCount;

        public bool IsReadOnly => false;

        public ArrayList()
        {
            items = new T[DefaultCapacity];
            Count = 0;
        }

        public ArrayList(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity value is negative");
            }

            items = new T[capacity];
            Count = 0;
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException($"Index value {index} is out of range [0,{Count - 1}]");
            }
        }

        private void CheckReadOnly()
        {
            if (IsReadOnly)
            {
                throw new AccessViolationException("Modification of a read-only value attempted.");
            }
        }

        public bool Remove(T item)
        {
            CheckReadOnly();

            var index = IndexOf(item);

            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            CheckReadOnly();

            CheckIndex(index);

            Count--;

            var itemsNew = Array.CreateInstance(typeof(T), items.Length);
            Array.Copy(items, itemsNew, Count);

            if (index > 0)
            {
                Array.Copy(itemsNew, items, index);
            }

            Array.Copy(itemsNew, index + 1, items, index, Count - index);

            changesCount++;
        }

        public int IndexOf(T value)
        {
            for (var i = 0; i < Count; i++)
            {
                if (Equals(items[i], value))
                {
                    return i;
                }
            }

            return -1;
        }

        public T this[int index]
        {
            get
            {
                CheckIndex(index);
                return items[index];
            }

            set
            {
                CheckIndex(index);
                items[index] = value;
            }
        }

        public void Insert(int index, T value)
        {
            CheckReadOnly();

            if (index == Count)
            {
                Add(value);
                Count++;
                changesCount++;
                return;
            }

            CheckIndex(index);

            Array.Copy(items, index, items, index + 1, Count - index);
            
            items[index] = value;            

            Count++;
            changesCount++;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            CheckReadOnly();

            var itemsNew = new T[items.Length];
            Array.Copy(items, itemsNew, Count);

            Count += array.Length;

            if (arrayIndex > 0)
            {
                Array.Copy(itemsNew, items, arrayIndex - 1);
            }

            Array.Copy(array, 0, items, arrayIndex, array.Length);

            Array.Copy(itemsNew, arrayIndex, items, arrayIndex + array.Length, Count - arrayIndex);
        }

        public void TrimExcess()
        {
            if (Count >= Capacity)
            {
                return;
            }

            Array.Resize(ref items, Count);

            Capacity = Count;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            var initialChangesCount = changesCount;

            for (var i = 0; i < Count; i++)
            {
                if (initialChangesCount != changesCount)
                {
                    throw new InvalidOperationException("The object was changed while iterations");
                }

                yield return items[i];
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
            {
                yield return items[i];
            }
        }

        public int Capacity
        {
            get => items.Length;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Capacity value is negative");
                }

                if (value < Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"Capacity value is less then Count = {Count}");
                }

                var newItems = new T[value];
                Array.Copy(items, 0, newItems, 0, Count);

                items = newItems;
            }
        }
        
        public void Add(T value)
        {
            CheckReadOnly();

            items[Count] = value;
            Count++;
            changesCount++;
        }

        public bool Contains(T value)
        {            
            return IndexOf(value)>=0;
        }

        public void Clear()
        {
            if (Count != 0)
            {
                Array.Clear(items, 0, Count);
                Count = 0;
            }

            changesCount++;
        }
    }
}