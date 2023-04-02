using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using Polkanalysis.Domain.Runtime.Module;

namespace Polkanalysis.Infrastructure.DirectAccess.Test.Runtime
{
    public class PalletBuilderTest
    {
        protected readonly ISubstrateRepository _substrateRepository;
        private readonly IPalletBuilder _palletBuilder;
        private readonly ICurrentMetaData _currentMetaData;

        public PalletBuilderTest()
        {
            _substrateRepository = Substitute.For<ISubstrateRepository>();

            //var mockClient = Substitute.For<SubstrateClientExt>(default, default);
            //var mockClient = Substitute.For<ISubstrateClientRepository>();
            //_substrateRepository.Api.Returns(mockClient);

            _currentMetaData = Substitute.For<ICurrentMetaData>();
            _palletBuilder = new PalletBuilder(_substrateRepository, _currentMetaData);
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
            Assert.Throws<ArgumentNullException>(() => _palletBuilder.BuildCall("Balances", null));
            //Assert.Throws<ArgumentNullException>(() => _palletBuilder.BuildCall("Balances", new Method(0, 0, null)));

            Assert.Throws<ArgumentNullException>(() => _palletBuilder.BuildEvent("Balances", null));
            //Assert.Throws<ArgumentNullException>(() => _palletBuilder.BuildEvent("Balances", new Method(0, 0, null)));

            Assert.Throws<ArgumentNullException>(() => _palletBuilder.BuildError("Balances", null));
            //Assert.Throws<ArgumentNullException>(() => _palletBuilder.BuildError("Balances", new Method(0, 0, null)));
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
            Assert.Throws<ArgumentNullException>(() => _palletBuilder.GenerateDynamicNamespaceBase(Arg.Any<IEnumerable<string>>()));
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
            //var timestampPalletError = new Substrate.NetApi.Model.Meta.PalletErrors();
            //timestampPalletError.TypeId.Returns((uint)0);
            //var timestampPalletEvent = new Substrate.NetApi.Model.Meta.PalletEvents();
            //timestampPalletEvent.TypeId.Returns((uint)0);

            timestampPalletModule.Calls = timestampPalletCall;

            var dictionnaryModule = new Dictionary<uint, Substrate.NetApi.Model.Meta.PalletModule>
            {
                { 0, timestampPalletModule }
            };

            //_substrateRepository.Api.Returns(Substitute.For<ISubstrateClientRepository>());

            _substrateRepository.RuntimeMetadata.NodeMetadata.Modules.Returns(dictionnaryModule);

            var timestampType = new NodeTypeVariant()
            {
                Path = new string[] { "pallet_timestamp", "pallet", "call" },
            };

            var dictionnaryType = new Dictionary<uint, NodeType>
            {
                { 0, timestampType }
            };
            _substrateRepository.RuntimeMetadata.NodeMetadata.Types.Returns(dictionnaryType);
            var callBuilded = _palletBuilder.BuildCall("Timestamp", new Method(3, 0, new byte[] { 1 }));

            var timestampSet = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_timestamp.pallet.EnumCall();

            var value2 = new BaseCom<U64>();
            value2.Value.Returns(new CompactInteger(1671349818016));

            timestampSet.Value = Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_timestamp.pallet.Call.set;
            timestampSet.Value2 = value2;

            Assert.Equals(callBuilded, timestampSet);
        }
    }
}
