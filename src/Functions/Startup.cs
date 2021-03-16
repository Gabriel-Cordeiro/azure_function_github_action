using Functions;

using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Serilog;
using Serilog.Core;

using System;
using System.Collections.Generic;
using System.Text;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var services = builder.Services;
            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            builder.Services.AddLogging(lb => lb.AddSerilog(ConfiguracaoLog(configuration)));
        }

        private Logger ConfiguracaoLog(IConfiguration configuration) => new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .Enrich.WithProperty("ApplicationName", typeof(Startup).Assembly.GetName().Name)
            .WriteTo.File(
              $@"D:\home\LogFiles\Application\fnc-intreclame.txt",
              fileSizeLimitBytes: 1_000_000,
              rollOnFileSizeLimit: true,
              shared: true,
              flushToDiskInterval: TimeSpan.FromSeconds(1))
            .CreateLogger();
    }
}
