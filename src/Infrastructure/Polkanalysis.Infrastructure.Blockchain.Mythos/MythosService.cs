using Microsoft.Extensions.Logging;
using Polkanalysis.Configuration.Contracts.Endpoints;
using Polkanalysis.Infrastructure.Blockchain.Mythos.Mapping;
using Polkanalysis.Mythos.NetApiExt.Generated;
using Substrate.NetApi.Model.Extrinsics;

namespace Polkanalysis.Infrastructure.Blockchain.Mythos
{
    public class MythosService : BlockchainAbstractService
    {
        private SubstrateClientExt? _mythosClient;

        private readonly MythosMapping _blockchainMapping;
        private readonly ILogger<MythosService> _logger;

        public MythosService(
            ISubstrateEndpoint substrateconfiguration,
            MythosMapping blockchainMapping,
            ILogger<MythosService> logger) : base(substrateconfiguration, logger)
        {
            _blockchainMapping = blockchainMapping;
            _logger = logger;
        }

        public override string BlockchainName => "Mythos";

        public override ILogger Logger => _logger;

        public override IEnumerable<string> DependenciesName => [];

        public override IEnumerable<Contracts.ISubstrateService> ChainDependencies => [];

        public override string NetApiExtAssembly => "Polkanalysis.Mythos.NetApiExt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";

        public override string NetApiExtModelNamespace => "Polkanalysis.Mythos.NetApiExt.Generated.Model";

        protected override async Task InstanciateSubstrateServiceAsync()
        {
            _mythosClient = new SubstrateClientExt(_endpointInformation.Uri, ChargeTransactionPayment.Default());
        }

        public SubstrateClientExt MythosClient
        {
            get
            {
                if (_mythosClient == null)
                {
                    InstanciateSubstrateServiceAsync();
                }

                return _mythosClient!;
            }
        }

        public override Substrate.NetApi.SubstrateClient AjunaClient => MythosClient;

        public override Blockchain.Contracts.Contracts.IStorage Storage => throw new NotImplementedException();

        public override Blockchain.Contracts.Rpc.IRpc Rpc => throw new NotImplementedException();

        public override Blockchain.Contracts.Contracts.IConstants Constants => throw new NotImplementedException();

        public override Blockchain.Contracts.Contracts.ICalls Calls => throw new NotImplementedException();

        public override Blockchain.Contracts.Contracts.IEvents Events => throw new NotImplementedException();

        public override Blockchain.Contracts.Contracts.IErrors Errors => throw new NotImplementedException();
    }
}
