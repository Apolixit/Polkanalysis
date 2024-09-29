using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Polkanalysis.Configuration.Contracts;
using Microsoft.Extensions.Logging;
using Substrate.NetApi;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Storage;
using Polkanalysis.Infrastructure.Blockchain.Common.Rpc;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Events;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Rpc;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot
{
    public class PolkadotService : BlockchainAbstractService
    {
        private SubstrateClientExt? _polkadotClient;
        private readonly ISubstrateEndpoint _substrateconfiguration;
        private readonly PeopleChainService _peopleChainService;
        private readonly IBlockchainMapping _blockchainMapping;
        private readonly ILogger<PolkadotService> _logger;

        public PolkadotService(
            ISubstrateEndpoint substrateconfiguration,
            IBlockchainMapping blockchainMapping,
            ILogger<PolkadotService> logger,
            PeopleChainService peopleChainService)
        {
            _substrateconfiguration = substrateconfiguration;
            _blockchainMapping = blockchainMapping;
            _logger = logger;
            _peopleChainService = peopleChainService;
        }

        public override string BlockchainName => "Polkadot";
        public override SubstrateClient AjunaClient => PolkadotClient;

        public SubstrateClientExt PolkadotClient
        {
            get
            {
                if (_polkadotClient == null)
                {
                    _polkadotClient = new SubstrateClientExt(_substrateconfiguration.WsEndpointUri, ChargeTransactionPayment.Default());
                }
                return _polkadotClient;
            }

            set
            {
                _polkadotClient = value;
            }
        }

        

        private IStorage? _polkadotStorage = null;
        public override IStorage Storage
        {
            get
            {
                if (_polkadotStorage == null)
                    _polkadotStorage = new PolkadotStorage(PolkadotClient, _blockchainMapping, _logger, _peopleChainService);

                return _polkadotStorage;
            }
        }

        private IRpc? _rpc = null;
        public override IRpc Rpc
        {
            get
            {
                if (_rpc == null)
                    _rpc = new Rpc(PolkadotClient);

                return _rpc;
            }
        }

        public override IConstants Constants => throw new NotImplementedException();

        public override ICalls Calls => throw new NotImplementedException();

        private IEvents? _events = null;
        public override IEvents Events
        {
            get
            {
                if (_events == null)
                    _events = new PolkadotEvents(PolkadotClient, _blockchainMapping, _logger);

                return _events;
            }
        }

        public override IErrors Errors => throw new NotImplementedException();

        public override IEnumerable<string> Dependencies => ["PeopleChain"];

        public override ILogger Logger => _logger;
    }
}
