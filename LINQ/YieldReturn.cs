using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    static class YieldReturn
    {
        //public static int Yield1()    //The body of cannot be an iterator block because 'int' is not an iterator interface type
        //{
        //    yield return 1;
        //}

        //public static int[] Yield2()  //The body of cannot be an iterator block because 'int[]' is not an iterator interface type
        //{
        //    yield return 1;
        //}

        public static IEnumerable<int> Yield3()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }

        public static IEnumerable<int> Yield4()
        {
            for (int i = 1; i <= 3; i++)
                yield return i;
        }

        public static IEnumerable<int> Yield5()
        {
            int i = 1;
            yield return i++;
            yield return i++;
            yield return i++;
            for (; i <= 6; i++)
                yield return i;
        }

        public static IEnumerable<int> Yield6()
        {
            for (int i = 1; ; i++)
            {
                if (i == 4)
                    yield break;
                else
                    yield return i;
            }
        }

        public static IEnumerable<Sample> Yield7NonYield()
        {
            var list = new List<Sample>();
            for (var i = 1; i <= 10; i++)
                list.Add(new Sample { Data = i * 10 });
            return list;
        }

        public static IEnumerable<Sample> Yield7()
        {
            for (int i = 1; i <= 10; i++)
                yield return new Sample { Data = i * 10 };
        }

        public static void Double(IEnumerable<Sample> samples)
        {
            foreach (var s in samples)
                s.Data *= 2;
        }

        public static IEnumerable<Sample> Yield7Wrapper(IEnumerable<Sample> samples)
        {
            //var list = new List<Sample>();
            //foreach (var s in samples)
            //    list.Add(s);
            //return list;
            
            return new List<Sample>(samples);       //same as above foreach add pattern
        }
    }
}
