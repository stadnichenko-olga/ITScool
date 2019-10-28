using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    interface IList
    {
        bool IsEmpty();

        int Add();

        bool Contains();

        void Clear();

        void Insert();

        void Remove();

        void RemoveAt();

        int IndexOf();

        void TrimExcess();
    }
}
