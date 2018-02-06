using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamedTuple
{
    class Program
    {
        static void Main(string[] args)
        {
            (string A, string B, string C) TupleWithName(string a, string b, string c) // tuple return type
            {
                a += a;
                b += b;
                c += c;
                return (A: a, B: b, C: c); // tuple literal
            }

            var tuple = TupleWithName("aaa", "bbb", "ccc");
            string aa = tuple.A;
            string bb = tuple.B;
            string cc = tuple.C;
        }
    }
}
