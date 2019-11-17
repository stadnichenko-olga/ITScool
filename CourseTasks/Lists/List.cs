using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lists
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> head;

        private int changesCount = 0;

        private int Length { get; set; }

        public int Count() => Length;

        public T GetFirst()
        {
            if (Length == 0)
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
            Length++;
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
                this[Length - 1].Next = newNode;
            }

            changesCount++;
            Length++;
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException($"Index value {index} is out of range [0,{Length - 1}]");
            }
        }

        private Node<T> this[int index]
        {
            get
            {
                CheckIndex(index);

                Node<T> node = head;

                for (int i = 0; i < index; i++)
                {
                    node = node.Next;
                }

                return node;
            }
        }

        public void AddByIndex(int index, T data)
        {
            if (index == Length)
            {
                Add(data);
                return;
            }

            CheckIndex(index);

            var newNode = new Node<T>(data);

            Node<T> node = this[index - 1];
            newNode.Next = node.Next;
            node.Next = newNode;

            changesCount++;
            Length++;
        }

        public bool Remove(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                    }
                    else
                    {
                        head = head.Next;
                    }

                    Length--;
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

            var data = this[index].Data;
            this[index - 1].Next = this[index].Next;

            Length--;
            changesCount++;

            return data;
        }

        public T RemoveFirst()
        {
            if (Length == 0)
            {
                throw new InvalidOperationException("Empty list");
            }

            var data = head.Data;
            head = head.Next;
            Length--;
            changesCount++;

            return data;
        }

        public bool IsEmpty() => Length == 0;

        public T GetValue(int index)
        {
            CheckIndex(index);

            return this[index].Data;
        }

        public void SetValue(int index, T data)
        {
            CheckIndex(index);

            Node<T> node = this[index];
            node.Data = data;
            changesCount++;
        }

        public LinkedList<T> Copy()
        {
            if (head == null)
            {
                return new LinkedList<T>();
            }

            LinkedList<T> result = new LinkedList<T>();
            Node<T> current = head;
            Node<T> previous = null;
            int i = 0;

            while (current != null)
            {
                Node<T> node = new Node<T>(current.Data);
                result.Add(current.Data);

                if (i == 0)
                {
                    result.head = node;
                    previous = node;
                }
                else
                {
                    previous.Next = node;
                    previous = node;
                }

                current = current.Next;
                i++;
            }

            previous.Next = null;

            return result;
        }

        public void Revert()
        {
            if (head == null)
            {
                changesCount++;
                return;
            }

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

            changesCount++;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var item in this)
            {
                result.Append(string.Join(" ", item));
            }

            return result.ToString();
        }

        public override int GetHashCode()
        {
            int result = 17;
            int initialChangesCount = changesCount;

            foreach (var item in this)
            {
                if (initialChangesCount != changesCount)
                {
                    throw new InvalidOperationException("The object was changed while iterations");
                }

                result = result * 31 + (item == null ? 0 : item.GetHashCode());
            }
            return result;
        }

        public override bool Equals(Object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            LinkedList<T> linkedList = (LinkedList<T>)obj;

            if (Length != linkedList.Length)
            {
                return false;
            }

            Node<T> node1 = head;
            Node<T> node2 = linkedList.head;

            while (node1 != null)
            {
                if (!node1.Data.Equals(node2.Data))
                {
                    return false;
                }

                node1 = node1.Next;
                node2 = node2.Next;
            }

            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
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

            int initialChangesCount = changesCount;

            while (node != null)
            {
                if (initialChangesCount != changesCount)
                {
                    throw new InvalidOperationException("The object was changed while iterations");
                }

                yield return node.Data;
                node = node.Next;
            }
        }
    }
}
