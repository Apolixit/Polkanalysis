using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Runtime;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using Polkanalysis.Infrastructure.Blockchain.Contracts;

namespace Polkanalysis.SubstrateDecode.Test.Node
{
    public class DecodeTest
    {
        private ISubstrateDecoding _decode;

        [SetUp]
        public void Setup()
        {
            _decode = new SubstrateDecoding(
                new EventNodeMapping(),
                Substitute.For<ISubstrateService>(),
                Substitute.For<IPalletBuilder>(),
                Substitute.For<ICurrentMetaData>(),
                Substitute.For<ILogger<SubstrateDecoding>>());
        }

        [Test]
        public void EmptyInput_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => _decode.DecodeEvent(string.Empty));
            Assert.Throws<InvalidOperationException>(() => _decode.DecodeEvent("0x00"));
            Assert.Throws<InvalidOperationException>(() => _decode.DecodeEvent("I am a bad input"));
        }

        [Test]
        public void EmptyType_ShouldHaveEmptyNode()
        {
            IType emptyType = new U32();
            var node = _decode.Decode(emptyType);

            Assert.That(node, Is.Not.Null);
            Assert.False(node.IsEmpty);
        }
    }
}
