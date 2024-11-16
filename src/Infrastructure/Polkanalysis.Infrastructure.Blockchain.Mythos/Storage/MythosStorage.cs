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
using Polkanalysis.Infrastructure.Blockchain.Mythos.Mapping;
using Polkanalysis.Mythos.NetApiExt.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Mythos.Storage
{
    public class MythosStorage : IStorage
    {
        private readonly SubstrateClientExt _mythosClient;
        public readonly MythosMapping _mapper;
        private readonly ILogger _logger;

        public MythosStorage(SubstrateClientExt peopleChainClient, MythosMapping mapper, ILogger logger)
        {
            _mythosClient = peopleChainClient;
            _mapper = mapper;
            _logger = logger;
        }

        private ISystemStorage? _systemStorage = null;
        private ITimestampStorage? _timestampStorage = null;

        public string? BlockHash { get; set; }

        public ISystemStorage System
        {
            get
            {
                if (_systemStorage == null)
                    _systemStorage = new SystemStorage(_mythosClient, _mapper, _logger);

                _systemStorage.BlockHash = BlockHash;
                return _systemStorage;
            }
        }

        public ITimestampStorage Timestamp
        {
            get
            {
                if (_timestampStorage == null)
                    _timestampStorage = new TimestampStorage(_mythosClient, _mapper, _logger);

                _timestampStorage.BlockHash = BlockHash;
                return _timestampStorage;
            }
        }

        public IAuctionsStorage Auctions => throw new NotImplementedException();

        public IAuthorshipStorage Authorship => throw new NotImplementedException();

        public IBabeStorage Babe => throw new NotImplementedException();

        public IBalancesStorage Balances => throw new NotImplementedException();

        public ICrowdloanStorage Crowdloan => throw new NotImplementedException();

        public IIdentityStorage Identity => throw new NotImplementedException();

        public INominationPoolsStorage NominationPools => throw new NotImplementedException();

        public IParasStorage Paras => throw new NotImplementedException();

        public IParaSessionInfoStorage ParaSessionInfo => throw new NotImplementedException();

        public IRegistrarStorage Registrar => throw new NotImplementedException();

        public ISessionStorage Session => throw new NotImplementedException();

        public IStakingStorage Staking => throw new NotImplementedException();

        

        public IParachainInfoStorage ParachainInfo => throw new NotImplementedException();
    }
}
