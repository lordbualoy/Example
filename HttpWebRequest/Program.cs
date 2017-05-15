using System;
using System.Collections.Generic;
using System.Linq;
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
