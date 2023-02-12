using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Secondary.Pallet.Timestamp;
using Substats.Polkadot.NetApiExt.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Polkadot.Repository.Storage
{
    public class TimestampStorage : ITimestampStorage
    {
        private readonly SubstrateClientExt _client;
        public TimestampStorage(SubstrateClientExt client)
        {
            _client = client;
        }

        public Task<Bool> DidUpdateAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U64> NowAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
