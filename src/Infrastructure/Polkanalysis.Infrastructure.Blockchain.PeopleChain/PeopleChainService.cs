using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Rpc;
using Polkanalysis.PeopleChain.NetApiExt.Generated;
using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using Polkanalysis.Infrastructure.Blockchain.Common.Rpc;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain.Storage;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain.Events;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain.Mapping;
using Substrate.NET.Utils.Core;
using Polkanalysis.Configuration.Contracts.Endpoints;

namespace Polkanalysis.Infrastructure.Blockchain.PeopleChain
{
    public class PeopleChainService : BlockchainAbstractService
    {
        private SubstrateClientExt? _peopleChainClient;
        
        private readonly PeopleChainMapping _blockchainMapping;
        private readonly ILogger<PeopleChainService> _logger;

        public PeopleChainService(
            ISubstrateEndpoint substrateconfiguration,
            PeopleChainMapping blockchainMapping,
            ILogger<PeopleChainService> logger) : base(substrateconfiguration, logger)
        {
            _blockchainMapping = blockchainMapping;
            _logger = logger;
        }

        protected override async Task InstanciateSubstrateServiceAsync()
        {
            _peopleChainClient = new SubstrateClientExt(_endpointInformation.Uri, ChargeTransactionPayment.Default());
        }

        public SubstrateClientExt PeopleChainClient
        {
            get
            {
                if (_peopleChainClient == null)
                {
                    InstanciateSubstrateServiceAsync();
                }

                return _peopleChainClient!;
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
                    _rpc = new Rpc(PeopleChainClient, new TmpChain(PeopleChainClient, MetadataHelper.GetMetadataFromHex));

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

        public override IErrors Errors => throw new NotImplementedException();

        public override ILogger Logger => _logger;
        public override string NetApiExtAssembly => "Polkanalysis.PeopleChain.NetApiExt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
        public override string NetApiExtModelNamespace => "Polkanalysis.PeopleChain.NetApiExt.Generated.Model";

        public override IEnumerable<string> DependenciesName => [];
        public override IEnumerable<ISubstrateService> ChainDependencies => [];
    }
}
