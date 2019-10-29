using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{

    public class ArrayList<T> : IList
    {
        private T[] items = new T[10];
        private int length;

        public ArrayList(int capacity)
        {
            items = new T[capacity];
        }

        public int Count
        {
            get { return length; }
        }

        private void CheckIndex(int index)
        {
            if ((index < 0) || (index >= Count))
            {
                throw new ArgumentException(nameof(index), " value is invalid.");
            }
        }

        public bool IsEmpty() => length == 0;

        public virtual int Capacity
        {
            get { return length; }
            private set => length = value;
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

        private void IncreaseCapacityByOne()
        {
            T[] old = items;
            items = new T[old.Length + 1];
            Array.Copy(old, 0, items, 0, old.Length);
        }

        private void DecreaseCapacityByOne()
        {
            T[] old = items;
            items = new T[old.Length - 1];
            Array.Copy(old, 0, items, 0, old.Length - 1);
        }

        private void IncreaseCapacity()
        {
            T[] old = items;
            items = new T[old.Length * 2];
            Array.Copy(old, 0, items, 0, old.Length);
        }

        public int Add(T value)
        {
            if (length < items.Length)
            {
                items[length] = value;
                length++;
                return length - 1;
            }

            return -1;
        }

        void InsertAt(T value, int index)
        {
            CheckIndex(index);
            IncreaseCapacityByOne();

            for (int i = Count - 1; i > index; i--)
            {
                items[i] = items[i - 1];
            }
            items[index] = value;
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
            items = new T[0];
            length = 0;
        }

        void Remove(T value)
        {
            RemoveAt(IndexOf(value));
        }

        public void RemoveAt(int index)
        {
            CheckIndex(index);
            Array.Copy(items, index + 1, items, index, length - index - 1);
            DecreaseCapacityByOne();
            length--;
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

        void TrimExcess() => Array.Resize(ref items, Count);
    }
}
