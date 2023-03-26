using Ajuna.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Auctions;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Authorship;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.AwesomeAvatars;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Babe;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Balances;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Crowdloan;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Identity;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.NominationPools;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Paras;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.ParaSessionInfo;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Registrar;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Session;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Staking;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.SystemCore;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Timestamp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Contracts
{
    public interface IStorage
    {
        public string BlockHash { get; set; }
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
        public ITimestampStorage Timestamp { get; }
    }
}
