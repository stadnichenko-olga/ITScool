using System;
using System.Collections;
using System.Collections.Generic;

namespace Lists
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> head;

        public int Length()
        {
            int count = 0;

            if (head != null)
            {
                count++;
                while (head.Next != null)
                {
                    count++;
                    head = head.Next;
                }
            }
            else
            {
                return 0;
            }
            return count;
        }

        public T GetFirst() => head.Data;

        public void AddFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
        }

        public void AddLast(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
            {
                head = node;
            }
            else
            {               
                while (head.Next != null)
                {
                    head = head.Next;
                }
                head.Next = node;
            }
        }

        public void Add(T data)
        {
            AddLast(data);
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index > Length() + 1)
            {
                throw new ArgumentException($"Invalid value of ", nameof(index));
            }
        }

        public void AddIndex(int index, T data)
        {
            Node<T> node = head;
            Node<T> nodeAdd = new Node<T>(data);

            CheckIndex(index);

            if (IsEmpty() || index == 0)
            {
                AddFirst(data);
                return;
            }

            if (index == Length() + 1)
            {
                AddLast(data);
                return;
            }

            for (int i = 0; i < index - 1 && node != null; i++)
            {
                node = node.Next;
            }

            nodeAdd.Next = node.Next;
            node.Next = nodeAdd;
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

            return false;
        }

        public T Remove(int index)
        {
            Node<T> current = head;
            Node<T> previous = null;
            int i = 0;
            T data = current.Data;

            CheckIndex(index);

            if (index == 0)
            {
                head = current.Next;
                current = null;
                return data;
            }

            while (i < index)
            {
                previous = current;
                current=current.Next;
                i++;
            }
            
            previous.Next = current.Next;
            data = current.Data;
            current = null;
            return data;
        }

        public T RemoveFirst()
        {
            return Remove(0);
        }

        public bool IsEmpty() => Length() == 0;

        public T GetNode(int index)
        {
            Node<T> node = head;

            if (index < 0 || index > Length() - 1)
            {
                throw new ArgumentException($"Invalid value of {nameof(index)}.");
            }

            if (IsEmpty())
            {
                throw new ArgumentException($"Empty list.");
            }

            for (int i = 0; i < index && node != null; i++)
            {
                node = node.Next;
            }

            return node.Data;
        }

        public void SetNode(int index, T dataToSet)
        {
            Node<T> node = head;

            if (index < 0 || index > Length() - 1)
            {
                throw new ArgumentException($"Invalid value of {nameof(index)}.");
            }

            if (IsEmpty())
            {
                throw new ArgumentException($"Empty list.");
            }

            for (int i = 0; i < index && node != null; i++)
            {
                node = node.Next;
            }

            node.Data = dataToSet;
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

        public void Reverse()
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
        }

        public void Print()
        {
            foreach (var item in this)
            {
                Console.Write(item.ToString() + " ");
            }
            Console.WriteLine();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
