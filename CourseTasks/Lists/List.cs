using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void AddIndex(int index, T data)
        {
            Node<T> node = top;
            Node<T> nodeAdd = new Node<T>(data);

            if (index < 0 || index > Length() + 1)
            {
                throw new ArgumentException($"Invalid value of {nameof(index)}.");
            }

            if (this == null || index == 0)
            {
                AddFirst(data);
                return;
            }

            if (index == Length() + 1)
            {
                AddLast(data);
                return;
            }

            for (int i = 0; i < index && node != null; i++)
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
            T data=current.Data;

            if (index < 0 || index > Length()-1)
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
                    data=current.Data;
                }

                previous = current;
                current = current.Next;
            }
            return data;
        }

        public bool IsEmpty { get { return length == 0; } }
        
        public void Clear()
        {
            top = null;
            bottom = null;
            length = 0;
        }
        
        public bool Contains(T data)
        {
            Node<T> current = top;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
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
