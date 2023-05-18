using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.Integration.Tests.Contracts;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Domain.Runtime.Module;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.Repository;

namespace Polkanalysis.Domain.Integration.Tests.Repository.Explorer
{
    public abstract class ExplorerRepositoryTest : PolkadotIntegrationTest
    {
        protected IExplorerRepository _explorerRepository;
        protected ICurrentMetaData _currentMetaData;
        protected ISubstrateDecoding _substrateDecoding;

        // https://polkadot.subscan.io/block/10219793
        //  Block with extrinsic failed
        [SetUp]
        public void Setup()
        {
            _currentMetaData = new CurrentMetaData(
                _substrateRepository, Substitute.For<ILogger<CurrentMetaData>>());

            _substrateDecoding = new SubstrateDecoding(
                new EventNodeMapping(),
                _substrateRepository,
                new PalletBuilder(
                    _substrateRepository,
                    _currentMetaData),
                _currentMetaData,
                Substitute.For<ILogger<SubstrateDecoding>>());
            _explorerRepository = new ExplorerRepository(
                _substrateRepository,
                _substrateDecoding,
                new ModelBuilder(),
                Substitute.For<ILogger<ExplorerRepository>>());
        }
    }
}
