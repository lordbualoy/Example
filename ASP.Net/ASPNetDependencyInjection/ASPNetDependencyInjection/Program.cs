using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ASPNetDependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection
                .AddSingleton<IService1, Service1>()
                .AddSingleton<Service2>();
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            IService1 service1 = serviceProvider.GetRequiredService<IService1>();
            service1.Work();

            Service2 service2 = serviceProvider.GetRequiredService<Service2>();
            service2.Work();
        }
    }

    interface IService1
    {
        void Work();
    }

    class Service1 : IService1
    {
        public void Work()
        {
            Console.WriteLine(nameof(Service1));
        }
    }

    class Service2
    {
        public void Work()
        {
            Console.WriteLine(nameof(Service2));
        }
    }
}
