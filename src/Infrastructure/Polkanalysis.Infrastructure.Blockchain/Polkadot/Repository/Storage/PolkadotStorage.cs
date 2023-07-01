using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Secondary.Contracts;
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
using Polkanalysis.Polkadot.NetApiExt.Generated;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Storage
{
    public class PolkadotStorage : IStorage
    {
        private SubstrateClientExt _polkadotClient;
        private readonly ILogger _logger;

        public PolkadotStorage(SubstrateClientExt polkadotClient, ILogger logger)
        {
            _polkadotClient = polkadotClient;
            _logger = logger;
        }

        private IAuctionsStorage? _auctionsStorages = null;
        private IAuthorshipStorage? _authorshipStorages = null;
        private IAwesomeAvatarsStorage? _awesomeAvatarsStorage = null;
        private IBabeStorage? _babeStorages = null;
        private IBalancesStorage? _balancesStorages = null;
        private ICrowdloanStorage? _crowdloanStorage = null;
        private IIdentityStorage? _identityStorage = null;
        private INominationPoolsStorage? _nominationPoolsStorage = null;
        private IParasStorage? _parasStorage = null;
        private IParaSessionInfoStorage? _paraSessionInfoStorage = null;
        private IRegistrarStorage? _registrarStorage = null;
        private ISessionStorage? _sessionStorage = null;
        private IStakingStorage? _stakingStorage = null;
        private ISystemStorage? _systemStorage = null;
        private ITimestampStorage? _timestampStorage = null;

        public string BlockHash { get; set; }

        public IAuctionsStorage Auctions
        {
            get
            {
                if (_auctionsStorages == null)
                    _auctionsStorages = new AuctionsStorage(_polkadotClient, _logger);

                _auctionsStorages.BlockHash = BlockHash;
                return _auctionsStorages;
            }
        }

        public IAuthorshipStorage Authorship
        {
            get
            {
                if (_authorshipStorages == null)
                    _authorshipStorages = new AuthorshipStorage(_polkadotClient, _logger);

                _authorshipStorages.BlockHash = BlockHash;
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
                    _babeStorages = new BabeStorage(_polkadotClient, _logger);

                _babeStorages.BlockHash = BlockHash;
                return _babeStorages;
            }
        }

        public IBalancesStorage Balances
        {
            get
            {
                if (_balancesStorages == null)
                    _balancesStorages = new BalancesStorage(_polkadotClient, _logger);

                _balancesStorages.BlockHash = BlockHash;
                return _balancesStorages;
            }
        }

        public ICrowdloanStorage Crowdloan
        {
            get
            {
                if (_crowdloanStorage == null)
                    _crowdloanStorage = new CrowdloanStorage(_polkadotClient, _logger);

                _crowdloanStorage.BlockHash = BlockHash;
                return _crowdloanStorage;
            }
        }

        public IIdentityStorage Identity
        {
            get
            {
                if (_identityStorage == null)
                    _identityStorage = new IdentityStorage(_polkadotClient, _logger);

                _identityStorage.BlockHash = BlockHash;
                return _identityStorage;
            }
        }

        public INominationPoolsStorage NominationPools
        {
            get
            {
                if (_nominationPoolsStorage == null)
                    _nominationPoolsStorage = new NominationPoolsStorage(_polkadotClient, _logger);

                _nominationPoolsStorage.BlockHash = BlockHash;
                return _nominationPoolsStorage;
            }
        }

        public IParasStorage Paras
        {
            get
            {
                if (_parasStorage == null)
                    _parasStorage = new ParasStorage(_polkadotClient, _logger);

                _parasStorage.BlockHash = BlockHash;
                return _parasStorage;
            }
        }

        public IParaSessionInfoStorage ParaSessionInfo
        {
            get
            {
                if (_paraSessionInfoStorage == null)
                    _paraSessionInfoStorage = new ParaSessionInfoStorage(_polkadotClient, _logger);

                _paraSessionInfoStorage.BlockHash = BlockHash;
                return _paraSessionInfoStorage;
            }
        }

        public IRegistrarStorage Registrar
        {
            get
            {
                if (_registrarStorage == null)
                    _registrarStorage = new RegistrarStorage(_polkadotClient, _logger);

                _registrarStorage.BlockHash = BlockHash;
                return _registrarStorage;
            }
        }

        public ISessionStorage Session
        {
            get
            {
                if (_sessionStorage == null)
                    _sessionStorage = new SessionStorage(_polkadotClient, _logger);

                _sessionStorage.BlockHash = BlockHash;
                return _sessionStorage;
            }
        }

        public IStakingStorage Staking
        {
            get
            {
                if (_stakingStorage == null)
                    _stakingStorage = new StakingStorage(_polkadotClient, _logger);

                _stakingStorage.BlockHash = BlockHash;
                return _stakingStorage;
            }
        }

        public ISystemStorage System
        {
            get
            {
                if (_systemStorage == null)
                    _systemStorage = new SystemStorage(_polkadotClient, _logger);

                _systemStorage.BlockHash = BlockHash;
                return _systemStorage;
            }
        }

        public ITimestampStorage Timestamp
        {
            get
            {
                if (_timestampStorage == null)
                    _timestampStorage = new TimestampStorage(_polkadotClient, _logger);

                _timestampStorage.BlockHash = BlockHash;
                return _timestampStorage;
            }
        }
    }
}
