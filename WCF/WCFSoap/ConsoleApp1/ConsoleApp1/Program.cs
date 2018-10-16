using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleApp1.ServiceReference1.Service1Client service1Client = new ServiceReference1.Service1Client();
            string get = service1Client.GetData(100);
        }
    }
}
