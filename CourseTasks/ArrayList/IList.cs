namespace ArrayList
{
    using System.Collections.Generic;

    public interface IList<T> : IEnumerable<T>
    {        
        void Insert(int index, T item);

        void RemoveAt(int index);

        void Remove(T item);

        T this[int index] { get; set; }

        int IndexOf(T item);

        void TrimExcess();
    }
}
