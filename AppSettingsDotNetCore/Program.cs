using Microsoft.Extensions.Configuration;
using System;

namespace AppSettingsDotNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            string sampleKey = config["SampleKey"];
        }
    }
}
