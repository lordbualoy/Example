using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackTraceException
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //this one should've been the best way to write as it's the most robust & clean one, but in practice it doesn't
                //as this one lost the vital stack trace during the catch throw process
                SampleLogic.LogicA();
            }
            catch (Exception e)
            {
            }

            try
            {
                //this one is only just an acceptable way to write as it's not even clean way to write, but in practice it actually is the best way to write
                //as this one is capable of preserve the vital stack trace during the catch throw process
                SampleLogic.LogicB();
            }
            catch (Exception e)
            {
            }

            try
            {
                //this one should've been the worst way to write as it's so ugly way of exception handling, but in practice it actually is on par with LogicB in result
                //as this one is capable of preserve the vital stack trace during the catch throw process
                SampleLogic.LogicC();
            }
            catch (Exception e)
            {
            }

            try
            {
                //this one does not handle any exception at all, although crude but this one is capable of preserve the vital stack trace during the catch throw process
                //and might've been the best way to go for release build as catching and rethrow is helpful in debugging but are completely useless in production environment
                SampleLogic.LogicD();
            }
            catch (Exception e)
            {
            }

            try
            {
                //An example of LogicB style in practice
                Demo.work();
            }
            catch (Exception e)
            {
            }
        }
    }

    class SampleLogic
    {
        /// <summary>
        /// Robust & Clean Code with explicitly stated 'catch (Exception e)' and 'throw e'
        /// </summary>
        public static void LogicA()
        {
            try
            {
                InternalLogic();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Lazy Code with explicitly stated 'catch (Exception e)' and ambiguously stated 'throw'
        /// </summary>
        public static void LogicB()
        {
            try
            {
                InternalLogic();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// Extremely Lazy Code with ambiguously stated 'catch' and 'throw'
        /// </summary>
        public static void LogicC()
        {
            try
            {
                InternalLogic();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// No catch and throw at all
        /// </summary>
        public static void LogicD()
        {
            InternalLogic();
        }

        static void InternalLogic()
        {
            int a = 0;
            int b = 10 / a;
        }
    }
}
