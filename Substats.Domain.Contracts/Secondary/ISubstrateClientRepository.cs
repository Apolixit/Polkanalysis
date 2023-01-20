using Ajuna.NetApi;
using Ajuna.NetApi.Model.Meta;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Modules;
using Substats.Polkadot.NetApiExt.Generated.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary
{
    public interface ISubstrateClientRepository
    {
        public SubstrateClient Core { get; }
        public BalancesStorage BalancesStorage { get; }
        public IdentityStorage IdentityStorage { get; }
        public NominationPoolsStorage NominationPoolsStorage { get; }
        public SystemStorage SystemStorage { get; }
        public StakingStorage StakingStorage { get; }
        public AuthorshipStorage AuthorshipStorage { get; }
        public AuctionsStorage AuctionsStorage { get; }
        public ParasStorage ParasStorage { get; }
        public CrowdloanStorage CrowdloanStorage { get; }
        public SessionStorage SessionStorage { get; }
    }
}
