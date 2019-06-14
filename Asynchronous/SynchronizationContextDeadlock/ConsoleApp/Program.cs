using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        readonly Log log;
        readonly RemoteHelper remoteHelper;

        Program()
        {
            log = new Log();
            remoteHelper = new RemoteHelper(log);
        }

        static void Main(string[] args)
        {
            new Program().Work();
            Console.Read();
        }

        /// <summary>
        /// ConsoleApp is safe from deadlock
        /// </summary>
        void Work()
        {
            log.Write("Program.Work");
            var resp = remoteHelper.GetResponse();
            var resp2 = remoteHelper.GetResponseDeadlock();
            log.Write("Program.Work");
        }
    }

    class Log : BaseLog
    {
        protected override void WriteImplementation(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
