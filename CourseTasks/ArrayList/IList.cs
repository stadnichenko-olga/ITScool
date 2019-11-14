using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    public interface IList<T>: IEnumerable
    {        
        void Insert(int index, T item);

        void RemoveAt(int index);

        T this[int index] { get; set; }

        int IndexOf(T item);

        void TrimExcess();
    }
}
