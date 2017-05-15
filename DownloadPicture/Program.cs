using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DownloadPicture
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Net.WebClient client = new System.Net.WebClient();
            System.Net.WebProxy webproxy = new System.Net.WebProxy();
            System.Uri uri = new System.Uri("http://192.168.200.1:800");

            webproxy.Address = uri;
            webproxy.Credentials = new System.Net.NetworkCredential("", "");
            client.Proxy = webproxy;
            
            client.DownloadFile("http://kingofwallpapers.com/picture/picture-008.jpg", @"C:\Users\senior\Desktop\picture-008.jpg");
        }
    }
}
