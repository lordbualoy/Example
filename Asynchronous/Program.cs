using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asynchronous
{
    public class AsyncDemo
    {
        // The method to be executed asynchronously.
        public string TestMethod(int callDuration)
        {
            Console.WriteLine("Test method begins.");
            System.Threading.Thread.Sleep(callDuration);
            return String.Format("My call time was {0}.", callDuration.ToString());
        }
    }
    // The delegate must have the same signature as the method
    // it will call asynchronously.
    public delegate string AsyncMethodCaller(int callDuration);

    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the test class.
            AsyncDemo ad = new AsyncDemo();

            // Create the delegate.
            AsyncMethodCaller caller = ad.TestMethod;
            
            // Initiate the asychronous call.
            IAsyncResult result = caller.BeginInvoke(3000, null, null);

            System.Threading.Thread.Sleep(0);
            Console.WriteLine("Main thread does some work.");

            // Wait for the WaitHandle to become signaled.
            result.AsyncWaitHandle.WaitOne();

            // Perform additional processing here.
            // Call EndInvoke to retrieve the results.
            string returnValue = caller.EndInvoke(result);

            // Close the wait handle.
            result.AsyncWaitHandle.Close();

            Console.WriteLine("The call executed on thread, with return value \"{0}\".", returnValue);
        }
    }
}
