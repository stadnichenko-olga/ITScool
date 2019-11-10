using System;
using System.Collections;
using System.Collections.Generic;

namespace Lists
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> head;

        private int changesCount = 0;

        private int length { get; set; }

        public int Length() => length;

        private int ChangesCount() => changesCount;

        public T GetFirst()
        {
            if (length == 0)
            {
                throw new ArgumentException("Empty list", nameof(length));
            }

            return head.Data;
        }

        public void AddFirst(T data)
        {
            var node = new Node<T>(data);

            node.Next = head;
            head = node;

            changesCount++;
            length++;
        }

        public void Add(T data)
        {
            var nodeAdd = new Node<T>(data);

            Node<T> node = head;

            if (head == null)
            {
                head = nodeAdd;
            }
            else
            {
                this[length - 1].Next = nodeAdd;
            }

            changesCount++;
            length++;
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Length())
            {
                throw new ArgumentOutOfRangeException("Invalid value of index", nameof(index));
            }
        }

        private Node<T> this[int index]
        {
            get
            {
                Node<T> node = head;

                for (int i = 0; i < index && node != null; i++)
                {
                    node = node.Next;
                }

                return node;
            }
        }

        public void AddByIndex(int index, T data)
        {
            if (index == length)
            {
                Add(data);
                return;
            }

            CheckIndex(index);

            var nodeAdd = new Node<T>(data);

            Node<T> node = this[index - 1];
            nodeAdd.Next = node.Next;
            node.Next = nodeAdd;

            changesCount++;
            length++;
        }

        public bool Remove(T data)
        {
            if (data == null)
            {
                return true;
            }

            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        current = null;
                    }
                    else
                    {
                        head = head.Next;
                    }

                    length--;
                    changesCount++;

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public T Remove(int index)
        {
            CheckIndex(index);

            T data = this[index].Data;
            Remove(data);

            return data;
        }

        public T RemoveFirst()
        {
            if (length == 0)
            {
                throw new ArgumentException("Empty list", nameof(length));
            }

            return Remove(0);
        }

        public bool IsEmpty() => Length() == 0;

        public T GetValue(int index)
        {
            CheckIndex(index);

            return this[index].Data;
        }

        public void SetValue(int index, T dataToSet)
        {
            CheckIndex(index);

            Node<T> node = this[index];
            node.Data = dataToSet;
            changesCount++;
        }

        public LinkedList<T> Copy()
        {
            if (head == null)
            {
                return null;
            }

            LinkedList<T> result = new LinkedList<T>();
            IEnumerator<T> iterator = GetEnumerator();

            while (iterator.MoveNext())
            {
                result.Add(iterator.Current);
            }

            return result;
        }

        public void Revert()
        {
            if (!IsEmpty())
            {
                Node<T> current = head;
                Node<T> previous = null;

                while (current != null)
                {
                    Node<T> temp = current.Next;
                    current.Next = previous;
                    previous = current;
                    head = current;
                    current = temp;
                }
            }

            changesCount++;
        }

        public void Print()
        {
            foreach (var item in this)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < length; i++)
            {
                yield return this[i].Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> node = head;

            int changesCountInitial = changesCount;

            while (node != null && changesCountInitial == ChangesCount())
            {
                yield return node.Data;
                node = node.Next;
            }
        }
    }
}
