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
using Polkanalysis.Infrastructure.Blockchain.PeopleChain.Mapping;
using Polkanalysis.PeopleChain.NetApiExt.Generated;

namespace Polkanalysis.Infrastructure.Blockchain.PeopleChain.Storage
{
    internal class PeopleChainStorage : IStorage
    {
        private SubstrateClientExt _peopleChainClient;
        public readonly PeopleChainMapping _mapper;
        private readonly ILogger _logger;

        public PeopleChainStorage(SubstrateClientExt peopleChainClient, PeopleChainMapping mapper, ILogger logger)
        {
            _peopleChainClient = peopleChainClient;
            _mapper = mapper;
            _logger = logger;
        }

        public string? BlockHash { get; set; }

        private IIdentityStorage? _identityStorage = null;
        private IBalancesStorage? _balancesStorage = null;
        private ISystemStorage? _systemStorage = null;
        private ITimestampStorage? _timestampStorage = null;
        private IParachainInfoStorage? _parachainInfoStorage = null;

        public IIdentityStorage Identity
        {
            get
            {
                if (_identityStorage == null)
                    _identityStorage = new IdentityStorage(_peopleChainClient, _mapper, _logger);

                _identityStorage.BlockHash = BlockHash;
                return _identityStorage;
            }
        }

        public IAuctionsStorage Auctions => throw new NotImplementedException();

        public IAuthorshipStorage Authorship => throw new NotImplementedException();

        public IBabeStorage Babe => throw new NotImplementedException();

        public IBalancesStorage Balances
        {
            get
            {
                if (_balancesStorage == null)
                    _balancesStorage = new BalancesStorage(_peopleChainClient, _mapper, _logger);

                _balancesStorage.BlockHash = BlockHash;
                return _balancesStorage;
            }
        }

        public ICrowdloanStorage Crowdloan => throw new NotImplementedException();

        public INominationPoolsStorage NominationPools => throw new NotImplementedException();

        public IParasStorage Paras => throw new NotImplementedException();

        public IParaSessionInfoStorage ParaSessionInfo => throw new NotImplementedException();

        public IRegistrarStorage Registrar => throw new NotImplementedException();

        public ISessionStorage Session => throw new NotImplementedException();

        public IStakingStorage Staking => throw new NotImplementedException();

        public ISystemStorage System
        {
            get
            {
                if (_systemStorage == null)
                    _systemStorage = new SystemStorage(_peopleChainClient, _mapper, _logger);

                _systemStorage.BlockHash = BlockHash;
                return _systemStorage;
            }
        }

        public ITimestampStorage Timestamp
        {
            get
            {
                if (_timestampStorage == null)
                    _timestampStorage = new TimestampStorage(_peopleChainClient, _mapper, _logger);

                _timestampStorage.BlockHash = BlockHash;
                return _timestampStorage;
            }
        }

        public IParachainInfoStorage ParachainInfo
        {
            get
            {
                if (_parachainInfoStorage == null)
                    _parachainInfoStorage = new ParachainInfoStorage(_peopleChainClient, _mapper, _logger);

                _parachainInfoStorage.BlockHash = BlockHash;
                return _parachainInfoStorage;
            }
        }
    }
}
