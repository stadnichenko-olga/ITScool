using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lists
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> head;

        private int changesCount;

        public int Count { get; private set; }

        public bool IsEmpty => Count == 0;

        public T GetFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Empty list");
            }

            return head.Data;
        }

        public void AddFirst(T data)
        {
            var node = new Node<T>(data);

            node.Next = head;
            head = node;

            changesCount++;
            Count++;
        }

        public void Add(T data)
        {
            var newNode = new Node<T>(data);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                this[Count - 1].Next = newNode;
            }

            changesCount++;
            Count++;
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException($"Index value {index} is out of range [0,{Count - 1}]");
            }
        }

        private Node<T> this[int index]
        {
            get
            {
                CheckIndex(index);

                var node = head;

                for (int i = 0; i < index; i++)
                {
                    node = node.Next;
                }

                return node;
            }
        }

        public void AddByIndex(int index, T data)
        {
            if (index == Count)
            {
                Add(data);

                return;
            }

            CheckIndex(index);

            var newNode = new Node<T>(data);

            var node = this[index - 1];
            newNode.Next = node.Next;
            node.Next = newNode;

            changesCount++;
            Count++;
        }

        public bool Remove(T data)
        {
            if (Equals(data, null))
            {
                return true;
            }

            var current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (Equals(current.Data, data))
                {
                    if (!Equals(previous, null))
                    {
                        previous.Next = current.Next;
                    }
                    else
                    {
                        head = head.Next;
                    }

                    Count--;
                    changesCount++;

                    return true;
                }
                previous = current;
                current = current.Next;
            }

            return false;
        }

        public T RemoveAt(int index)
        {
            CheckIndex(index);

            if (index == 0)
            {
                return RemoveFirst();
            }

            var current = head;
            Node<T> previous = null;
            int i = 0;

            while (i < index)
            {
                previous = current;
                current = current.Next;
                i++;
            }

            var data = current.Data;

            if (previous != null)
            {
                previous.Next = current.Next;
            }

            Count--;
            changesCount++;

            return data;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Empty list");
            }

            var data = head.Data;
            head = head.Next;
            Count--;
            changesCount++;

            return data;
        }

        public T GetValue(int index)
        {
            CheckIndex(index);

            return this[index].Data;
        }

        public void SetValue(int index, T data)
        {
            CheckIndex(index);

            var node = this[index];
            node.Data = data;

            changesCount++;
        }

        public LinkedList<T> Copy()
        {
            if (head == null)
            {
                return new LinkedList<T>();
            }

            var result = new LinkedList<T>();
            var current = head;

            while (current != null)
            {
                var node = new Node<T>(current.Data);
                node.Next = result.head;
                result.head = node;
                result.Count++;
                current = current.Next;
            }

            result.Revert();

            return result;
        }

        public void Revert()
        {
            if (head == null)
            {
                return;
            }

            var current = head;
            Node<T> previous = null;
            int i = 0;

            while (i < Count)
            {
                var temp = current.Next;
                current.Next = previous;
                previous = current;
                head = current;
                current = temp;
                i++;
            }

            changesCount++;
        }

        public override string ToString()
        {
            if (Count == 1)
            {
                return head.Data.ToString();
            }

            var result = new StringBuilder();

            foreach (var item in this)
            {
                result.Append(item);
                result.Append(" ");
            }

            return result.ToString();
        }

        public override int GetHashCode()
        {
            int result = 17;

            foreach (var item in this)
            {
                result = result * 31 + (item == null ? 0 : item.GetHashCode());
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (Equals(obj, null) || GetType() != obj.GetType())
            {
                return false;
            }

            var linkedList = (LinkedList<T>)obj;

            if (Count != linkedList.Count)
            {
                return false;
            }

            var node1 = head;
            var node2 = linkedList.head;
            int i = 0;

            while (i < Count)
            {
                if (!Equals(node1.Data, node2.Data))
                {
                    return false;
                }

                node1 = node1.Next;
                node2 = node2.Next;
                i++;
            }

            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int initialChangesCount = changesCount;
            var current = head;

            for (int i = 0; i < Count; i++)
            {
                if (initialChangesCount != changesCount)
                {
                    throw new InvalidOperationException("The object was changed while iterations");
                }

                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
