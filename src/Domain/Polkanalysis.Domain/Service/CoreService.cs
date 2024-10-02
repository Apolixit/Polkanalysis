using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Service
{
    public class CoreService : ICoreService
    {
        private readonly ISubstrateService _substrateService;
        private readonly ILogger<CoreService> _logger;

        public CoreService(ISubstrateService substrateService, ILogger<CoreService> logger)
        {
            _substrateService = substrateService;
            _logger = logger;
        }

        public async Task<DateTime> GetDateTimeFromTimestampAsync(Hash? blockHash, CancellationToken cancellationToken)
        {
            var currentTimestamp = blockHash switch
            {
                null => await _substrateService.Storage.Timestamp.NowAsync(cancellationToken),
                _ => await _substrateService.At(blockHash).Storage.Timestamp.NowAsync(cancellationToken)
            };

            var dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(currentTimestamp.Value);

            return dt;
        }

        public async Task<DateTime> GetDateTimeFromTimestampAsync(uint? blockNum, CancellationToken cancellationToken)
        {
            var blockHash = blockNum is null ? null : (await _substrateService.Rpc.Chain.GetBlockHashAsync(new BlockNumber(blockNum.Value), CancellationToken.None));

            return await GetDateTimeFromTimestampAsync(blockHash, cancellationToken);
        }
    }
}
