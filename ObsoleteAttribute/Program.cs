using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Obsolete
{
    class Program
    {
        static void Main(string[] args)
        {
            ObsoletedClass1 test1 = new ObsoletedClass1();  //compiler warning
            ObsoletedClass2 test2 = new ObsoletedClass2();  //compiler warning with custom message
            ObsoletedClass3 test3 = new ObsoletedClass3();  //compiler warning with custom message
            ObsoletedClass4 test4 = new ObsoletedClass4();  //compile error with custom message

            Class test5 = new Class();                      //compile error with custom message
            Class test6 = new Class(10);
            test6.i = 50;                                   //compile error with custom message
            test6.j = 50;                                   //compile error with custom message
            test6.Method();                                 //compile error with custom message
        }
    }

    [Obsolete]
    class ObsoletedClass1
    {
    }

    [Obsolete("msg")]
    class ObsoletedClass2
    {
    }

    [Obsolete("msg",false)]
    class ObsoletedClass3
    {
    }

    [Obsolete("msg", true)]
    class ObsoletedClass4
    {
    }

    class Class
    {
        [Obsolete("msg", true)]
        public int i;

        [Obsolete("msg", true)]
        public int j { get; set; }

        [Obsolete("msg", true)]
        public Class()
        {
        }

        public Class(int i)
        {
        }

        [Obsolete("msg", true)]
        public void Method()
        {
        }
    }
}
