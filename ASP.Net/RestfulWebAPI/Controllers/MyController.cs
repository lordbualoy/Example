using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestfulWebAPI.Controllers
{
    public class MyController : ApiController
    {
        //เป็น Get เพราะชื่อขึ้นต้นว่า Get
        public string GetHello() => "Hello";
        //เป็น Post เพราะชื่อขึ้นต้นว่า Post
        public string PostHello() => "Hello";
        //เป็น Put เพราะชื่อขึ้นต้นว่า Put
        public string PutHello() => "Hello";
        //เป็น Delete เพราะชื่อขึ้นต้นว่า Delete
        public string DeleteHello() => "Hello";
        [HttpGet]
        public string Get1() => "Hello";
        [AcceptVerbs("GET")]
        public string Get2() => "Hello";
        [HttpGet]
        [Route("api/My/Get3/{value1}")]
        public int Get3(int value1) => value1;
        [HttpGet]
        [Route("api/My/Get4/{value1}/{value2}")]
        public int Get4(int value1, int value2) => value1 + value2;
        [HttpPost]
        public string Post1() => "Post";
        [HttpPost]
        public string Post2([FromBody] string value) => value;
        [HttpHead]
        public void Head1() { }
        [AcceptVerbs("GET", "POST")]
        public string GetPost() => "GetPost";
        [AcceptVerbs("GET", "POST", "PUT", "DELETE", "PATCH", "HEAD", "OPTIONS")]
        public string Multi() => "Multi";
        [HttpGet]
        public HttpResponseMessage WriteHTML()
        {
            HttpResponseMessage msg = new HttpResponseMessage()
            {
                Content = new StringContent(@"<!DOCTYPE html>
<html>
<head>
<title>Page Title</title>
</head>
<body>

<h1>This is a Heading</h1>
<p>This is a paragraph.</p>

</body>
</html>",
                   System.Text.Encoding.UTF8,
                   "text/html"
               )
            };
            return msg;
        }
        [HttpGet]
        [ActionName("Json")]   //To request into this action the external request need to specify the path as My/Json instead of My/TestData
        public HttpResponseMessage TestData()
        {
            string json = "[{\"athlete\":\"Michael Phelps\",\"age\":23,\"country\":\"United States\",\"year\":2008,\"date\":\"24/08/2008\",\"sport\":\"Swimming\",\"gold\":8,\"silver\":0,\"bronze\":0,\"total\":8},{\"athlete\":\"Michael Phelps\",\"age\":19,\"country\":\"United States\",\"year\":2004,\"date\":\"29/08/2004\",\"sport\":\"Swimming\",\"gold\":6,\"silver\":0,\"bronze\":2,\"total\":8}]";

            HttpResponseMessage msg = new HttpResponseMessage()
            {
                Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json")
            };
            msg.Headers.Add("Access-Control-Allow-Origin", "*");
            return msg;
        }
    }
}
