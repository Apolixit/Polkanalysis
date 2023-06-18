using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Polkanalysis.Worker.Parameters.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Worker.Parameters
{
    public class PerimeterService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<PerimeterService> _logger;
        public PerimeterService(
            IConfiguration configuration, ILogger<PerimeterService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        /// <summary>
        /// Return block to scan from the configuration.
        /// For example if we are at block 1 000 000 and you want to query in the past from block 1, you can put from : 1 or from : "genesis" in the appsettings file
        /// Example to query everthing from the beggining :
        /// "blockPerimeter": {
        ///  "from": "1",
        ///  "to": "now",
        ///  "overrideIfAlreadyExists": false
        /// }
        /// </summary>
        /// <param name="lastBlockId"></param>
        /// <returns></returns>
        public BlockPerimeter GetBlockPerimeter(Func<uint> lastBlockId)
        {
            return new BlockPerimeter(_configuration, _logger, lastBlockId);
        }

        public EraPerimeter GetEraPerimeter(Func<uint> lastEraId)
        {
            return new EraPerimeter(_configuration, _logger, lastEraId);
        }

        public TokenPricePerimeter GetTokenPricePerimeter(Func<DateTime> firstDay)
        {
            return new TokenPricePerimeter(_configuration, _logger, firstDay);
        }
    }
}
