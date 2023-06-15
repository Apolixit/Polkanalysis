using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Secondary;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Runtime;

namespace Polkanalysis.Domain.Tests.Runtime.Metadata
{
    public class CurrentMetadataTest
    {
        private ICurrentMetaData _currentMetaData;

        [SetUp]
        public void Setup()
        {
            //using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            //var logger = loggerFactory.CreateLogger<CurrentMetaData>();


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
