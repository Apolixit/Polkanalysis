using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Polkanalysis.Worker.Parameters.Context
{
    public class EraPerimeter : GenericPerimeter<uint>
    {
        public EraPerimeter(
            IConfiguration configuration,
            ILogger<PerimeterService> logger,
            Func<uint> lastEraId)
            : base(configuration, "eraPerimeter", logger, 1, lastEraId())
        {
        }
    }
}
