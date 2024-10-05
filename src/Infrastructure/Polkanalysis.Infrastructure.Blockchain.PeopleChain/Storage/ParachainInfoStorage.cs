using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ParachainInfo;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain.Mapping;
using Polkanalysis.PeopleChain.NetApiExt.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.PeopleChain.Storage
{
    public class ParachainInfoStorage : PeopleChainAbstractStorage, IParachainInfoStorage
    {
        public ParachainInfoStorage(SubstrateClientExt client, PeopleChainMapping mapper, ILogger logger) : base(client, mapper, logger) { }

        public async Task<Id> ParachainIdAsync(CancellationToken token)
        {
            return Map<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.polkadot_parachain_primitives.primitives.IdBase, Id>(
                await _client.ParachainInfoStorage.ParachainIdAsync(token));
        }
    }
}
