using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Net.Sockets.TcpClient client =
                //new System.Net.Sockets.TcpClient("192.168.200.211", 65535);
                new System.Net.Sockets.TcpClient();
            client.Connect("192.168.200.211", 65535);
            string send = "hello";
            byte[] bytes = Encoding.UTF8.GetBytes(send);
            client.Client.Send(bytes);
            //using (System.Net.Sockets.NetworkStream stream = client.GetStream())
            //{
            //    stream.Write(bytes,0,bytes.Length);
            //}
        }
    }
}
