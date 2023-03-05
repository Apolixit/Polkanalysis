using Ajuna.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Secondary.Pallet.Crowdloan;
using Substats.Polkadot.NetApiExt.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Polkadot.Repository.Storage
{
    public class CrowdloanStorage : MainStorage, ICrowdloanStorage
    {
        public CrowdloanStorage(SubstrateClientExt client, ILogger logger) : base(client, logger) { }

        public Task<U32> EndingsCountAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<FundInfo> FundsAsync(Id key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Id>> NewRaiseAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
