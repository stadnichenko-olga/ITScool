using System;
using System.Collections;
using System.Collections.Generic;

namespace ArrayList
{
    public class ArrayList<T> : IList<T>
    {
        private const int defaultCapacity = 10;

        private T[] items = new T[defaultCapacity];
        private int Length { get; set; }
        private int changesCount = 0;        

        public ArrayList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("Capacity value is negative");
            }

            items = new T[capacity];
            Length = 0;
        }

        public virtual int Count
        {
            get
            {
                return Length;
            }
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Capacity)
            {
                throw new IndexOutOfRangeException($"Index value {index} is out of range [0,{Length - 1}]");
            }
        }

        public bool IsEmpty() => Length == 0;

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
                        items = new T[defaultCapacity];
                    }
                }
            }
        }

        public ArrayList<T> SubList<T>(ArrayList<T> data, int index, int length)
        {
            CheckIndex(index);
            CheckIndex(index+length);

            var result = new ArrayList<T>(data.Capacity);
            Array.Copy(data.items, index, result.items, 0, length);
            return result;
        }

        T IList<T>.this[int index]
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
                int newCapacity = (items.Length == 0) ? defaultCapacity : (items.Length * 2);
                
                if (newCapacity < min)
                {
                    newCapacity = min;
                }
                
                Capacity = newCapacity;
                changesCount++;
            }
        }

        public int Add(T value)
        {
            if (Length == Capacity) EnsureCapacity(Length + 1);

            if (Length < Capacity)
            {
                items[Length] = value;
                Length++;
                changesCount++;
                return Length - 1;
            }

            return -1;
        }

        void IList<T>.Insert(int index, T value)
        {
            CheckIndex(index);

            if (Length == Capacity) EnsureCapacity(Length + 1);

            for (int i = Capacity - 1; i > index; i--)
            {
                items[i] = items[i - 1];
            }

            items[index] = value;
            Length++;
            changesCount++;
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

        void IList<T>.RemoveAt(int index)
        {
            CheckIndex(index);
            Array.Copy(items, index + 1, items, index, Length - index - 1);
            changesCount++;
            Length--;
        }

        int IList<T>.IndexOf(T value)
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

        void IList<T>.TrimExcess() => Array.Resize(ref items, Capacity);

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
    }
}
