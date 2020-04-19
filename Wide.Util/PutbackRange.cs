using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wide.Util
{
    public class PutbackRange<T>
        where T : class
    {
        private readonly List<T> putback = new List<T>();
        private readonly IEnumerator<T> currentPosition;

        public PutbackRange(IEnumerable<T> inputRange)
        {
            currentPosition = inputRange.GetEnumerator();
        }

        public void Putback(T input)
        {
            if (input == null) return;
            putback.Add(input);
        }

        public T GetNext()
        {
            if (putback.Any())
            {
                var last = putback.Last();
                putback.RemoveAt(putback.Count - 1);
                return last;
            }
            if (currentPosition.MoveNext())
            {
                return currentPosition.Current;
            }
            return null;
        }
    }
}
