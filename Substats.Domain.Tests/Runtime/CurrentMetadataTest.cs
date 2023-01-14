using Substats.Domain.Contracts.Runtime;
using Substats.Domain.Contracts.Secondary;
using Substats.Infrastructure.DirectAccess.Runtime;
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

namespace Substats.Domain.Tests.Runtime
{
    public class CurrentMetadataTest
    {
        private ICurrentMetaData _currentMetaData;

        [SetUp]
        public void Setup()
        {
            //using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            //var logger = loggerFactory.CreateLogger<CalculationService>();
            var logger = Substitute.For<ILogger<CurrentMetaData>>();
            
            _currentMetaData = new CurrentMetaData(
                Substitute.For<ISubstrateNodeRepository>(),
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
