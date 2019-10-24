using System;
using System.Collections;
using System.Collections.Generic;

namespace Lists
{
    public class LinkedList<T> : IEnumerable<T>
    {
        Node<T> top;
        Node<T> bottom;
        int length;

        public int Length() => length;

        public T GetFirst() => top.Data;

        public void AddFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = top;
            top = node;

            if (length == 0)
            {
                bottom = top;
            }

            length++;
        }

        public void AddLast(T data)
        {
            Node<T> node = new Node<T>(data);

            if (top == null)
            {
                top = node;
            }
            else
            {
                bottom.Next = node;
            }

            bottom = node;
            length++;
        }

        public void Add(T data)
        {
            AddLast(data);
        }

        public void AddIndex(int index, T data)
        {
            Node<T> node = top;
            Node<T> nodeAdd = new Node<T>(data);

            if (index < 0 || index > Length() + 1)
            {
                throw new ArgumentException($"Invalid value of {nameof(index)}.");
            }

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
            Node<T> current = top;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                        {
                            bottom = previous;
                        }
                    }
                    else
                    {
                        top = top.Next;
                        if (top == null)
                        {
                            bottom = null;
                        }
                    }
                    length--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        public T Remove(int index)
        {
            Node<T> current = top;
            Node<T> previous = null;
            int i = 0;
            T data = current.Data;

            if (index < 0 || index > Length() - 1)
            {
                throw new ArgumentException($"Invalid value of {nameof(index)}.");
            }

            while (current != null)
            {
                if (i == index)
                {
                    if (previous != null)
                    {
                        if (current.Next == null)
                        {
                            bottom = previous;
                        }
                        previous.Next = current.Next;
                    }
                    else
                    {
                        top = top.Next;
                        if (top == null)
                        {
                            bottom = null;
                        }
                    }
                    length--;
                    data = current.Data;
                }

                i++;
                previous = current;
                current = current.Next;
            }
            return data;
        }

        public T RemoveFirst()
        {
            return Remove(0);
        }

        public bool IsEmpty() => Length() == 0;

        public T GetNode(int index)
        {
            Node<T> node = top;

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
            Node<T> node = top;

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

            Node<T> node = top;

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
                Node<T> current = top;
                Node<T> previous = null;

                while (current != null)
                {
                    Node<T> temp = current.Next;
                    current.Next = previous;
                    previous = current;
                    top = current;
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
            Node<T> current = top;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
