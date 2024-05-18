using Microsoft.Extensions.Configuration;
using Polkanalysis.Common.Logging;
using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Common.Start
{
    [ExcludeFromCodeCoverage]
    public static class StartApplicationExtension
    {
        /// <summary>
        /// Build a Serilog logger and a Microsoft logger
        /// </summary>
        /// <param name="loggerName"></param>
        /// <returns></returns>
        public static (Serilog.Core.Logger serilogLogger, Microsoft.Extensions.Logging.ILogger microsoftLogger, IConfiguration config) InitLoggerAndConfig(string loggerName)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            IConfiguration config = new ConfigurationBuilder()
                        .AddJsonFile($"appsettings.{environment}.json")
                        .AddEnvironmentVariables()
                        .Build();

            var serilogLogger = LoggerExtension.BuildLogger(config);

            Microsoft.Extensions.Logging.ILogger microsoftLogger = LoggerExtension.CreateLogger(serilogLogger, loggerName);
            return (serilogLogger, microsoftLogger, config);
        }
    }
}
