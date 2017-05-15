using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeInitializationException
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CustomClass instance = new CustomClass();
            }
            catch(Exception e)
            {
                string errText = e.Message;
                Console.WriteLine("False result of exception = " + errText);
                errText = e.InnerException.Message;
                Console.WriteLine("True result of exception = " + errText);
            }
        }

        class CustomClass
        {
            static int result;
            public int data;

            static CustomClass()
            {
                int numerator = 100;
                int denominator = int.Parse("0");
                int result = numerator / denominator;
            }

            public CustomClass()
            {
                data = result;
            }
        }
    }
}
