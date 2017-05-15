using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousFunction
{
    class Program
    {
        delegate int AnonymousFunctionDelegate(int i);
        static void Main(string[] args)
        {
            AnonymousFunctionDelegate anonymous = delegate(int input)
            {
                return input * 2;
            };

            int resultInt = anonymous(100);
        }
    }
}
