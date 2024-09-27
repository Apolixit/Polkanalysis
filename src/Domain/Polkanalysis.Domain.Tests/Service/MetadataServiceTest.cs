using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Domain.Contracts.Service;
using Substrate.NET.Metadata.Service;
using Polkanalysis.Domain.Tests.Abstract;
using Polkanalysis.Domain.Service;
using System.Threading;
using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Domain.Tests.Service
{
    public class MetadataServiceTest : DomainTestAbstract
    {
        private IMetadataService _metadataService;
        private IExplorerService _explorerService;
        private ISubstrateService _substrateService;

        [SetUp]
        public void Setup()
        {
            var logger = Substitute.For<ILogger<MetadataService>>();
            _explorerService = Substitute.For<IExplorerService>();
            _substrateService = Substitute.For<ISubstrateService>();
            
            _metadataService = new MetadataService(
                _substrateService,
                _substrateDbContext,
                _explorerService,
                logger
            );

            _substrateService.Rpc.Chain.GetBlockHashAsync(CancellationToken.None).Returns(MockHash);
        }

        [Test]
        public void GetPalletModule_WithNullName_ShouldFailed()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _metadataService.GetPalletModuleByNameAsync(string.Empty, CancellationToken.None));
        }

        [Test]
        public async Task GetMetadataAsync_FromSpecVersion_ShouldSucceedAsync()
        {
            _substrateDbContext.SpecVersionModels.Add(new Infrastructure.Database.Contracts.Model.Version.SpecVersionModel()
            {
                SpecVersion = 10,
                BlockchainName = "Polkadot",
                BlockStart = 1000,
                BlockEnd = 2000,
                MetadataVersion = 14,
                Metadata = MockMetadata1
            });
            _substrateDbContext.SpecVersionModels.Add(new Infrastructure.Database.Contracts.Model.Version.SpecVersionModel()
            {
                SpecVersion = 20,
                BlockchainName = "Polkadot",
                BlockStart = 2001,
                BlockEnd = 3000,
                MetadataVersion = 14,
                Metadata = MockMetadata2
            });
            _substrateDbContext.SaveChanges();

            _substrateService.Rpc.Chain.GetBlockHashAsync(new BlockNumber((uint)1000), Arg.Any<CancellationToken>()).Returns(MockHash);
            _substrateService.Rpc.State.GetMetaDataAsync(MockHash, CancellationToken.None).Returns(MockMetadata1);
            _explorerService.GetDateTimeFromTimestampAsync(MockHash, CancellationToken.None).Returns(new DateTime(2024, 01, 01));

            var res = await _metadataService.GetMetadataAsync(10, CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }
    }
}
