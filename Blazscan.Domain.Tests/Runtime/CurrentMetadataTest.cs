using Blazscan.Domain.Contracts.Runtime;
using Blazscan.Domain.Contracts.Secondary;
using Blazscan.Infrastructure.DirectAccess.Runtime;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Domain.Tests.Runtime
{
    public class CurrentMetadataTest
    {
        private ICurrentMetaData _currentMetaData;

        [SetUp]
        public void Setup()
        {
            var logger = Substitute.For<ILogger<CurrentMetaData>>();
            
            _currentMetaData = new CurrentMetaData(
                Substitute.For<ISubstrateNodeRepository>(),
                logger
            );
        }

        [Test]
        public void GetPalletModule_WithNullName_ShouldFailed()
        {
            Assert.Throws<ArgumentException>(() => _currentMetaData.GetPalletModule(Arg.Any<string>()));
        }

        [Test]
        public void GetPalletModule_WithInvalidName_ShouldFailed()
        {
            // We don't want to find anything in current metadata
            _currentMetaData.GetCurrentMetadata().ReturnsNull();
            Assert.Throws<ArgumentException>(() => _currentMetaData.GetPalletModule("NotFoundModuleName"));
        }

        [Test]
        public void GetPalletType_WithInvalidType_ShouldFailed()
        {
            _currentMetaData.GetCurrentMetadata().ReturnsNull();
            Assert.Throws<InvalidOperationException>(() => _currentMetaData.GetPalletType(10));
        }
    }
}
