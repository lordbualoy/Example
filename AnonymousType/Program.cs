using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousType
{
    class Program
    {
        static void Main(string[] args)
        {
            var anon1 = new { a = 10, b = 20, };
            var anon2 = new { a = 1, b = 2, };
            anon1 = anon2;  //can be assigned as both anon1 and anon2 has exactly the same signature

            var anon3 = new { a = 10, b = 20, c = 30 };
            //anon1 = anon3;  //cannot be assigned as anon1 and anon3 has different signature

            int get = anon1.a;
            get = anon1.b;
        }
    }
}
