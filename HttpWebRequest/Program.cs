using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
                HttpResponseMessage httpResponse = httpClient.SendAsync(msg).GetAwaiter().GetResult();
                string responseString = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
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
            
            HttpClientMessageHandler1 httpClientMessageHandler1 = new HttpClientMessageHandler1();
            HttpClientMessageHandler2 httpClientMessageHandler2 = new HttpClientMessageHandler2();
            HttpClientMessageHandler3 httpClientMessageHandler3 = new HttpClientMessageHandler3();
            httpClientMessageHandler1.InnerHandler = httpClientMessageHandler2;
            httpClientMessageHandler2.InnerHandler = httpClientMessageHandler3;
            httpClientMessageHandler3.InnerHandler = new HttpClientHandler();

            using (HttpClient httpClient = new HttpClient(httpClientMessageHandler1))
            {
                HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, "http://localhost/");
                HttpResponseMessage httpResponse = httpClient.SendAsync(msg).GetAwaiter().GetResult();
                var responseHeader = httpResponse.Headers.Where(x => x.Key == "X-Custom-Header").First();
                string responseString = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
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

        class HttpClientMessageHandler1 : DelegatingHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Debug.WriteLine("Adding X-Custom-Header to Request Header");
                request.Headers.Add("X-Custom-Header", "X-Custom-Header");
                return base.SendAsync(request, cancellationToken);
            }
        }

        class HttpClientMessageHandler2 : DelegatingHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Debug.WriteLine("Adding X-Custom-Header2 to Request Header");
                request.Headers.Add("X-Custom-Header2", "X-Custom-Header2");
                return base.SendAsync(request, cancellationToken);
            }
        }

        class HttpClientMessageHandler3 : DelegatingHandler
        {
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                HttpResponseMessage responseMessage = await base.SendAsync(request, cancellationToken);
                Debug.WriteLine("Adding X-Custom-Header to Response Header");
                responseMessage.Headers.Add("X-Custom-Header", "X-Custom-Header");
                return responseMessage;
            }
        }
    }
}
