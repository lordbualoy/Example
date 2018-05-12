using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncDemo asyncDemo = new AsyncDemo();
            
            Console.WriteLine("Step 1");
            Task<int> asyncGetResult = asyncDemo.Async1();


            //แบบ Wait มีปัญหาเวลา Exception จะเป็น AggregateException ทำให้ไม่รู้ว่าสาเหตุจริงๆเกิดจากอะไร
            //Console.WriteLine("Step 9");
            //asyncGetResult.Wait();      //wait until Async3 then Async2 then Async1 to finish

            //Console.WriteLine("Step 14");
            //int asyncResult = asyncGetResult.Result;


            //แบบ GetAwaiter เวลา Exception จะเป็น Exception จริง
            Console.WriteLine("Step 9");
            System.Runtime.CompilerServices.TaskAwaiter<int> taskAwaiter = asyncGetResult.GetAwaiter();
            int asyncResult = taskAwaiter.GetResult();
            Console.WriteLine("Step 14");
            

            //.Net 4.0-Style Task.Run
            Task t = Task.Run(
                () => {
                    // Just loop.
                    int ctr = 0;
                    for (ctr = 0; ctr <= 1000000; ctr++)
                    { }
                    Console.WriteLine("Finished {0} loop iterations",
                                      ctr);
                }
                );
            System.Runtime.CompilerServices.TaskAwaiter taskAwaiter2 = t.GetAwaiter();
            taskAwaiter2.GetResult();
        }
    }

    class AsyncDemo
    {
        public async Task<int> Async1()
        {
            Console.WriteLine("Step 2");
            Task<int> getResult = Async2();

            //returns from Async2 while Async2's await is not finished yet
            Console.WriteLine("Step 7");

            Console.WriteLine("Step 8");
            int result = await getResult;     //return to Main until await finishes

            Console.WriteLine("Step 13");
            return result;
        }

        async Task<int> Async2()
        {
            Console.WriteLine("Step 3");
            Task<int> getResult = Async3();

            //returns from Async3 while Async3's await is not finished yet
            Console.WriteLine("Step 5");

            Console.WriteLine("Step 6");
            int result = await getResult;     //return to Async1 until await finishes

            Console.WriteLine("Step 12");
            return result;
        }

        async Task<int> Async3()
        {
            Console.WriteLine("Step 4");
            await Task.Delay(3000);     //return to Async2 until await finishes

            //steals the control from Main
            Console.WriteLine("Step 10");

            Console.WriteLine("Step 11");
            return 10;
        }
    }
}
