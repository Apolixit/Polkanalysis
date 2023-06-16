using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.DatabaseWorker.Parameters
{
    public class BlockPerimeter
    {
        public BlockPerimeter(IConfiguration configuration, ILogger<BlockPerimeter> logger)
        {
            if (configuration == null)
                throw new ConfigurationErrorsException($"{nameof(configuration)} is not set");

            var substrateSection = configuration.GetSection("blockPerimeter").GetChildren().ToList();
            if(substrateSection != null && substrateSection.Any())
            {
                var fromBlockSection = substrateSection.FirstOrDefault(e => e.Key == "fromBlock");
                var toBlockBlockSection = substrateSection.FirstOrDefault(e => e.Key == "toBlock");

                // For a valid configuration, both values have to be set (otherwise, just ignore it)
                if(fromBlockSection?.Value != null && toBlockBlockSection?.Value != null)
                {
                    if(fromBlockSection.Value.ToLower() == "genesis")
                    {
                        FromBlock = 1;
                    } else
                    {
                        uint parsedFromBlock;
                        if(uint.TryParse(fromBlockSection.Value, out parsedFromBlock))
                        {
                            FromBlock = parsedFromBlock;
                        } else
                        {
                            logger.LogWarning($"From block (={fromBlockSection.Value}) is not a valid input. Param is ignored");
                        }
                    }

                    uint parsedToBlock;
                    if (uint.TryParse(toBlockBlockSection.Value, out parsedToBlock))
                    {
                        ToBlock = parsedToBlock;
                    }

                    if(FromBlock != null && ToBlock != null && FromBlock.Value > ToBlock.Value) {
                        logger.LogWarning($"From block (={FromBlock.Value}) is greater than To block (={ToBlock.Value}). Param are ignored");

                        FromBlock = null;
                        ToBlock = null;
                    }
                }
            }
        }

        public uint? FromBlock { get; set; }
        public uint? ToBlock { get; set; }

        public bool IsSet() => FromBlock != null;
    }
}
