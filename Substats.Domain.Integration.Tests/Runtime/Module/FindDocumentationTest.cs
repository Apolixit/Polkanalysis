﻿using Ajuna.NetApi.Model.Types;
using Substats.Domain.Contracts.Runtime;
using Substats.Integration.Tests.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substats.Domain.Contracts.Runtime.Module;
using Substats.Domain.Runtime;
using Substats.Domain.Runtime.Module;

namespace Substats.Domain.Integration.Tests.Runtime.Module
{
    public class FindDocumentationTest : PolkadotIntegrationTest
    {
        private readonly IPalletBuilder _palletBuilder;
        private readonly ICurrentMetaData _currentMetaData;
        private readonly ILogger<CurrentMetaData> _logger;

        public FindDocumentationTest()
        {
            _logger = Substitute.For<ILogger<CurrentMetaData>>();
            _currentMetaData = new CurrentMetaData(_substrateRepository, _logger);
            _palletBuilder = new PalletBuilder(_substrateRepository, _currentMetaData);
        }

        [Test]
        [TestCase(Substats.Polkadot.NetApiExt.Generated.Model.pallet_timestamp.pallet.Call.set)]
        [TestCase(Substats.Polkadot.NetApiExt.Generated.Model.pallet_balances.pallet.Event.Endowed)]
        [TestCase(Substats.Polkadot.NetApiExt.Generated.Model.pallet_democracy.pallet.Call.cancel_referendum)]
        [TestCase(Substats.Polkadot.NetApiExt.Generated.Model.pallet_democracy.pallet.Error.AlreadyCanceled)]
        public void FindDocumentation_Enum_ShouldSuceed(object e)
        {
            Assert.IsNotNull(_palletBuilder.FindDocumentation((Enum)e));
        }

        [Test]
        [TestCase(typeof(Substats.Polkadot.NetApiExt.Generated.Model.pallet_timestamp.pallet.Call))]
        public void FindDocumentation_EnumType_ShouldSuceed(Type e)
        {
            Assert.IsNotNull(_palletBuilder.FindDocumentation(e));
        }

        //public void FindDocumentation_Pallet_ShouldSuceed(object e)
        //{
        //    Assert.IsNotNull(_palletBuilder.FindDocumentation((Enum)e));
        //}

        [Test]
        public void FindDocumentation_PalletTimestampEventSet_ShouldSuceed()
        {
            var nodeTypeGeneric = _palletBuilder.FindNodeType(typeof(Substats.Polkadot.NetApiExt.Generated.Model.pallet_timestamp.pallet.Call));
            Assert.IsNotNull(nodeTypeGeneric);

            var nodeTypeExplicit = _palletBuilder.FindNodeType(Substats.Polkadot.NetApiExt.Generated.Model.pallet_timestamp.pallet.Call.set.GetType());
            Assert.IsNotNull(nodeTypeExplicit);

            Assert.AreEqual(nodeTypeExplicit, nodeTypeGeneric);

            Assert.IsNotNull(nodeTypeGeneric.Docs);
        }

        [Test]
        [TestCase(typeof(Substats.Polkadot.NetApiExt.Generated.Model.pallet_democracy.Releases))]
        [TestCase(typeof(Substats.Polkadot.NetApiExt.Generated.Model.xcm.EnumVersionedXcm))]
        [TestCase(typeof(Substats.Polkadot.NetApiExt.Generated.SubstrateClientExt))]
        [TestCase(typeof(Substats.Polkadot.NetApiExt.Generated.Storage.AuctionsCalls))]
        [TestCase(typeof(Substats.Polkadot.NetApiExt.Generated.Storage.ConfigurationStorage))]
        [TestCase(typeof(Substats.Polkadot.NetApiExt.Generated.Types.Base.Arr0U8))]
        [TestCase(typeof(Substats.Polkadot.NetApiExt.Generated.Types.Base.Arr2BaseTuple))]
        public void FindDocumentation_ButNoDocumentationAssociated_ShouldFail(Type e)
        {
            Assert.IsNull(_palletBuilder.FindDocumentation(e));
        }
    }
}