using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppWithHostDotNetCore
{
    class SampleTask : IHostedService
    {
        readonly IConfiguration configuration;
        readonly ILogger<SampleTask> logger;
        readonly SampleParser sampleParser;

        public SampleTask(IConfiguration configuration, ILogger<SampleTask> logger, SampleParser sampleParser)
        {
            this.configuration = configuration;
            this.logger = logger;
            this.sampleParser = sampleParser;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Hello World!");
            int parsed = sampleParser.Parse(configuration["SampleKey"]);
            logger.LogInformation($"Parsed SampleKey is {parsed}");
            int parsed2 = sampleParser.Parse(configuration["SampleKey2"]);
            logger.LogInformation($"Parsed SampleKey2 is {parsed2}");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Goodbye World!");

            return Task.CompletedTask;
        }
    }
}
