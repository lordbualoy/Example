using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ASPNetCoreDependencyInjection
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<SingletonService>();
            services.AddHttpClient();       //BasicClient
            services.AddHttpClient("aaa", x =>
            {
                x.BaseAddress = new Uri("http://a.a");
                x.DefaultRequestHeaders.Host = "b";
            });  //NamedClient
            services.AddHttpClient<TypedClient>();       //TypedClient
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }

    public class SingletonService
    {
        public void Work()
        {
            Console.WriteLine(nameof(SingletonService));
        }
    }

    public class TypedClient
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
