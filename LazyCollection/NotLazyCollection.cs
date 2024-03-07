using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.LazyCollection
{
    internal class NotLazyCollection<T>(List<T> collection) : ILazyCollection<T>
    {
        public int Count => collection.Count;

        public T this[int index]
        {
            get => collection[index];
            set => collection[index] = value;
        }

        public IEnumerable<T> Enumerate()
        {
            var myCollection = collection.ToList();
            return myCollection;
        }
    }
}
