using Microsoft.Extensions.Logging;
using Polkanalysis.Configuration.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Rpc;
using Polkanalysis.PeopleChain.NetApiExt.Generated;
using Substrate.NetApi;
using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NetApi.Model.Extrinsics;
using Polkanalysis.Infrastructure.Blockchain.Common.Rpc;
using Substrate.NET.Metadata.Service;
using Substrate.NET.Metadata.V14;
using Substrate.NET.Utils.Address;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain.Storage;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain.Events;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.PeopleChain
{
    public class PeopleChainService : BlockchainAbstractService
    {
        private SubstrateClientExt? _peopleChainClient;
        private readonly ISubstrateEndpoint _substrateconfiguration;
        private readonly PeopleChainMapping _blockchainMapping;
        private readonly ILogger<PeopleChainService> _logger;

        public PeopleChainService(
            ISubstrateEndpoint substrateconfiguration,
            PeopleChainMapping blockchainMapping,
            ILogger<PeopleChainService> logger)
        {
            _substrateconfiguration = substrateconfiguration;
            _blockchainMapping = blockchainMapping;
            _logger = logger;
        }

        public SubstrateClientExt PeopleChainClient
        {
            get
            {
                if (_peopleChainClient == null)
                {
                    _peopleChainClient = new SubstrateClientExt(_substrateconfiguration.WsEndpointUri, ChargeTransactionPayment.Default());
                }
                return _peopleChainClient;
            }

            set
            {
                _peopleChainClient = value;
            }
        }

        public override SubstrateClient AjunaClient => PeopleChainClient;

        public override string BlockchainName => "PeopleChain";

        private IStorage? _polkadotStorage = null;
        public override IStorage Storage
        {
            get
            {
                if (_polkadotStorage == null)
                    _polkadotStorage = new PeopleChainStorage(PeopleChainClient, _blockchainMapping, _logger);

                return _polkadotStorage;
            }
        }

        private IRpc? _rpc = null;
        public override IRpc Rpc
        {
            get
            {
                if (_rpc == null)
                    _rpc = new Rpc(PeopleChainClient);

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
                    _events = new PeopleChainEvents(PeopleChainClient, _blockchainMapping, _logger);

                return _events;
            }
        }

        public override  IErrors Errors => throw new NotImplementedException();

        public override IEnumerable<string> Dependencies => [];

        public override ILogger Logger => _logger;
    }
}
