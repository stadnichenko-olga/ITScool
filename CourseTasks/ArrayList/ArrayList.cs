using System;
using System.Collections;
using System.Collections.Generic;

namespace ArrayList
{
    public class ArrayList<T> : IList<T>
    {
        private const int DefaultCapacity = 8;

        private T[] items;

        public int Count { get; private set; }

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
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity value is less than 1.");
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
                throw new NotSupportedException("Modification of a read-only value attempted.");
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

            Array.Copy(items, index + 1, items, index, Count - index - 1);

            Count--;
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

            if (Count == items.Length)
            {
                EnsureCapacity(Count + 1);
            }

            if (index == Count)
            {
                Add(value);
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
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Result array is NULL");
            }
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"Index value {arrayIndex} is out of range [0,{array.Length - 1}]");
            }
            if (array.Length < arrayIndex + Count)
            {
                throw new ArgumentException(nameof(array), $"Capacity of {array} is not enought.");
            }

            Array.Copy(items, 0, array, arrayIndex, Count);
        }

        public void TrimExcess()
        {
            if (Count >= Capacity)
            {
                return;
            }

            Capacity = Count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var initialChangesCount = changesCount;

            for (var i = 0; i < Count; i++)
            {
                if (initialChangesCount != changesCount)
                {
                    throw new InvalidOperationException("The object was changed while iterations.");
                }

                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public int Capacity
        {
            get => items.Length;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Capacity value is negative");
                }

                if (value < Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"Capacity value is less then Count = {Count}");
                }

                changesCount++;

                Array.Resize(ref items, value);
            }
        }

        private void EnsureCapacity(int size)
        {
            if (items.Length > size)
            {
                return;
            }

            var newCapacity = items.Length * 2;
            Capacity = Math.Max(size, newCapacity);
        }

        public void Add(T value)
        {
            CheckReadOnly();

            if (Count == items.Length)
            {
                EnsureCapacity(Count + 1);
            }


            items[Count] = value;

            Count++;

            changesCount++;
        }

        public bool Contains(T value)
        {
            return IndexOf(value) >= 0;
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