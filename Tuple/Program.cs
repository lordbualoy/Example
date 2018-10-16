using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            //Generic Tuple
            Tuple<int, int> result = DivideByTen(53);

            //C# 7 Named Tuple
            (int first, int second) namedTuple1 = (first: 10, second: 20);
            namedTuple1.first++;
            namedTuple1.second++;

            (int c, int d) namedTuple2 = CreateNamedTupleMethod();

            (int c, int d) namedTuple3 = CreateNamedTupleLocalFunction();

            (int a, int b) CreateNamedTupleLocalFunction()
            {
                return (a: 10, b: 20);
            };
        }

        static Tuple<int, int> DivideByTen(int input)
        {
            int quotient = input / 10;
            int remainder = input % 10;
            return new Tuple<int, int>(quotient, remainder);
        }

        static (int a, int b) CreateNamedTupleMethod() => (a: 10, b: 20);
    }
}
