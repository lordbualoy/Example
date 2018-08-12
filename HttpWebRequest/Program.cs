using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;

namespace HttpWebRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Uri uri;
            System.Net.WebRequest req;

            uri = new Uri("http://www.google.com");
            req = System.Net.WebRequest.Create(uri);
            System.Net.HttpWebRequest httpReq = (System.Net.HttpWebRequest)req;
            //ถ้าขึ้นด้วย http, WebRequest จะ return มาเป็น WebRequest ที่ถูก downcast มาจาก HttpWebRequest

            uri = new Uri("ftp://www.google.com");
            req = System.Net.WebRequest.Create(uri);
            System.Net.FtpWebRequest ftpReq = (System.Net.FtpWebRequest)req;
            //ถ้าขึ้นด้วย ftp, WebRequest จะ return มาเป็น WebRequest ที่ถูก downcast มาจาก FtpWebRequest


            MyWebRequest myReq;

            myReq = MyWebRequest.Create("http://www.google.com");
            MyHttpWebRequest myHttpReq = (MyHttpWebRequest)myReq;
            //คาดว่าใน code ของ .Net จะทำประมาณตัวอย่าง MyWebRequest ข้างบน

            myReq = MyWebRequest.Create("ftp://www.google.com");
            MyFtpWebRequest myFtpReq = (MyFtpWebRequest)myReq;
            //คาดว่าใน code ของ .Net จะทำประมาณตัวอย่าง MyWebRequest ข้างบน
            
            using (HttpClient httpClient = new HttpClient())
            {
                HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, "http://www.google.com");
                HttpResponseMessage httpResponse = httpClient.SendAsync(msg).Result;
                string responseString = httpResponse.Content.ReadAsStringAsync().Result;
            }

            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect("localhost", 80);
            string httpRequestMessage = Parse(@"GET http://localhost/ HTTP/1.1
Host: localhost");
            byte[] bytes = Encoding.UTF8.GetBytes(httpRequestMessage);
            NetworkStream tcpStream = tcpClient.GetStream();
            tcpStream.Write(bytes, 0, bytes.Length);
            tcpStream.Flush();

            byte[] buffer = new byte[4096];
            tcpStream.Read(buffer, 0, buffer.Length);
            string response = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

            string Parse(string input)
            {
                StringBuilder sb = new StringBuilder();
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(input)))
                using (System.IO.StreamReader sr = new System.IO.StreamReader(ms))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                        sb.AppendLine(line);
                }
                sb.AppendLine();
                return sb.ToString();
            };
        }

        class MyWebRequest
        {
            public static MyWebRequest Create(string uri)
            {
                MyWebRequest myWebRequest;
                int index=uri.IndexOf(':');
                string prefix=uri.Substring(0,index);
                switch (prefix)
                {
                    case "http":
                        MyHttpWebRequest myHttpWebRequest = new MyHttpWebRequest();
                        myWebRequest = (MyWebRequest)myHttpWebRequest;
                        return myWebRequest;
                    case "ftp":
                        MyFtpWebRequest myFtpWebRequest = new MyFtpWebRequest();
                        myWebRequest = (MyWebRequest)myFtpWebRequest;
                        return myWebRequest;
                    default:
                        myWebRequest = new MyWebRequest();
                        return myWebRequest;
                }
            }
        }

        class MyHttpWebRequest : MyWebRequest
        {
        }

        class MyFtpWebRequest : MyWebRequest
        {
        }
    }
}
