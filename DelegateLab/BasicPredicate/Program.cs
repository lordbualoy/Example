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

            List<string> list1 = new List<string>();
            list1.Add("1");
            list1.Add("2");
            list1.Add("3");
            list1.Add("4");
            List<string> list1result = list1.FindAll((string x) => x == "1" || x == "2");

            List<Composite> list2 = new List<Composite>();
            list2.Add(new Composite() { valueA = "1", valueB = "a" });
            list2.Add(new Composite() { valueA = "2", valueB = "b" });
            list2.Add(new Composite() { valueA = "3", valueB = "c" });
            list2.Add(new Composite() { valueA = "4", valueB = "d" });
            List<Composite> list2result = list2.FindAll((Composite x) => x.valueA == "1" || x.valueA == "2");
        }

        class Composite
        {
            public string valueA;
            public string valueB;
        }
    }
}
