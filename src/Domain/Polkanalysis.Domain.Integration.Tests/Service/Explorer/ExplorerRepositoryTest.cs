using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Runtime;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Domain.Runtime.Module;
using Polkanalysis.Domain.Service;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Integration.Tests.Polkadot;
using Microsoft.Extensions.Caching.Distributed;

namespace Polkanalysis.Domain.Integration.Tests.Service.Explorer
{
    [CancelAfter(RepositoryMaxTimeout)]
    public abstract class ExplorerRepositoryTest : PolkadotIntegrationTest
    {
        protected IExplorerService _explorerRepository;
        protected ICurrentMetaData _currentMetaData;
        protected ISubstrateDecoding _substrateDecoding;
        protected IAccountService _accountRepository;

        // https://polkadot.subscan.io/block/10219793
        //  Block with extrinsic failed
        [SetUp]
        public void Setup()
        {
            _currentMetaData = new CurrentMetaData(
                _substrateService, Substitute.For<ILogger<CurrentMetaData>>());

            _accountRepository = new AccountService(_substrateService, _substrateDbContext, Substitute.For<ILogger<AccountService>>(), Substitute.For<IDistributedCache>());

            _substrateDecoding = new SubstrateDecoding(
                new EventNodeMapping(),
                _substrateService,
                new PalletBuilder(
                    _substrateService,
                    _currentMetaData, Substitute.For<ILogger<PalletBuilder>>()),
                _currentMetaData,
                Substitute.For<ILogger<SubstrateDecoding>>());
            _explorerRepository = new ExplorerService(
                _substrateService,
                _substrateDecoding,
                _accountRepository,
                Substitute.For<ILogger<ExplorerService>>());
        }
    }
}
