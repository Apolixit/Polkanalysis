using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Runtime.Mapping;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Runtime;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Runtime.Module;

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
                Substitute.For<ISubstrateRepository>(),
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
