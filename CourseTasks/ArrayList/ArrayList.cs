using System;
using System.Collections;
using System.Collections.Generic;

namespace ArrayList
{
    public class ArrayList<T> : IList<T>
    {
        private const int DefaultCapacity = 8;

        private T[] items;

        private int Length { get; set; }

        private int changesCount;

        private bool isReadOnly { get; set; }

        public ArrayList()
        {
            items = new T[DefaultCapacity];
            Length = 0;
        }

        public ArrayList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("Capacity value is negative");
            }

            items = new T[capacity];
            Length = 0;
        }


        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Capacity)
            {
                throw new IndexOutOfRangeException($"Index value {index} is out of range [0,{Length - 1}]");
            }
        }

        public bool Remove(T item)
        {
            if (IsReadOnly)
            {
                throw new AccessViolationException("Modification of a read-only value attempted.");
            }

            int index = IndexOf(item);

            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (IsReadOnly)
            {
                throw new AccessViolationException("Modification of a read-only value attempted.");
            }

            CheckIndex(index);

            Array itemsNew = Array.CreateInstance(typeof(T), items.Length);
            Array.Copy(items, itemsNew, items.Length);
            int itemsLeft = items.Length - index;

            Array.Copy(itemsNew, index + 1, items, index, itemsLeft);

            Length--;
            changesCount++;
        }

        public int IndexOf(T value)
        {
            int i = 0;

            foreach (var item in items)
            {
                if (item.Equals(value))
                {
                    return i;
                }
                i++;
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
                changesCount++;
            }
        }

        public void Insert(int index, T value)
        {
            if (IsReadOnly)
            {
                throw new AccessViolationException("Modification of a read-only value attempted.");
            }

            CheckIndex(index);

            if (Length == Capacity) EnsureCapacity(Length + 1);

            Array itemsNew = Array.CreateInstance(typeof(T), items.Length);
            Array.Copy(items, itemsNew, Count());
            int itemsLeft = Count() - index;

            if (itemsLeft > 0)
            {
                Array.Copy(itemsNew, index, items, index + 1, itemsLeft);
            }

            items[index] = value;
            Length++;
            changesCount++;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (IsReadOnly)
            {
                throw new AccessViolationException("Modification of a read-only value attempted.");
            }

            int arrayLength = array.Length;

            for (int i = 0; i < arrayLength; i++)
            {
                Insert(arrayIndex + i, array[i]);
            }
        }

        public void TrimExcess() => Array.Resize(ref items, Capacity);

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            int initialChangesCount = changesCount;

            for (int i = 0; i < Length; i++)
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
            for (int i = 0; i < Length; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public virtual int Capacity
        {
            get { return items.Length; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Capacity value is negative");
                }

                if (value < items.Length)
                {
                    throw new ArgumentOutOfRangeException($"Capacity value is less then initial capacity = {Length}");
                }

                if (value != items.Length)
                {
                    if (value > 0)
                    {
                        var newItems = new T[value];
                        if (Length > 0)
                        {
                            Array.Copy(items, 0, newItems, 0, Length);
                        }
                        items = newItems;
                    }
                    else
                    {
                        items = new T[DefaultCapacity];
                    }
                }
            }
        }

        public bool IsReadOnly => isReadOnly;

        int ICollection<T>.Count => Length;

        public int Count() => Length;

        public ArrayList<T> SubList(int index, int length)
        {
            CheckIndex(index);
            CheckIndex(index + length);

            var result = new ArrayList<T>(Capacity);

            for (int i = index; i < index + length; i++)
            {
                result.Add(items[i]);
            }

            return result;
        }

        private void IncreaseCapacity()
        {
            T[] old = items;
            items = new T[old.Length * 2];
            Array.Copy(old, 0, items, 0, old.Length);
            changesCount++;
        }

        private void EnsureCapacity(int min)
        {
            if (items.Length < min)
            {
                int newCapacity = (items.Length == 0) ? DefaultCapacity : (items.Length * 2);

                if (newCapacity < min)
                {
                    newCapacity = min;
                }

                Capacity = newCapacity;
                changesCount++;
            }
        }

        public void Add(T value)
        {
            if (Length == Capacity) EnsureCapacity(Length + 1);

            if (Length < Capacity)
            {
                items[Length] = value;
                Length++;
                changesCount++;
            }
        }

        public bool Contains(T value)
        {
            foreach (var item in items)
            {
                if (item.Equals(value))
                {
                    return true;
                }
            }

            return false;
        }

        public void Clear()
        {
            if (Length != 0)
            {
                Array.Clear(items, 0, Length);
                Length = 0;
            }

            changesCount++;
        }

    }
}