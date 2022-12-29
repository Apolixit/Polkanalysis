using Ajuna.NetApi;
using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Meta;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Blazscan.Domain.Contracts.Repository;
using Blazscan.Domain.Contracts.Runtime;
using Blazscan.Infrastructure.DirectAccess.Runtime;
using Blazscan.Integration.Tests.Contracts;
using Blazscan.Polkadot.NetApiExt.Generated;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Infrastructure.DirectAccess.Integration.Tests.Polkadot.Runtime
{
    public class PalletBuilderTest : PolkadotIntegrationTest
    {
        private readonly IPalletBuilder _palletBuilder;
        private readonly ICurrentMetaData _currentMetaData;

        public PalletBuilderTest()
        {
            _currentMetaData = new CurrentMetaData(_substrateRepository);
            _palletBuilder = new PalletBuilder(_substrateRepository, _currentMetaData);
        }

        [Test]
        [Ignore("Todo debug")]
        [TestCase("0x0BA05236248501")]
        public void BuildCall_PalletTimestampSetTime_ShouldSucceed(string hex)
        {
            var timestampPalletModule = Substitute.For<PalletModule>();
            var timestampPalletCall = Substitute.For<PalletCalls>();
            //timestampPalletCall.TypeId.Returns((uint)0);
            timestampPalletCall.TypeId = 0;
            //var timestampPalletError = new Ajuna.NetApi.Model.Meta.PalletErrors();
            //timestampPalletError.TypeId.Returns((uint)0);
            //var timestampPalletEvent = new Ajuna.NetApi.Model.Meta.PalletEvents();
            //timestampPalletEvent.TypeId.Returns((uint)0);

            timestampPalletModule.Calls = timestampPalletCall;

            var dictionnaryModule = new Dictionary<uint, Ajuna.NetApi.Model.Meta.PalletModule>
            {
                { 0, timestampPalletModule }
            };

            _substrateRepository.Client.Returns(Substitute.For<SubstrateClientExt>());

            _substrateRepository.Client.MetaData.NodeMetadata.Modules.Returns(dictionnaryModule);

            var timestampType = new Ajuna.NetApi.Model.Meta.NodeTypeVariant()
            {
                Path = new string[] { "pallet_timestamp", "pallet", "call" },
            };

            var dictionnaryType = new Dictionary<uint, Ajuna.NetApi.Model.Meta.NodeType>
            {
                { 0, timestampType }
            };
            _substrateRepository.Client.MetaData.NodeMetadata.Types.Returns(dictionnaryType);
            //_substrateRepository.Client.Returns(new NetApiExt.Generated.SubstrateClientExt(new Uri("wss://rpc.polkadot.io"), ChargeTransactionPayment.Default()));
            //var callBuilded = _palletBuilder.BuildCall("Timestamp", new Method(3, 0, Utils.HexToByteArray(hex)));
            var callBuilded = _palletBuilder.BuildCall("Timestamp", new Method(3, 0, new byte[] { 1 }));

            var timestampSet = new Blazscan.Polkadot.NetApiExt.Generated.Model.pallet_timestamp.pallet.EnumCall();

            var value2 = new BaseCom<U64>();
            value2.Value.Returns(new CompactInteger(1671349818016));

            timestampSet.Value = Blazscan.Polkadot.NetApiExt.Generated.Model.pallet_timestamp.pallet.Call.set;
            timestampSet.Value2 = value2;

            Assert.Equals(callBuilded, timestampSet);
        }
    }
}
