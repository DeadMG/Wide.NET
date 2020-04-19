using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wide.Util
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<V> SelectAggregate<T, U, V>(this IEnumerable<T> input, U initialState, Func<T, U, U> aggregate, Func<T, U, U, V> select)
        {
            var currentState = initialState;
            foreach (var item in input)
            {
                var nextState = aggregate(item, currentState);
                yield return select(item, currentState, nextState);
                currentState = nextState;
            }
        }
    }
}
