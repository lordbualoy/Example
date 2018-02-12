using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNS
{
    class Program
    {
        static void Main(string[] args)
        {
            string hostName = System.Net.Dns.GetHostName();
            ResolveDNS(hostName);
            hostName = "www.google.com";
            ResolveDNS(hostName);
            Console.Read();
        }

        static void ResolveDNS(string hostName)
        {
            try
            {
                System.Net.IPHostEntry ipHostEntry = System.Net.Dns.GetHostEntry(hostName);
                System.Net.IPAddress[] ipAddresses = ipHostEntry.AddressList;
                foreach (System.Net.IPAddress ipAddress in ipAddresses)
                    Console.WriteLine("HostName={0}\tIP={1}", hostName, ipAddress);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
