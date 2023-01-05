using Ajuna.NetApi;
using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Meta;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Blazscan.Domain.Contracts.Repository;
using Blazscan.Domain.Contracts.Runtime;
using Blazscan.Infrastructure.DirectAccess.Runtime;
using Blazscan.Polkadot.NetApiExt.Generated;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace Blazscan.Infrastructure.DirectAccess.Test.Runtime
{
    public class PalletBuilderTest
    {
        protected readonly ISubstrateNodeRepository _substrateRepository;
        private readonly IPalletBuilder _palletBuilder;
        private readonly ICurrentMetaData _currentMetaData;

        public PalletBuilderTest()
        {
            _substrateRepository = Substitute.For<ISubstrateNodeRepository>();

            var mockClient = Substitute.For<SubstrateClientExt>(default, default);
            _substrateRepository.Client.Returns(mockClient);

            _currentMetaData = Substitute.For<ICurrentMetaData>();
            _palletBuilder = new DirectAccess.Runtime.PalletBuilder(_substrateRepository, _currentMetaData);
        }

        [Test]
        public void Build_InvalidPalletName_ShouldFailed()
        {
            _currentMetaData.GetPalletModule(Arg.Any<string>()).ReturnsNull();
            var mockMethod = Substitute.For<Method>((byte)0, (byte)0);

            Assert.Throws<ArgumentException>(() => _palletBuilder.BuildCall("WrongName", mockMethod));
            Assert.Throws<ArgumentException>(() => _palletBuilder.BuildEvent("WrongName", mockMethod));
            Assert.Throws<ArgumentException>(() => _palletBuilder.BuildError("WrongName", mockMethod));
        }

        [Test]
        public void Build_InvalidMethodParameter_ShouldFailed()
        {
            // Just mock a random pallet module, in order to bypass the if( != null)
            _currentMetaData.GetPalletModule(Arg.Any<string>()).Returns(new PalletModule());

            var mockMethod = Substitute.For<Method>((byte)0, (byte)0);
            Assert.Throws<ArgumentNullException>(() => _palletBuilder.BuildCall("Balances", new Method(0, 0)));
            Assert.Throws<ArgumentNullException>(() => _palletBuilder.BuildEvent("Balances", new Method(0, 0)));
            Assert.Throws<ArgumentNullException>(() => _palletBuilder.BuildError("Balances", new Method(0, 0)));
        }

        [Test]
        [TestCase(new string[] { "xxxx" }, "")]
        [TestCase(new string[] { "toto", "titi", "tata","xxxx" }, "toto.titi.tata")]
        public void GenerateDynamicNamespace_WithValidNamespace_ShouldWork(IEnumerable<string> currentNamespace, string result)
        {
            Assert.That(_palletBuilder.GenerateDynamicNamespaceBase(currentNamespace), Is.EqualTo(result));
        }

        [Test]
        public void GenerateDynamicNamespace_WithInvalidNamespace_ShouldFail()
        {
            Assert.That(_palletBuilder.GenerateDynamicNamespaceBase(new List<string>()), Is.EqualTo(string.Empty));
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.Throws<ArgumentNullException>(() => _palletBuilder.GenerateDynamicNamespaceBase(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        [Test]
        [Ignore("Todo debug")]
        [TestCase("0x0B3CA561D98401")]
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
