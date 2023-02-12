using Substats.Domain.Contracts.Secondary.Contracts;
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
using Substats.Domain.Contracts.Secondary.Pallet.Timestamp;
using Substats.Polkadot.NetApiExt.Generated;

namespace Substats.Infrastructure.Polkadot.Repository.Storage
{
    public class PolkadotStorage : IStorage
    {
        private SubstrateClientExt _polkadotClient;

        public PolkadotStorage(SubstrateClientExt polkadotClient)
        {
            _polkadotClient = polkadotClient;
        }

        private IAuctionsStorage? _auctionsStorages = null;
        private IAuthorshipStorage? _authorshipStorages = null;
        private IAwesomeAvatarsStorage? _awesomeAvatarsStorage = null;
        private IBabeStorage? _babeStorages = null;
        private IBalancesStorage? _balancesStorages = null;
        private ICrowdloanStorage? _crowdloanStorage = null;
        private IIdentityStorage? _identityStorage = null;
        private INominationPoolsStorage? _nominationPoolsStorage = null;
        private IIdentityStorage? _identityStorage = null;
        private IParasStorage? _parasStorage = null;
        private IParaSessionInfoStorage? _paraSessionInfoStorage = null;
        private IRegistrarStorage? _registrarStorage = null;
        private ISessionStorage? _sessionStorage = null;
        private IStakingStorage? _stakingStorage = null;
        private ISystemStorage? _systemStorage = null;
        private ITimestampStorage? _timestampStorage = null;

        public IAuctionsStorage Auctions {
            get
            {
                if (_auctionsStorages == null)
                    _auctionsStorages = new AuctionsStorage(_polkadotClient);

                return _auctionsStorages;
            }
        }

        public IAuthorshipStorage Authorship
        {
            get
            {
                if (_authorshipStorages == null)
                    _authorshipStorages = new AuthorshipStorage(_polkadotClient);

                return _authorshipStorages;
            }
        }

        public IAwesomeAvatarsStorage AwesomeAvatars
        {
            get
            {
                return null;
            }
        }

        public IBabeStorage Babe
        {
            get
            {
                if (_babeStorages == null)
                    _babeStorages = new BabeStorage(_polkadotClient);

                return _babeStorages;
            }
        }


        //public IBalancesStorage Balances
        //{
        //    get
        //    {
        //        if (_balancesStorages == null)
        //            _balancesStorages = new BalancesStorage(_polkadotClient);

        //        return _balancesStorages;
        //    }
        //}

        public IBalancesStorage Balances
        {
            get
            {
                if (_balancesStorages == null)
                    _balancesStorages = new BalancesStorage(_polkadotClient);

                return _balancesStorages;
            }
        }

        public ICrowdloanStorage Crowdloan
        {
            get
            {
                if (_crowdloanStorage == null)
                    _crowdloanStorage = new CrowdloanStorage(_polkadotClient);

                return _crowdloanStorage;
            }
        }

        public IIdentityStorage Identity
        {
            get
            {
                if (_identityStorage == null)
                    _identityStorage = new IdentityStorage(_polkadotClient);

                return _identityStorage;
            }
        }

        public INominationPoolsStorage NominationPools
        {
            get
            {
                if (_nominationPoolsStorage == null)
                    _nominationPoolsStorage = new NominationPoolsStorage(_polkadotClient);

                return _nominationPoolsStorage;
            }
        }

        public IParasStorage Paras
        {
            get
            {
                if (_parasStorage == null)
                    _parasStorage = new ParasStorage(_polkadotClient);

                return _parasStorage;
            }
        }

        public IParaSessionInfoStorage ParaSessionInfo
        {
            get
            {
                if (_paraSessionInfoStorage == null)
                    _paraSessionInfoStorage = new ParaSessionInfoStorage(_polkadotClient);

                return _paraSessionInfoStorage;
            }
        }

        public IRegistrarStorage Registrar
        {
            get
            {
                if (_registrarStorage == null)
                    _registrarStorage = new RegistrarStorage(_polkadotClient);

                return _registrarStorage;
            }
        }

        public ISessionStorage Session
        {
            get
            {
                if (_sessionStorage == null)
                    _sessionStorage = new SessionStorage(_polkadotClient);

                return _sessionStorage;
            }
        }

        public IStakingStorage Staking
        {
            get
            {
                if (_stakingStorage == null)
                    _stakingStorage = new StakingStorage(_polkadotClient);

                return _stakingStorage;
            }
        }

        public ISystemStorage System
        {
            get
            {
                if (_systemStorage == null)
                    _systemStorage = new SystemStorage(_polkadotClient);

                return _systemStorage;
            }
        }

        public ITimestampStorage Timestamp
        {
            get
            {
                if (_timestampStorage == null)
                    _timestampStorage = new TimestampStorage(_polkadotClient);

                return _timestampStorage;
            }
        }
    }
}
