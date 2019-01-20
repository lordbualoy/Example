using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using System.Net.Http;

namespace ASPNetDependencyInjectionHttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddHttpClient<TypedClient>(x =>
            {
                x.BaseAddress = new Uri("http://a.a");
                x.DefaultRequestHeaders.Host = "b";
            });
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            TypedClient typedClient = serviceProvider.GetRequiredService<TypedClient>();
            typedClient.Work();
        }
    }

    class TypedClient
    {
        readonly HttpClient httpClient;

        public TypedClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public void Work()
        {
            Console.WriteLine(httpClient.ToString());
        }
    }
}
