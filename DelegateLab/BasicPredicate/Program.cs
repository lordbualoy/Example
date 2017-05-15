using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Predicate
{
    class Program
    {
        static void Main(string[] args)
        {
            //Predicate<T> Delegate

            //แบบเทียบกับค่า static
            Predicate<int> isOne = i => i == 1;
            bool result = isOne(1);
            result = isOne(2);

            //แบบเทียบกับค่า dynamic จากข้างนอก (A คือค่าที่ set จากข้างนอก)
            int A = 100;
            Predicate<int> isEqualToA = i => i == A;
            result = isEqualToA(1);
            result = isEqualToA(100);
        }
    }
}
