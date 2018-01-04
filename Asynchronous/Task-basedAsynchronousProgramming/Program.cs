using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_basedAsynchronousProgramming
{
    class Program
    {
        delegate void delegateSignature();

        static void Main(string[] args)
        {
            TaskFactory taskFactory = Task.Factory;

            delegateSignature instanceOfDelegate = ActualMethod;

            Action action = () =>
            {
                // Just loop.
                int ctr = 0;
                for (ctr = 0; ctr <= 1000000; ctr++)
                { }
                Console.WriteLine("Finished {0} loop iterations",
                                  ctr);
            };

            Task t = taskFactory.StartNew(
                //ActualMethod
                //instanceOfDelegate
                //action
                () => {
                    // Just loop.
                    int ctr = 0;
                    for (ctr = 0; ctr <= 1000000; ctr++)
                    { }
                    Console.WriteLine("Finished {0} loop iterations",
                                      ctr);
                }
                );
            t.Wait();
            Console.Read();
        }

        public static void ActualMethod()
        {
            // Just loop.
            int ctr = 0;
            for (ctr = 0; ctr <= 1000000; ctr++)
            { }
            Console.WriteLine("Finished {0} loop iterations",
                              ctr);
        }
    }
}
