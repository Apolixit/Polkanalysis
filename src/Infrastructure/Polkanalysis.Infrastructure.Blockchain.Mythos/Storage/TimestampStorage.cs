using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Timestamp;
using Polkanalysis.Infrastructure.Blockchain.Mythos.Mapping;
using Polkanalysis.Mythos.NetApiExt.Generated;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Mythos.Storage
{
    public class TimestampStorage : MythosAbstractStorage, ITimestampStorage
    {
        public TimestampStorage(SubstrateClientExt client, MythosMapping mapper, ILogger logger) : base(client, mapper, logger)
        {
        }

        public async Task<Bool> DidUpdateAsync(CancellationToken token)
        {
            return await _client.TimestampStorage.DidUpdateAsync(token);
        }

        public async Task<U64> NowAsync(CancellationToken token)
        {
            return await _client.TimestampStorage.NowAsync(token);
        }
    }
}
