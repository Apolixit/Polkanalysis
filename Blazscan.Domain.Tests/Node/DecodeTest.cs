using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Primitive;
using Blazscan.Domain.Contracts.Runtime;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.SubstrateDecode.Test.Node
{
    public class DecodeTest
    {
        private readonly ISubstrateDecoding _decode;

        public DecodeTest()
        {
            _decode = Substitute.For<ISubstrateDecoding>();
        }

        [Test]
        public void EmptyInput_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => _decode.DecodeEvent(string.Empty));
            Assert.Throws<ArgumentNullException>(() => _decode.DecodeEvent("I am a bad input"));
        }

        [Test]
        public void EmptyType_ShouldHaveEmptyNode()
        {
            IType emptyType = new U32();
            var node = _decode.DecodeEvent(emptyType);

            Assert.That(node, Is.Not.Null);
            Assert.True(node.IsEmpty);
        }
    }
}
