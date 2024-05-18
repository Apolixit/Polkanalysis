using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Common.Logging
{
    [ExcludeFromCodeCoverage]
    public static class LoggerExtension
    {
        public static Logger BuildLogger(IConfiguration config)
        {
            var loggerConfig = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", Serilog.Events.LogEventLevel.Warning);

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
    }
}
