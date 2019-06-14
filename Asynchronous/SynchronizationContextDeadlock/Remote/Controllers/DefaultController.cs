using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace Remote.Controllers
{
    public class DefaultController : ApiController
    {
        public string Get()
        {
            Thread.Sleep(3000);
            return "Done";
        }
    }
}
