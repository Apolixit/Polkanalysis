using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Common.Logging
{
    public static class LoggerExtension
    {
        public static Logger BuildLogger(IConfiguration config)
        {
            var loggerConfig = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", Serilog.Events.LogEventLevel.Warning);

            //var otelEndpoint = config["Monitoring:Opentelemetry:uri"];
            //if(!string.IsNullOrEmpty(otelEndpoint))
            //{
            //    loggerConfig.WriteTo.OpenTelemetry(
            //        endpoint: otelEndpoint, 
            //        protocol: Serilog.Sinks.OpenTelemetry.OtlpProtocol.Grpc);
            //}

            //var loggerConfig = new LoggerConfiguration()
            //    .ReadFrom.Configuration(config)
            //    .WriteTo.Console()
            //    .WriteTo.File("logs/logWorker.txt", rollingInterval: RollingInterval.Day)
            //    .WriteTo.Seq("http://localhost:5341")
            //    .WriteTo.OpenTelemetry("http://localhost:4317");
            return loggerConfig.CreateLogger();
        }

        public static Microsoft.Extensions.Logging.ILogger CreateLogger(IConfiguration config, string loggerName)
        {
            return new SerilogLoggerFactory(BuildLogger(config)).CreateLogger(loggerName);
        }

        public static Microsoft.Extensions.Logging.ILogger CreateLogger(Logger logger, string loggerName)
        {
            return new SerilogLoggerFactory(logger).CreateLogger(loggerName);
        }

        //public static async Task<IHost> AddSerilog(this IHostBuilder builder, IConfigurationRoot config)
        //{
        //    builder.Use(buildLogger(config));
        //}


    }
}
