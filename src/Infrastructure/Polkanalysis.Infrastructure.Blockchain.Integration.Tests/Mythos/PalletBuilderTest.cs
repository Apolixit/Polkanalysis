using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime.Module;
using Polkanalysis.Infrastructure.Blockchain.Runtime.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Mythos
{
    public class PalletBuilderTest : MythosIntegrationTests
    {
        private readonly IPalletBuilder _palletBuilder;

        public PalletBuilderTest()
        {
            _palletBuilder = new PalletBuilder(_substrateService, Substitute.For<ILogger<PalletBuilder>>());
        }

        [Test]
        public void FindProperty_WhenValidEvent_PoolCommissionChangeRateUpdated_ShouldReturnProperties()
        {
            var property = _palletBuilder.FindProperty(Contracts.Pallet.Nfts.Enums.Event.Created);
            
            Assert.That(property, Is.Not.Null);
            Assert.That(property[0].Name, Is.EqualTo("collection"));
            Assert.That(property[1].Name, Is.EqualTo("creator"));
            Assert.That(property[2].Name, Is.EqualTo("owner"));
        }
    }
}
