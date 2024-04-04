using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Integration.Tests.Polkadot;
using Polkanalysis.Domain.Runtime;

namespace Polkanalysis.Domain.Integration.Tests.Runtime.Metadata
{
    public class CurrentMetadataTest : PolkadotIntegrationTest
    {
        private ICurrentMetaData _currentMetaData;

        [SetUp]
        public void Setup()
        {
            _currentMetaData = new CurrentMetaData(
                _substrateService,
                Substitute.For<ILogger<CurrentMetaData>>());
        }

        [Test]
        public void GetPalletModule_WithInvalidName_ShouldFailed()
        {
            Assert.Throws<InvalidOperationException>(() => _currentMetaData.GetPalletModule("NotFoundModuleName"));
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
