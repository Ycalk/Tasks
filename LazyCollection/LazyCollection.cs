using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.LazyCollection
{
    internal class LazyCollection<T>(List<T> collection) : ILazyCollection<T>
    {
        public int Count => collection.Count;

        public T this[int index]
        {
            get => collection[index];
            set => collection[index] = value;
        }

        public IEnumerable<T> Enumerate()
        {
            foreach (var element in collection)
            {
                yield return element;
            }
        }
    }
}
