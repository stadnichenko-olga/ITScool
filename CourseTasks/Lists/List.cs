using System;
using System.Collections;
using System.Collections.Generic;

namespace Lists
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> head;

        private bool hasChanged;

        public int Length()
        {
            if (head == null)
            {
                return 0;
            }

            int count = 1;
            Node<T> node = head;

            while (node.Next != null)
            {
                node = node.Next;
                count++;
            }

            return count;
        }

        public T GetFirst() => head.Data;

        private bool HasChanged() => hasChanged;

        public void AddFirst(T data)
        {
            var node = new Node<T>
            {
                Data = data
            };

            node.Next = head;
            head = node;

            hasChanged = !hasChanged;
        }

        public void Add(T data)
        {
            var nodeAdd = new Node<T>
            {
                Data = data
            };

            Node<T> node = head;

            if (head == null)
            {
                head = nodeAdd;
            }
            else
            {
                while (node.Next != null)
                {
                    node = node.Next;
                }
                node.Next = nodeAdd;
            }

            hasChanged = !hasChanged;
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Length())
            {
                throw new ArgumentException($"Invalid value of ", nameof(index));
            }
        }

        private Node<T> this[int index]
        {
            get
            {
                Node<T> node = head;

                for (int i = 0; i < index - 1 && node != null; i++)
                {
                    node = node.Next;
                }

                return node;
            }
        }

        public void AddByIndex(int index, T data)
        {
            CheckIndex(index);

            var nodeAdd = new Node<T>
            {
                Data = data
            };

            if (index == Length() + 1)
            {
                Add(data);
                return;
            }

            Node<T> node = this[index - 1];
            nodeAdd.Next = node.Next;
            node.Next = nodeAdd;

            hasChanged = !hasChanged;
        }

        public bool Remove(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            if (current.Data.Equals(data))
            {
                head = current.Next;
                current = null;

                return true;
            }

            while (current != null)
            {
                while (!current.Data.Equals(data))
                {
                    previous = current;
                    current = current.Next;
                }

                previous.Next = current.Next;
                data = current.Data;
                current = null;

                return true;
            }

            hasChanged = !hasChanged;

            return false;
        }

        public T Remove(int index)
        {
            CheckIndex(index);

            Node<T> previous = this[index - 1];
            Node<T> current = this[index];

            previous.Next = current.Next;
            T data = current.Data;
            current = null;

            hasChanged = !hasChanged;

            return data;
        }

        public T RemoveFirst()
        {
            hasChanged = !hasChanged;

            return Remove(0);
        }

        public bool IsEmpty() => Length() == 0;

        public T GetNode(int index)
        {
            CheckIndex(index);

            Node<T> node = this[index];

            return node.Data;
        }

        public void SetNode(int index, T dataToSet)
        {
            CheckIndex(index);

            Node<T> node = this[index];

            node.Data = dataToSet;

            hasChanged = !hasChanged;
        }

        public LinkedList<T> CopyOf()
        {
            LinkedList<T> result = new LinkedList<T>();

            if (IsEmpty())
            {
                return result;
            }

            Node<T> node = head;

            while (node != null)
            {
                result.Add(node.Data);
                node = node.Next;
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

            hasChanged = !hasChanged;
        }

        public void Print()
        {
            foreach (var item in this)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> node = head;

            bool hasChangedInitial = HasChanged();

            while (node != null && hasChangedInitial == HasChanged())
            {
                yield return node.Data;
                node = node.Next;
            }
        }
    }
}
