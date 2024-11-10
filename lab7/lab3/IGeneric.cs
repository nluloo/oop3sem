using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    internal interface IGeneric<T>
    {
        void GetInfo();
        void Add(T obj);
        void Remove(T obj);
    }
}
