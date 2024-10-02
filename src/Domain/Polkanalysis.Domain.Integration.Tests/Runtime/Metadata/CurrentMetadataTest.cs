using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Integration.Tests.Polkadot;
using Polkanalysis.Domain.Runtime;

namespace Polkanalysis.Domain.Integration.Tests.Runtime.Metadata
{
    public class CurrentMetadataTest : PolkadotIntegrationTest
    {
        private IMetadataService _currentMetaData;

        [SetUp]
        public void Setup()
        {
            _currentMetaData = new MetadataService(_substrateService,
                                                      _substrateDbContext,
                                                      Substitute.For<ICoreService>(),
                                                      Substitute.For<ILogger<MetadataService>>());
        }

        [Test]
        public void GetPalletModule_WithInvalidName_ShouldFailed()
        {
            Assert.ThrowsAsync<InvalidOperationException>(() => _currentMetaData.GetPalletModuleByNameAsync("NotFoundModuleName", CancellationToken.None));
        }

        [Test]
        public void GetPalletType_WithInvalidType_ShouldFailed()
        {
            Assert.Throws<KeyNotFoundException>(() => _currentMetaData.GetPalletType(1000));
        }

        [Test]
        public void GetPalletType_WithvalidType_ShouldSucceed()
        {
            Assert.That(_currentMetaData.GetPalletType(1), Is.Not.Null);
        }
    }
}
