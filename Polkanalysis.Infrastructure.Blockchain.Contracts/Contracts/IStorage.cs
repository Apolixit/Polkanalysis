using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Crowdloan;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ParaSessionInfo;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Babe;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Authorship;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.AwesomeAvatars;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Registrar;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Session;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Auctions;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Timestamp;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Paras;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts
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
