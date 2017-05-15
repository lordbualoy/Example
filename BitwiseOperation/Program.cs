using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitwiseOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            int test = 1;
            test = test & ~0x111;       //0x111 = 1111 1111 1111 in binary
            test = test | 2;            //2 = 10 in binary
            test = test & ~2;           //2 = 10 in binary

            //conversion from 1 to 0
            test = 1;
            test = test ^ 1;

            //conversion from 0 to 1
            test = 0;
            test = test ^ 1;
        }
    }
}
