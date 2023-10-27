using Polkanalysis.Domain.Contracts.Runtime;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.Infrastructure.Blockchain.Contracts;

namespace Polkanalysis.Domain.Tests.Runtime.Metadata
{
    public class CurrentMetadataTest
    {
        private ICurrentMetaData _currentMetaData;

        [SetUp]
        public void Setup()
        {
            var logger = Substitute.For<ILogger<CurrentMetaData>>();

            _currentMetaData = new CurrentMetaData(
                Substitute.For<ISubstrateService>(),
                logger
            );
        }

        [Test]
        public void GetPalletModule_WithNullName_ShouldFailed()
        {
            Assert.Throws<ArgumentNullException>(() => _currentMetaData.GetPalletModule(Arg.Any<string>()));
        }


    }
}
