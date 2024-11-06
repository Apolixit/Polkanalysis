using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Auctions;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Authorship;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Babe;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Crowdloan;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ParachainInfo;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Paras;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ParaSessionInfo;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Registrar;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Session;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Timestamp;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;
using Polkanalysis.Polkadot.NetApiExt.Generated;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Storage
{
    public class PolkadotStorage : IStorage
    {
        private SubstrateClientExt _polkadotClient;
        private readonly IServiceProvider _serviceProvider;
        private readonly PeopleChainService _peopleChainService;
        public readonly PolkadotMapping _mapper;
        private readonly ILogger _logger;

        public PolkadotStorage(SubstrateClientExt polkadotClient,
                               PolkadotMapping mapper,
                               ILogger logger,
                               PeopleChainService peopleChainService,
                               IServiceProvider serviceProvider)
        {
            _polkadotClient = polkadotClient;
            _mapper = mapper;
            _logger = logger;
            _peopleChainService = peopleChainService;
            _serviceProvider = serviceProvider;
        }

        private IAuctionsStorage? _auctionsStorages = null;
        private IAuthorshipStorage? _authorshipStorages = null;
        private IBabeStorage? _babeStorages = null;
        private IBalancesStorage? _balancesStorage = null;
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

        public string? BlockHash { get; set; }

        public IAuctionsStorage Auctions
        {
            get
            {
                if (_auctionsStorages == null)
                    _auctionsStorages = new AuctionsStorage(_polkadotClient, _mapper, _logger);

                _auctionsStorages.BlockHash = BlockHash;
                return _auctionsStorages;
            }
        }

        public IAuthorshipStorage Authorship
        {
            get
            {
                if (_authorshipStorages == null)
                    _authorshipStorages = new AuthorshipStorage(_polkadotClient, _mapper, _logger);

                _authorshipStorages.BlockHash = BlockHash;
                return _authorshipStorages;
            }
        }

        public IBabeStorage Babe
        {
            get
            {
                if (_babeStorages == null)
                    _babeStorages = new BabeStorage(_polkadotClient, _mapper, _logger);

                _babeStorages.BlockHash = BlockHash;
                return _babeStorages;
            }
        }

        public IBalancesStorage Balances
        {
            get
            {
                if (_balancesStorage == null)
                    _balancesStorage = new BalancesStorage(_polkadotClient, _mapper, _logger);

                _balancesStorage.BlockHash = BlockHash;
                return _balancesStorage;
            }
        }

        public ICrowdloanStorage Crowdloan
        {
            get
            {
                if (_crowdloanStorage == null)
                    _crowdloanStorage = new CrowdloanStorage(_polkadotClient, _mapper, _logger);

                _crowdloanStorage.BlockHash = BlockHash;
                return _crowdloanStorage;
            }
        }

        public IIdentityStorage Identity
        {
            get
            {
                if (_identityStorage == null)
                    _identityStorage = new IdentityStorage(_polkadotClient, _mapper, _logger, _peopleChainService, _serviceProvider);

                _identityStorage.BlockHash = BlockHash;
                return _identityStorage;
            }
        }

        public INominationPoolsStorage NominationPools
        {
            get
            {
                if (_nominationPoolsStorage == null)
                    _nominationPoolsStorage = new NominationPoolsStorage(_polkadotClient, _mapper, _logger);

                _nominationPoolsStorage.BlockHash = BlockHash;
                return _nominationPoolsStorage;
            }
        }

        public IParasStorage Paras
        {
            get
            {
                if (_parasStorage == null)
                    _parasStorage = new ParasStorage(_polkadotClient, _mapper, _logger);

                _parasStorage.BlockHash = BlockHash;
                return _parasStorage;
            }
        }

        public IParaSessionInfoStorage ParaSessionInfo
        {
            get
            {
                if (_paraSessionInfoStorage == null)
                    _paraSessionInfoStorage = new ParaSessionInfoStorage(_polkadotClient, _mapper, _logger);

                _paraSessionInfoStorage.BlockHash = BlockHash;
                return _paraSessionInfoStorage;
            }
        }

        public IRegistrarStorage Registrar
        {
            get
            {
                if (_registrarStorage == null)
                    _registrarStorage = new RegistrarStorage(_polkadotClient, _mapper, _logger);

                _registrarStorage.BlockHash = BlockHash;
                return _registrarStorage;
            }
        }

        public ISessionStorage Session
        {
            get
            {
                if (_sessionStorage == null)
                    _sessionStorage = new SessionStorage(_polkadotClient, _mapper, _logger);

                _sessionStorage.BlockHash = BlockHash;
                return _sessionStorage;
            }
        }

        public IStakingStorage Staking
        {
            get
            {
                if (_stakingStorage == null)
                    _stakingStorage = new StakingStorage(_polkadotClient, _mapper, _logger);

                _stakingStorage.BlockHash = BlockHash;
                return _stakingStorage;
            }
        }

        public ISystemStorage System
        {
            get
            {
                if (_systemStorage == null)
                    _systemStorage = new SystemStorage(_polkadotClient, _mapper, _logger);

                _systemStorage.BlockHash = BlockHash;
                return _systemStorage;
            }
        }

        public ITimestampStorage Timestamp
        {
            get
            {
                if (_timestampStorage == null)
                    _timestampStorage = new TimestampStorage(_polkadotClient, _mapper, _logger);

                _timestampStorage.BlockHash = BlockHash;
                return _timestampStorage;
            }
        }

        public IParachainInfoStorage ParachainInfo => throw new NotImplementedException();
    }
}
