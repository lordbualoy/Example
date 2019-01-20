using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace ASPNetCoreDependencyInjection.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        readonly SingletonService singletonService;
        readonly HttpClient httpClientBasic;
        readonly HttpClient httpClientNamed;
        readonly TypedClient httpClientTyped;

        public ValuesController(SingletonService singletonService, IHttpClientFactory httpClientFactory, TypedClient typedClient)
        {
            this.singletonService = singletonService;
            httpClientBasic = httpClientFactory.CreateClient();
            httpClientNamed = httpClientFactory.CreateClient();
            httpClientTyped = typedClient;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Console.WriteLine(singletonService.ToString());
            Console.WriteLine(httpClientBasic.ToString());
            Console.WriteLine(httpClientNamed.ToString());
            Console.WriteLine(httpClientTyped.ToString());
            return new string[] { "value1", "value2" };
        }
    }
}
