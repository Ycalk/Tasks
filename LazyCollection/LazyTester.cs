using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tasks.LazyCollection
{
    [TestFixture]
    internal class LazyTester
    {
        [Test]
        public void TestLazyCollection()
        {
            for (var i = 0; i < 100; i++)
            {
                var collection = new List<int> { 1, 2, 3, 4, 5 };
                var collections = new ILazyCollection<int>[]
                {
                    new NotLazyCollection<int>(collection),
                    new LazyCollection<int>(collection)
                };
                var randomIndex = new Random().Next(2);
                Assert.That(DoubleListingTest(collections[randomIndex]), Is.True);
                Assert.That(
                    LazyTest(collections[randomIndex]),
                    Is.EqualTo(randomIndex == 1));
            }
        }

        private bool DoubleListingTest(ILazyCollection<int> collection)
        {
            var enumerator = collection.Enumerate().GetEnumerator();
            var counter = 0;
            while (enumerator.MoveNext())
                counter++;
            return counter == collection.Count;
        }

        private bool LazyTest<T>(ILazyCollection<T?> collection)
        {
            using var enumerator = collection.Enumerate().GetEnumerator();
            collection[0] = default;
            enumerator.MoveNext();
            return enumerator.Current is not null && enumerator.Current.Equals(collection[0]);
        }
    }
}
