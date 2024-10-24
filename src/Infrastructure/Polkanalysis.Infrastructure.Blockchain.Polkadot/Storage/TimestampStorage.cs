using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Timestamp;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Storage
{
    public class TimestampStorage : PolkadotAbstractStorage, ITimestampStorage
    {
        public TimestampStorage(SubstrateClientExt client, PolkadotMapping mapper, ILogger logger) : base(client, mapper, logger) { }

        public async Task<Bool> DidUpdateAsync(CancellationToken token)
        {
            var res = await _client.TimestampStorage.DidUpdateAsync(token);

            return res;
        }

        public async Task<U64> NowAsync(CancellationToken token)
        {
            return await _client.TimestampStorage.NowAsync(token);
        }
    }
}
