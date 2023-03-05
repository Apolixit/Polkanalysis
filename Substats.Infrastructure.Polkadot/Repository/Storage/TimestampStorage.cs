using Ajuna.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Substats.Domain.Contracts.Secondary.Pallet.Timestamp;
using Substats.Polkadot.NetApiExt.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Polkadot.Repository.Storage
{
    public class TimestampStorage : MainStorage, ITimestampStorage
    {
        public TimestampStorage(SubstrateClientExt client, ILogger logger) : base(client, logger) { }

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
