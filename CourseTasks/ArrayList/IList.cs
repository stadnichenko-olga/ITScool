
namespace ArrayList
{
    using System.Collections;

    public interface IListMy<T> : IEnumerable
    {        
        void Insert(int index, T item);

        void RemoveAt(int index);

        void Remove(T item);

        T this[int index] { get; set; }

        int IndexOf(T item);

        void TrimExcess();
    }
}
