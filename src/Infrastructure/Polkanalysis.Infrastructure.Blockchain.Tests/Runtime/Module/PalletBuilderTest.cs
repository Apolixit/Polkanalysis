using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime.Module;
using Polkanalysis.Infrastructure.Blockchain.Runtime.Module;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Infrastructure.DirectAccess.Test.Runtime
{
    public class PalletBuilderTest
    {
        protected static Hash MockHash = new Hash("0xc0096358534ec8d21d01d34b836eed476a1c343f8724fa2153dc0725ad797a90");

        protected readonly ISubstrateService _substrateService;
        private readonly IPalletBuilder _palletBuilder;
        private readonly IMetadataService _currentMetaData;

        public PalletBuilderTest()
        {
            _substrateService = Substitute.For<ISubstrateService>();

            //var mockClient = Substitute.For<SubstrateClientExt>(default, default);
            //var mockClient = Substitute.For<ISubstrateClientRepository>();
            //_substrateRepository.Api.Returns(mockClient);

            _currentMetaData = Substitute.For<IMetadataService>();
            _palletBuilder = new PalletBuilder(_substrateService, Substitute.For<ILogger<PalletBuilder>>());
        }

        [Test]
        public void Build_InvalidPalletName_ShouldFailed()
        {
            _currentMetaData.GetPalletModuleByNameAsync(Arg.Any<Hash>(), Arg.Any<string>(), CancellationToken.None).ReturnsNull();
            var mockMethod = Substitute.For<Method>((byte)0, (byte)0);

            Assert.Throws<ArgumentException>(() => _palletBuilder.BuildCall(MockHash, "WrongName", mockMethod));
            Assert.Throws<ArgumentException>(() => _palletBuilder.BuildEvent(MockHash, "WrongName", mockMethod));
            Assert.Throws<ArgumentException>(() => _palletBuilder.BuildError(MockHash, "WrongName", mockMethod));
        }

        [Test]
        public void Build_InvalidMethodParameter_ShouldFailed()
        {
            // Just mock a random pallet module, in order to bypass the if( != null)
            _currentMetaData.GetPalletModuleByNameAsync(Arg.Any<Hash>(), Arg.Any<string>(), CancellationToken.None).Returns(new PalletModule());

            var mockMethod = Substitute.For<Method>((byte)0, (byte)0);
            Assert.Throws<ArgumentNullException>(() => _palletBuilder.BuildCall(MockHash, "Balances", null));
            //Assert.Throws<ArgumentNullException>(() => _palletBuilder.BuildCall("Balances", new Method(0, 0, null)));

            Assert.Throws<ArgumentNullException>(() => _palletBuilder.BuildEvent(MockHash, "Balances", null));
            //Assert.Throws<ArgumentNullException>(() => _palletBuilder.BuildEvent("Balances", new Method(0, 0, null)));

            Assert.Throws<ArgumentNullException>(() => _palletBuilder.BuildError(MockHash, "Balances", null));
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
            Assert.Throws<ArgumentNullException>(() => _palletBuilder.GenerateDynamicNamespaceBase(null!));
        }

        //[Test]
        //[Ignore("Todo debug")]
        //[TestCase("0x0B3CA561D98401")]
        //public void BuildCall_PalletTimestampSetTime_ShouldSucceed(string hex)
        //{
        //    var timestampPalletModule = Substitute.For<PalletModule>();
        //    var timestampPalletCall = Substitute.For<PalletCalls>();
        //    //timestampPalletCall.TypeId.Returns((uint)0);
        //    timestampPalletCall.TypeId = 0;
        //    //var timestampPalletError = new Substrate.NetApi.Model.Meta.PalletErrors();
        //    //timestampPalletError.TypeId.Returns((uint)0);
        //    //var timestampPalletEvent = new Substrate.NetApi.Model.Meta.PalletEvents();
        //    //timestampPalletEvent.TypeId.Returns((uint)0);

        //    timestampPalletModule.Calls = timestampPalletCall;

        //    var dictionnaryModule = new Dictionary<uint, Substrate.NetApi.Model.Meta.PalletModule>
        //    {
        //        { 0, timestampPalletModule }
        //    };

        //    //_substrateRepository.Api.Returns(Substitute.For<ISubstrateClientRepository>());

        //    _substrateService.GetMetadataAsync(CancellationToken.None).NodeMetadata.Modules.Returns(dictionnaryModule);
        //    _substrateService.GetMetadataAsync(CancellationToken.None).Returns(new MetaData().)

        //    var timestampType = new NodeTypeVariant()
        //    {
        //        Path = new string[] { "pallet_timestamp", "pallet", "call" },
        //    };

        //    var dictionnaryType = new Dictionary<uint, NodeType>
        //    {
        //        { 0, timestampType }
        //    };
        //    _substrateService.GetMetadataAsync.NodeMetadata.Types.Returns(dictionnaryType);
        //    //var callBuilded = _palletBuilder.BuildCall("Timestamp", new Method(3, 0, new byte[] { 1 }));

        //    //var timestampSet = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_timestamp.pallet.EnumCall();

        //    //var value2 = new BaseCom<U64>();
        //    //value2.Value.Returns(new CompactInteger(1671349818016));

        //    //timestampSet.Value = Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_timestamp.pallet.Call.set;
        //    //timestampSet.Value2 = value2;

        //    //Assert.Equals(callBuilded, timestampSet);
        //}
    }
}
