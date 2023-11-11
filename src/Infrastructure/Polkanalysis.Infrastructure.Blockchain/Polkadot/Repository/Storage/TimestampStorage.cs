using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Timestamp;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Storage
{
    public class TimestampStorage : MainStorage, ITimestampStorage
    {
        public TimestampStorage(SubstrateClientExt client, IBlockchainMapping mapper, ILogger logger) : base(client, mapper, logger) { }

        public async Task<Bool> DidUpdateAsync(CancellationToken token)
        {
            var res = await _client.TimestampStorage.DidUpdateAsync(token);

            return res ?? new Bool(false);
        }

        public async Task<U64> NowAsync(CancellationToken token)
        {
            return await _client.TimestampStorage.NowAsync(token);
        }
    }
}
