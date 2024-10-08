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
        [TestCase(Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums.Event.Blacklisted)]
        [TestCase(Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums.Error.AlreadyCanceled)]
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
        [TestCase(typeof(Infrastructure.Blockchain.Contracts.Core.Error.DispatchError))]
        [TestCase(typeof(Infrastructure.Blockchain.Contracts.Pallet.Democracy.PriorLock))]
        [TestCase(typeof(Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums.EnumVersionedXcm))]
        //[TestCase(typeof(Polkanalysis.Polkadot.NetApiExt.Generated.SubstrateClientExt))]
        //[TestCase(typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Storage.AuctionsCalls))]
        //[TestCase(typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Storage.ConfigurationStorage))]
        //[TestCase(typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr0U8))]
        //[TestCase(typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr2BaseTuple))]
        public void FindDocumentation_ButNoDocumentationAssociated_ShouldFail(Type e)
        {
            Assert.That(_palletBuilder.FindDocumentation(e), Is.Null);
        }
    }
}
