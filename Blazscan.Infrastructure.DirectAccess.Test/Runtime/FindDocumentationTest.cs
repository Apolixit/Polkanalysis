using Ajuna.NetApi.Model.Types;
using Blazscan.Domain.Contracts.Runtime;
using Blazscan.Infrastructure.DirectAccess.Runtime;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Infrastructure.DirectAccess.Test.Runtime
{
    public class FindDocumentationTest : IntegrationTest
    {
        private readonly IPalletBuilder _palletBuilder;
        private readonly ICurrentMetaData _currentMetaData;

        public FindDocumentationTest()
        {
            _currentMetaData = new CurrentMetaData(_substrateRepository);
            _palletBuilder = new PalletBuilder(_substrateRepository, _currentMetaData);
        }

        [Test]
        [TestCase(NetApiExt.Generated.Model.pallet_timestamp.pallet.Call.set)]
        [TestCase(NetApiExt.Generated.Model.pallet_balances.pallet.Event.Endowed)]
        [TestCase(NetApiExt.Generated.Model.pallet_democracy.pallet.Call.cancel_referendum)]
        [TestCase(NetApiExt.Generated.Model.pallet_democracy.pallet.Error.AlreadyCanceled)]
        public void FindDocumentation_Enum_ShouldSuceed(Object e)
        {
            Assert.IsNotNull(_palletBuilder.FindDocumentation((Enum)e));
        }

        [Test]
        [TestCase(typeof(NetApiExt.Generated.Model.pallet_timestamp.pallet.Call))]
        public void FindDocumentation_EnumType_ShouldSuceed(Type e)
        {
            Assert.IsNotNull(_palletBuilder.FindDocumentation(e));
        }

        [Test]
        public void FindDocumentation_PalletTimestampEventSet_ShouldSuceed()
        {
            var nodeTypeGeneric = _palletBuilder.FindNodeType(typeof(NetApiExt.Generated.Model.pallet_timestamp.pallet.Call));
            Assert.IsNotNull(nodeTypeGeneric);

            var nodeTypeExplicit = _palletBuilder.FindNodeType(NetApiExt.Generated.Model.pallet_timestamp.pallet.Call.set.GetType());
            Assert.IsNotNull(nodeTypeExplicit);

            Assert.AreEqual(nodeTypeExplicit, nodeTypeGeneric);

            Assert.IsNotNull(nodeTypeGeneric.Docs);
        }

        [Test]
        [TestCase(typeof(NetApiExt.Generated.Model.pallet_democracy.Releases))]
        [TestCase(typeof(NetApiExt.Generated.Model.xcm.EnumVersionedXcm))]
        [TestCase(typeof(NetApiExt.Generated.SubstrateClientExt))]
        [TestCase(typeof(NetApiExt.Generated.Storage.AuctionsCalls))]
        [TestCase(typeof(NetApiExt.Generated.Storage.ConfigurationStorage))]
        [TestCase(typeof(NetApiExt.Generated.Types.Base.Arr0U8))]
        [TestCase(typeof(NetApiExt.Generated.Types.Base.Arr2BaseTuple))]
        public void FindDocumentation_ButNoDocumentationAssociated_ShouldFail(Type e)
        {
            Assert.IsNull(_palletBuilder.FindDocumentation(e));
        }
    }
}
