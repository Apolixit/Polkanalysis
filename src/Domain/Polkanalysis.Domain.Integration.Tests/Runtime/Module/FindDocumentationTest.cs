using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.Domain.Integration.Tests.Polkadot;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Infrastructure.Blockchain.Runtime.Module;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime.Module;

namespace Polkanalysis.Domain.Integration.Tests.Runtime.Module
{
    public class FindDocumentationTest : PolkadotIntegrationTest
    {
        private readonly IPalletBuilder _palletBuilder;
        private readonly IMetadataService _currentMetaData;
        private readonly ILogger<MetadataService> _logger;

        public FindDocumentationTest()
        {
            _logger = Substitute.For<ILogger<MetadataService>>();
            _currentMetaData = new MetadataService(_substrateService,
                                                      _substrateDbContext,
                                                      Substitute.For<ICoreService>(),
                                                      Substitute.For<ILogger<MetadataService>>());

            _palletBuilder = new PalletBuilder(_substrateService, Substitute.For<ILogger<PalletBuilder>>());
        }

        [Test]
        [TestCase(Infrastructure.Blockchain.Contracts.Pallet.Timestamp.Enums.Call.set)]
        [TestCase(Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums.Event.Endowed)]
        public void FindDocumentation_Enum_ShouldSuceed(object e)
        {
            Assert.That(_palletBuilder.FindDocumentation((Enum)e), Is.Not.Null);
        }

        [Test]
        [TestCase(typeof(Infrastructure.Blockchain.Contracts.Pallet.Timestamp.Enums.Call))]
        public void FindDocumentation_EnumType_ShouldSuceed(Type e)
        {
            Assert.That(_palletBuilder.FindDocumentation(e), Is.Not.Null);
        }

        [Test]
        public void FindNodeType_PalletTimestampEventSet_ShouldSuceed()
        {
            var nodeTypeGeneric = _palletBuilder.FindNodeType(typeof(Infrastructure.Blockchain.Contracts.Pallet.Timestamp.Enums.Call));
            Assert.That(nodeTypeGeneric, Is.Not.Null);

            var nodeTypeExplicit = _palletBuilder.FindNodeType(Infrastructure.Blockchain.Contracts.Pallet.Timestamp.Enums.Call.set.GetType());
            Assert.That(nodeTypeExplicit, Is.Not.Null);

            Assert.That(nodeTypeExplicit.Id, Is.EqualTo(nodeTypeGeneric.Id));

            Assert.That(nodeTypeGeneric.Docs, Is.Not.Null);
        }

        [Test]
        [TestCase(typeof(Infrastructure.Blockchain.Contracts.Core.Error.DispatchError), "0x0f26536564432c3ab92a7922ba25a86823bd71956839dc07752a4821a799b015")]
        public void FindDocumentation_ButNoDocumentationAssociated_ShouldFail(Type e, string hash)
        {
            Assert.That(_palletBuilder.FindDocumentation(e, new Substrate.NetApi.Model.Types.Base.Hash(hash)), Is.Null);
        }
    }
}
