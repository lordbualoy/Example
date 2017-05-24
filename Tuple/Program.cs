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
            Tuple<int, int> result = DivideByTen(53);
        }

        static Tuple<int, int> DivideByTen(int input)
        {
            int quotient = input / 10;
            int remainder = input % 10;
            return new Tuple<int, int>(quotient, remainder);
        }
    }
}
