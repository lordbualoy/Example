using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            b _b = new b();
            int ret = _b.met();
            a _a = _b;
            ret = _a.met();
            c _c = _b;
            ret = _c.met();
        }
    }

    class b : a, c
    {
        //int a.met()
        //{
        //    return 2;
        //}
        //int c.met()
        //{
        //    return 3;
        //}
        public int met()
        {
            return 1;
        }
    }

    interface a
    {
        int met();
    }

    interface c
    {
        int met();
    }
}
