using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    static class LINQImitation
    {
        public static IEnumerable<TSource> GetAll<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> selector)     //Func<TSource, bool> selector is supplied callback predicate
        {
            foreach (var s in source)
            {
                if (selector(s))
                    yield return s;
            }
        }
    }
}
