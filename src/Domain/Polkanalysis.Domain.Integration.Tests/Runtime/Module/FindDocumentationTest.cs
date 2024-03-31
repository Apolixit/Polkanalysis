using Polkanalysis.Domain.Contracts.Runtime;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.Domain.Runtime.Module;
using Polkanalysis.Domain.Integration.Tests.Polkadot;

namespace Polkanalysis.Domain.Integration.Tests.Runtime.Module
{
    public class FindDocumentationTest : PolkadotIntegrationTest
    {
        private readonly IPalletBuilder _palletBuilder;
        private readonly ICurrentMetaData _currentMetaData;
        private readonly ILogger<CurrentMetaData> _logger;

        public FindDocumentationTest()
        {
            _logger = Substitute.For<ILogger<CurrentMetaData>>();
            _currentMetaData = new CurrentMetaData(_substrateService, _logger);
            _palletBuilder = new PalletBuilder(_substrateService, _currentMetaData);
        }

        [Test, Ignore("Todo debug algo")]
        [TestCase(Infrastructure.Blockchain.Contracts.Pallet.Timestamp.Enums.Call.set)]
        [TestCase(Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums.Event.Endowed)]
        [TestCase(Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums.Event.Blacklisted)]
        [TestCase(Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums.Error.AlreadyCanceled)]
        public void FindDocumentation_Enum_ShouldSuceed(object e)
        {
            Assert.IsNotNull(_palletBuilder.FindDocumentation((Enum)e));
        }

        [Test, Ignore("Todo debug algo")]
        [TestCase(typeof(Infrastructure.Blockchain.Contracts.Pallet.Timestamp.Enums.Call))]
        public void FindDocumentation_EnumType_ShouldSuceed(Type e)
        {
            Assert.IsNotNull(_palletBuilder.FindDocumentation(e));
        }

        [Test, Ignore("Todo debug algo")]
        public void FindDocumentation_PalletTimestampEventSet_ShouldSuceed()
        {
            var nodeTypeGeneric = _palletBuilder.FindNodeType(typeof(Infrastructure.Blockchain.Contracts.Pallet.Timestamp.Enums.Call));
            Assert.IsNotNull(nodeTypeGeneric);

            var nodeTypeExplicit = _palletBuilder.FindNodeType(Infrastructure.Blockchain.Contracts.Pallet.Timestamp.Enums.Call.set.GetType());
            Assert.IsNotNull(nodeTypeExplicit);

            Assert.AreEqual(nodeTypeExplicit, nodeTypeGeneric);

            Assert.IsNotNull(nodeTypeGeneric.Docs);
        }

        [Test]
        [TestCase(typeof(Infrastructure.Blockchain.Contracts.Pallet.Democracy.PriorLock))]
        [TestCase(typeof(Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums.EnumVersionedXcm))]
        //[TestCase(typeof(Polkanalysis.Polkadot.NetApiExt.Generated.SubstrateClientExt))]
        //[TestCase(typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Storage.AuctionsCalls))]
        //[TestCase(typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Storage.ConfigurationStorage))]
        //[TestCase(typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr0U8))]
        //[TestCase(typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr2BaseTuple))]
        public void FindDocumentation_ButNoDocumentationAssociated_ShouldFail(Type e)
        {
            Assert.IsNull(_palletBuilder.FindDocumentation(e));
        }
    }
}
