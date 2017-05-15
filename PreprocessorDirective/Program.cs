//#define SYMBOL1     //define symbol through code
//#undef SYMBOL1      //cancel define symbol through code

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PreprocessorDirective
{
    class Program
    {
        static void Main(string[] args)
        {
            #if (DEBUG)
                Console.WriteLine("Debug Symbol Enabled");
            #endif

            #if (TRACE)
                Console.WriteLine("Trace Symbol Enabled");
            #endif

            #if (SYMBOL1)
                Console.WriteLine("Symbol1 Enabled");
            #endif

            #if (SYMBOL2)
                Console.WriteLine("Symbol2 Enabled");
            #endif
        }
    }
}
