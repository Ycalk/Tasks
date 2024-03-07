using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Tasks.BrokenDictionary
{
    [TestFixture]
    internal class BrokenTester
    {
        [Test]
        public void TestBrokenDictionary()
        {
            
            var regular = new Dictionary<int, int>();
            var broken = BrokenDictionary.GetBrokeDictionary();
            
            
            GC.Collect();
            Thread.Sleep(2000);

            var brokenTime = TestDictionary(broken);

            GC.Collect();
            Thread.Sleep(2000);

            var regularTime = TestDictionary(regular);

            Assert.That(brokenTime, Is.GreaterThan(regularTime),
                $"Broken time: {brokenTime}\nRegular time: {regularTime}\nDelta: {brokenTime - regularTime}");
            Console.WriteLine($"Broken time: {brokenTime}\nRegular time: {regularTime}\nDelta: {brokenTime - regularTime}");

            // My output:
            // Broken time: 22127
            // Regular time: 3
            // Delta: 22124
        }

        private long TestDictionary(Dictionary<int, int> dictionary)
        {
            Stopwatch stopwatch = new Stopwatch();
            var random = new Random();
            stopwatch.Start();
            var count = dictionary.Count;
            for (var i = 0; i < 100000; i++)
                dictionary.TryAdd(i, random.Next());

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }
    }
}
