using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Timestamp;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain.Mapping;
using Polkanalysis.PeopleChain.NetApiExt.Generated;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.PeopleChain.Storage
{
    internal class TimestampStorage : PeopleChainAbstractStorage, ITimestampStorage
    {
        public TimestampStorage(SubstrateClientExt client, PeopleChainMapping mapper, ILogger logger) : base(client, mapper, logger)
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
