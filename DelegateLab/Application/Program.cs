using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArr = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Func<int, bool> isEven = (int i) => i % 2 == 0;
            int count = intArr.Count(isEven);

            Func<int, bool> isOdd = (int i) => i % 2 != 0;
            count = intArr.Count(isOdd);

            int A = 10;
            Func<int, bool> isA = (int i) => i == A;
            count = intArr.Count<int>(isA);

            List<int> listInt = new List<int>();
            listInt.AddRange(intArr);

            Predicate<int> isGreaterThan5 = i => i > 5;
            List<int> listIntResult = listInt.FindAll(isGreaterThan5);
        }
    }
}
