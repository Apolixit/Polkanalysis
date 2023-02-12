using Substats.Domain.Contracts.Secondary.Pallet.Auctions;
using Substats.Domain.Contracts.Secondary.Pallet.Authorship;
using Substats.Domain.Contracts.Secondary.Pallet.AwesomeAvatars;
using Substats.Domain.Contracts.Secondary.Pallet.Babe;
using Substats.Domain.Contracts.Secondary.Pallet.Balances;
using Substats.Domain.Contracts.Secondary.Pallet.Crowdloan;
using Substats.Domain.Contracts.Secondary.Pallet.Identity;
using Substats.Domain.Contracts.Secondary.Pallet.NominationPools;
using Substats.Domain.Contracts.Secondary.Pallet.Paras;
using Substats.Domain.Contracts.Secondary.Pallet.ParaSessionInfo;
using Substats.Domain.Contracts.Secondary.Pallet.Registrar;
using Substats.Domain.Contracts.Secondary.Pallet.Session;
using Substats.Domain.Contracts.Secondary.Pallet.Staking;
using Substats.Domain.Contracts.Secondary.Pallet.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Contracts
{
    public interface IStorage
    {
        public IAuctionsStorage Auctions { get; }
        public IAuthorshipStorage Authorship { get; }
        public IAwesomeAvatarsStorage AwesomeAvatars { get; }
        public IBabeStorage Babe { get; }
        public IBalancesStorage Balances { get; }
        public ICrowdloanStorage Crowdloan { get; }
        public IIdentityStorage Identity { get; }
        public INominationPoolsStorage NominationPools { get; }
        public IParasStorage Paras { get; }
        public IParaSessionInfoStorage ParaSessionInfo { get; }
        public IRegistrarStorage Registrar { get; }
        public ISessionStorage Session { get; }
        public IStakingStorage Staking { get; }
        public ISystemStorage System { get; }
    }
}
