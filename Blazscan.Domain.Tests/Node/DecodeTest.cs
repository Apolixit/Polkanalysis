using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Primitive;
using Blazscan.Domain.Contracts.Repository;
using Blazscan.Domain.Contracts.Runtime;
using Blazscan.Domain.Contracts.Runtime.Mapping;
using Blazscan.Domain.Runtime;
using Microsoft.Extensions.Logging;
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
        private ISubstrateDecoding _decode;

        [SetUp]
        public void Setup()
        {
            _decode = new SubstrateDecoding(
                new EventMapping(),
                Substitute.For<ISubstrateNodeRepository>(),
                Substitute.For<IPalletBuilder>(),
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
            var node = _decode.DecodeEvent(emptyType);

            Assert.That(node, Is.Not.Null);
            Assert.False(node.IsEmpty);
        }
    }
}
