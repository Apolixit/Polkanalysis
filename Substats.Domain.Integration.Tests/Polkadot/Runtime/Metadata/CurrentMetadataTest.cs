using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
using Substats.Domain.Contracts.Runtime;
using Substats.Domain.Runtime;
using Substats.Integration.Tests.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Integration.Tests.Polkadot.Runtime.Metadata
{
    public class CurrentMetadataTest : PolkadotIntegrationTest
    {
        private ICurrentMetaData _currentMetaData;

        [SetUp]
        public void Setup()
        {
            _currentMetaData = new CurrentMetaData(
                _substrateRepository,
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
