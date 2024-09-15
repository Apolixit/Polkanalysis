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
    }
}
