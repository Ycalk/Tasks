using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.LazyCollection
{
    internal interface ILazyCollection<T>
    {
        public int Count { get; }
        public T this[int index] { get; set; }
        IEnumerable<T> Enumerate();
    }
}
