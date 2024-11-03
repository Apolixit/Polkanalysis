using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Microsoft.Extensions.Logging;
using Substrate.NetApi;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Storage;
using Polkanalysis.Infrastructure.Blockchain.Common.Rpc;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Events;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Rpc;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;
using Substrate.NetApi.Modules.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.ExtrinsicTmp;
using Substrate.NET.Utils.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Configuration.Contracts.Endpoints;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot
{
    public class PolkadotService : BlockchainAbstractService
    {
        private SubstrateClientExt? _polkadotClient;
        private readonly PeopleChainService _peopleChainService;
        private readonly PolkadotMapping _blockchainMapping;
        private readonly ILogger<PolkadotService> _logger;
        

        public PolkadotService(
            ISubstrateEndpoint substrateconfiguration,
            PolkadotMapping blockchainMapping,
            ILogger<PolkadotService> logger,
            PeopleChainService peopleChainService) : base(substrateconfiguration, logger)
        {
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
                    _polkadotClient = new SubstrateClientExt(_endpointInformation.Uri, ChargeTransactionPayment.Default());
                    _polkadotClient.AddJsonConverter(new ExtrinsicOldJsonConverter(ChargeTransactionPayment.Default()));
                    _polkadotClient.AddJsonConverter(new ExtrinsicNewJsonConverter(ChargeTransactionPayment.Default()));
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
                {
                    _rpc = new Rpc(PolkadotClient, new TmpChain(PolkadotClient, MetadataHelper.GetMetadataFromHex));
                }

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

        public override IEnumerable<ISubstrateService> ChainDependencies => [ _peopleChainService ];
        public override IEnumerable<string> DependenciesName => ChainDependencies.Select(x => x.BlockchainName);

        public override ILogger Logger => _logger;

        public const string PolkadotNetApiExtAssembly = "Polkanalysis.Polkadot.NetApiExt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
        public override string NetApiExtAssembly => PolkadotNetApiExtAssembly;
        public override string NetApiExtModelNamespace => "Polkanalysis.Polkadot.NetApiExt.Generated.Model";
    }
}
