using Blazscan.Domain.Contracts.Runtime;
using Blazscan.Domain.Runtime;
using Blazscan.Infrastructure.DirectAccess.Runtime;
using Blazscan.Integration.Tests.Contracts;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Infrastructure.DirectAccess.Integration.Tests.Polkadot.Runtime
{
    public class PalletInformationTest : PolkadotIntegrationTest
    {
        private IPalletInformation _palletInformation;
        private ICurrentMetaData _currentMetaData;
        private INode _node;

        [SetUp]
        public void Setup()
        {
            _node = new EventNode();
            _currentMetaData = new CurrentMetaData(_substrateRepository, Substitute.For<ILogger<CurrentMetaData>>());
            _palletInformation = new PalletInformation(_currentMetaData, Substitute.For<ILogger<PalletInformation>>(), _node);
        }

        [Test]
        public void PalletTimestamp_Call_ShouldSucceed()
        {
            var res = _palletInformation.GetModuleCalls("Timestamp", CancellationToken.None);

            Assert.IsNotNull(res);
        }
    }
}
