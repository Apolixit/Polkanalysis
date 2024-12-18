using Polkanalysis.Domain.Runtime;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Domain.Service;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Integration.Tests.Polkadot;
using Microsoft.Extensions.Caching.Distributed;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Runtime.Module;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime.Module;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime;
using Polkanalysis.Infrastructure.Blockchain.Runtime;
using Microsoft.Extensions.Caching.Hybrid;

namespace Polkanalysis.Domain.Integration.Tests.Service.Explorer
{
    [CancelAfter(RepositoryMaxTimeout)]
    public abstract class ExplorerRepositoryTest : PolkadotIntegrationTest
    {
        protected IExplorerService _explorerRepository;
        protected IMetadataService _currentMetaData;
        protected ISubstrateDecoding _substrateDecoding;
        protected IAccountService _accountRepository;
        protected IPalletBuilder _palletBuilder;
        protected ICoreService _coreService;

        // https://polkadot.subscan.io/block/10219793
        //  Block with extrinsic failed
        [SetUp]
        public void Setup()
        {
            _palletBuilder = new PalletBuilder(
                _substrateService,
                Substitute.For<ILogger<PalletBuilder>>());

            _coreService = new CoreService(_substrateService, Substitute.For<ILogger<CoreService>>());

            _currentMetaData = new MetadataService(_substrateService,
                                                      _substrateDbContext,
                                                      _coreService,
                                                      Substitute.For<ILogger<MetadataService>>());

            _accountRepository = new AccountService(_substrateService, _substrateDbContext, Substitute.For<ILogger<AccountService>>(), Substitute.For<HybridCache>());

            _substrateDecoding = new SubstrateDecoding(
                new EventNodeMapping(),
                _substrateService,
                new PalletBuilder(
                    _substrateService,
                    Substitute.For<ILogger<PalletBuilder>>()),
                Substitute.For<ILogger<SubstrateDecoding>>());

            _explorerRepository = new ExplorerService(
                _substrateService,
                _substrateDecoding,
                _accountRepository,
                Substitute.For<ILogger<ExplorerService>>(),
                _coreService);
        }
    }
}
