using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Timestamp;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using TimestampStorageExt = Polkanalysis.Polkadot.NetApiExt.Generated.Storage.TimestampStorage;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Storage
{
    public class TimestampStorage : MainStorage, ITimestampStorage
    {
        public TimestampStorage(SubstrateClientExt client, ILogger logger) : base(client, logger) { }

        public async Task<Bool> DidUpdateAsync(CancellationToken token)
        {
            return await GetStorageAsync<Bool>(TimestampStorageExt.DidUpdateParams, token);
        }

        public async Task<U64> NowAsync(CancellationToken token)
        {
            return await GetStorageAsync<U64>(TimestampStorageExt.NowParams, token);
        }
    }
}
