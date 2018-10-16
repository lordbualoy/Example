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
            //Mainly useful when using with ExpandoObject
            dynamic dyn = new System.Dynamic.ExpandoObject();
            dyn.A = 10;
            dyn.B = "10";

            int a = dyn.A;
            string b = dyn.B;

            //try to assign int to string; no compiler's error
            try { b = dyn.A; }
            catch(Exception e) { }

            //try to assign string to int; no compiler's error
            try { a = dyn.B; }
            catch(Exception e) { }

            //Weakly Typed no compilation sanity check
            dynamic dyn2 = 1234;
            try
            {
                //Will error at runtime as int has no Substring method (this is string method)
                dyn2.Substring(0);
            }
            catch { }

            //Anonymous Type vs Dynamic Type
            dynamic dyn3 = new { a = 10, b = 20, };
            var anon = new { a = 20, b = 40, };

            try
            {
                int get1 = dyn3.b;  //no intellisense
                int get2 = anon.b;  //have intellisense
                anon = dyn3;        //can be assigned as dyn3 is currently hold the same type as anonymous type anon
                get1 = dyn3;        //can be assigned at compile time but will raise error at runtime as dyn3 is currently hold the non-int type
            }
            catch { }

            //anon = 10;        //cannot compile as anon is a strongly typed as an anonymous type
            dyn3 = 10;          //can compile and there won't be a runtime error either as dynamic is weakly typed
        }
    }
}
