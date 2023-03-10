using Ajuna.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Substats.Domain.Contracts.Secondary.Pallet.Timestamp;
using Substats.Polkadot.NetApiExt.Generated;
using TimestampStorageExt = Substats.Polkadot.NetApiExt.Generated.Storage.TimestampStorage;

namespace Substats.Infrastructure.Polkadot.Repository.Storage
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
