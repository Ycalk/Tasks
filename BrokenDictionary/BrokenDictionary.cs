using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Tasks.BrokenDictionary
{
    internal static class BrokenDictionary
    {

        // from https://github.com/dotnet/runtime/blob/main/src/libraries/System.Private.CoreLib/src/System/Collections/HashHelpers.cs
        private const int HashCollisionThreshold = 100;

        private const int DictionaryLength = 50000;

        private class CustomHasher : IEqualityComparer<int>
        {
            private int _currentKey;
            private int _counter;
            public bool Equals(int x, int y) => x == y;

            public int GetHashCode(int el)
            {
                _counter++;
                if (_counter % HashCollisionThreshold + 1 == 0)
                    _currentKey++;
                return _currentKey;
            }
        }
        
        public static Dictionary<int,int> GetBrokeDictionary()
        {
            var random = new Random();
            var result = new Dictionary<int, int>(new CustomHasher());
            for (var i = 0; i < DictionaryLength; i++)
                result[i] = random.Next();

            return result;
        }
    }

    
}
