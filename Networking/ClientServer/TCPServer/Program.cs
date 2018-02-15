using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Net.IPAddress ip;
            System.Net.IPAddress.TryParse("192.168.200.211", out ip);
            //System.Net.IPAddress ip = GetIP();
            System.Net.Sockets.TcpListener listener =
                //new System.Net.Sockets.TcpListener(65535);
                new System.Net.Sockets.TcpListener(ip, 65535);
            listener.Start();

            while (true)
            {
                using (System.Net.Sockets.Socket socket = listener.AcceptSocket())
                {
                    byte[] bytes = new byte[5];
                    //byte[] bytes = GetBytesFromSocket(socket);
                    int n = socket.Receive(bytes);
                    string get = Encoding.UTF8.GetString(bytes);
                }
            }
        }

        static byte[] GetBytesFromSocket(System.Net.Sockets.Socket socket)
        {
            using (System.Net.Sockets.NetworkStream stream = new System.Net.Sockets.NetworkStream(socket))
            {
                byte[] bytes = new byte[5];
                if (stream.Read(bytes, 0, 5) != 5)
                    throw new Exception("no. of read stream bytes != stream.length");
                return bytes;
            }
        }

        static System.Net.IPAddress GetIP()
        {
            string hostName = System.Net.Dns.GetHostName();
            System.Net.IPHostEntry ipHostEntry = System.Net.Dns.GetHostEntry(hostName);
            System.Net.IPAddress[] ipAddresses = ipHostEntry.AddressList;

            foreach (System.Net.IPAddress ip in ipAddresses)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    return ip;
            }
            throw new Exception("Not Found");
        }
    }
}
