using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicType
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic dynamic = new System.Dynamic.ExpandoObject();
            dynamic.A = 10;
            dynamic.B = "10";

            int a = dynamic.A;
            string b = dynamic.B;

            //try to assign int to string; no compiler's error
            try { b = dynamic.A; }
            catch(Exception e) { }

            //try to assign string to int; no compiler's error
            try { a = dynamic.B; }
            catch(Exception e) { }
        }
    }
}
