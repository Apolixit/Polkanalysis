using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Polkanalysis.Worker.Parameters.Context
{
    public class BlockPerimeter : GenericPerimeter<uint>
    {
        public BlockPerimeter(
            IConfiguration configuration,
            ILogger<PerimeterService> logger,
            Func<uint> lastBlockId)
            : base(configuration, "blockPerimeter", logger, 1, lastBlockId())
        {
        }
    }
}
