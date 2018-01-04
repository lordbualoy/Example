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
            FileStreamWaitWithEndInvoke();
            FileStreamWaitWithWaitHandle();
            FileStreamWaitInfiniteLoop();
            FileStreamWaitForAsyncCallback();

            CallingSynchronousMethodsAsynchronously.WaitWithEndInvoke();
            CallingSynchronousMethodsAsynchronously.WaitWithWaitHandle();
            CallingSynchronousMethodsAsynchronously.WaitWithInfiniteLoop();
            CallingSynchronousMethodsAsynchronously.WaitForAsyncCallback();
            Console.Read();
        }

        static void FileStreamWaitWithEndInvoke()
        {
            using(System.IO.FileStream fs = new System.IO.FileStream(@"..\..\an_arbitrary_large_text_file.txt",System.IO.FileMode.Open))
            {
                const int bufferLength = 200 * 1024 * 1024;
                byte[] buffer = new byte[bufferLength];
                IAsyncResult result = fs.BeginRead(buffer, 0, bufferLength, null, null);
                int numOfBytes = fs.EndRead(result);
            }
        }

        static void FileStreamWaitWithWaitHandle()
        {
            using (System.IO.FileStream fs = new System.IO.FileStream(@"..\..\an_arbitrary_large_text_file.txt", System.IO.FileMode.Open))
            {
                const int bufferLength = 200 * 1024 * 1024;
                byte[] buffer = new byte[bufferLength];
                IAsyncResult result = fs.BeginRead(buffer, 0, bufferLength, null, null);

                // Wait for the WaitHandle to become signaled.
                result.AsyncWaitHandle.WaitOne();

                int numOfBytes = fs.EndRead(result);

                // Close the wait handle.
                result.AsyncWaitHandle.Close();
            }
        }

        static void FileStreamWaitInfiniteLoop()
        {
            using (System.IO.FileStream fs = new System.IO.FileStream(@"..\..\an_arbitrary_large_text_file.txt", System.IO.FileMode.Open))
            {
                const int bufferLength = 200 * 1024 * 1024;
                byte[] buffer = new byte[bufferLength];
                IAsyncResult result = fs.BeginRead(buffer, 0, bufferLength, null, null);

                while (result.IsCompleted == false)
                {
                    System.Threading.Thread.Sleep(250);
                    Console.Write(".");
                }

                int numOfBytes = fs.EndRead(result);
                Console.WriteLine();
            }
        }

        static void FileStreamWaitForAsyncCallback()
        {
            System.IO.FileStream fs = new System.IO.FileStream(@"..\..\an_arbitrary_large_text_file.txt", System.IO.FileMode.Open);

            const int bufferLength = 200 * 1024 * 1024;
            byte[] buffer = new byte[bufferLength];
            State st = new State(fs, buffer);
            AsyncCallback callback = new AsyncCallback(FileStreamCallbackMethod);
            IAsyncResult result = fs.BeginRead(buffer, 0, bufferLength, callback, st);
        }

        static void FileStreamCallbackMethod(IAsyncResult ar)
        {
            State st = (State)ar.AsyncState;

            int numOfBytes = st.FStream.EndRead(ar);
            byte[] buffer = st.ReadArray;
            st.FStream.Dispose();
        }

        // Maintain state information to be passed to 
        // EndWriteCallback and EndReadCallback.
        class State
        {
            // fStream is used to read and write to the file.
            System.IO.FileStream fStream;

            // readArray stores data that is read from the file.
            byte[] readArray;

            public State(System.IO.FileStream fStream, byte[] readArray)
            {
                this.fStream = fStream;
                this.readArray = readArray;
            }

            public System.IO.FileStream FStream
            { get { return fStream; } }

            public byte[] ReadArray
            { get { return readArray; } }
        }
    }

    class CallingSynchronousMethodsAsynchronously
    {
        public static void WaitWithEndInvoke()
        {
            // Create an instance of the test class.
            AsyncDemo ad = new AsyncDemo();

            // Create the delegate.
            AsyncMethodCaller caller = ad.TestMethod;

            // Initiate the asychronous call.
            IAsyncResult result = caller.BeginInvoke(3000, null, null);

            System.Threading.Thread.Sleep(0);
            Console.WriteLine("Main thread does some work.");

            // Perform additional processing here.
            // Call EndInvoke to retrieve the results.
            // The IAsyncResult argument of EndInvoke need to be the same one returned by BeginInvoke
            string returnValue = caller.EndInvoke(result);

            Console.WriteLine("The call executed on thread, with return value \"{0}\".", returnValue);
        }

        /// <summary>
        /// The wait handle is not closed automatically when you call EndInvoke. If you release all references to the wait handle, system resources are freed when garbage collection reclaims the wait handle. To free the system resources as soon as you are finished using the wait handle, dispose of it by calling the WaitHandle.Close method. Garbage collection works more efficiently when disposable objects are explicitly disposed.
        /// </summary>
        public static void WaitWithWaitHandle()
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
            // The IAsyncResult argument of EndInvoke need to be the same one returned by BeginInvoke
            string returnValue = caller.EndInvoke(result);

            // Close the wait handle.
            result.AsyncWaitHandle.Close();

            Console.WriteLine("The call executed on thread, with return value \"{0}\".", returnValue);
        }

        public static void WaitWithInfiniteLoop()
        {
            // Create an instance of the test class.
            AsyncDemo ad = new AsyncDemo();

            // Create the delegate.
            AsyncMethodCaller caller = ad.TestMethod;

            // Initiate the asychronous call.
            IAsyncResult result = caller.BeginInvoke(3000, null, null);

            System.Threading.Thread.Sleep(0);
            Console.WriteLine("Main thread does some work.");

            while (result.IsCompleted == false)
            {
                System.Threading.Thread.Sleep(250);
                Console.Write(".");
            }
            Console.WriteLine();

            // Perform additional processing here.
            // Call EndInvoke to retrieve the results.
            // The IAsyncResult argument of EndInvoke need to be the same one returned by BeginInvoke
            string returnValue = caller.EndInvoke(result);

            Console.WriteLine("The call executed on thread, with return value \"{0}\".", returnValue);
        }

        public static void WaitForAsyncCallback()
        {
            // Create an instance of the test class.
            AsyncDemo ad = new AsyncDemo();

            // Create the delegate.
            AsyncMethodCaller caller = ad.TestMethod;

            // Initiate the asychronous call.
            AsyncCallback callback = new AsyncCallback(CallbackMethod);
            IAsyncResult result = caller.BeginInvoke(3000, callback, "The call executed on thread, with return value \"{0}\".");

            Console.WriteLine("The main thread continues to execute...");

            // The callback is made on a ThreadPool thread. ThreadPool threads
            // are background threads, which do not keep the application running
            // if the main thread ends. Comment out the next line to demonstrate
            // this.
            System.Threading.Thread.Sleep(4000);

            Console.WriteLine("The main thread ends.");
        }

        // The callback method must have the same signature as the
        // AsyncCallback delegate.
        static void CallbackMethod(IAsyncResult ar)
        {
            // Retrieve the delegate.
            System.Runtime.Remoting.Messaging.AsyncResult result = (System.Runtime.Remoting.Messaging.AsyncResult)ar;
            AsyncMethodCaller caller = (AsyncMethodCaller)result.AsyncDelegate;

            // Retrieve the format string that was passed as state 
            // information.
            string formatString = (string)ar.AsyncState;

            // Call EndInvoke to retrieve the results.
            string returnValue = caller.EndInvoke(ar);

            // Use the format string to format the output message.
            Console.WriteLine(formatString, returnValue);
        }
    }
}
