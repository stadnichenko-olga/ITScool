namespace ArrayList
{
    using System.Collections.Generic;

    public interface IList<T> : IEnumerable<T>
    {        
        void Insert(int index, T item);

        void Add(T item);

        void RemoveAt(int index);

        void Remove(T item);

        T this[int index] { get; set; }

        int IndexOf(T item);

        int Count();

        ArrayList<T> SubList(int index, int length);

        void Clear();

        bool Contains(T item);

        void TrimExcess();
    }
}
