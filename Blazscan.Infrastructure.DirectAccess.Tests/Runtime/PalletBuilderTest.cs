using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Meta;
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

            //var mockClient = new SubstrateClientExt(default, default);
            var mockClient = Substitute.For<SubstrateClientExt>(default, default);
            //mockClient.IsConnected.Returns(true);
            //mockClient.ConnectAsync().ReturnsForAnyArgs(Task.CompletedTask);
            //mockClient.MetaData.Returns(Substitute.For<IMetaData>());

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
    }
}
