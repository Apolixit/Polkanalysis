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
        public static Microsoft.Extensions.Logging.ILogger InitLoggerAndConfig(string loggerName, IConfiguration config)
        {
            var serilogLogger = LoggerExtension.BuildLogger(config);
            Microsoft.Extensions.Logging.ILogger microsoftLogger = LoggerExtension.CreateLogger(serilogLogger, loggerName);
            return microsoftLogger;
        }
    }
}
