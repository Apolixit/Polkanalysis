using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Polkanalysis.Worker.Parameters.Context
{
    public class TokenPricePerimeter : GenericPerimeter<DateTime>
    {
        public TokenPricePerimeter(
            IConfiguration configuration,
            ILogger<PerimeterService> logger,
            Func<DateTime> firstDay) : base(configuration, "tokenPricePerimeter", logger, firstDay(),
                new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(-1))
        {
        }
    }
}
