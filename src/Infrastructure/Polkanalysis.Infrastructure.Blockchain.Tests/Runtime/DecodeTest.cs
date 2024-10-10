using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime.Module;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime;
using Polkanalysis.Infrastructure.Blockchain.Runtime;

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
                Substitute.For<ILogger<SubstrateDecoding>>());
        }

        [Test]
        public void EmptyInput_ShouldThrowException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _decode.DecodeEventAsync(string.Empty, CancellationToken.None));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _decode.DecodeEventAsync("0x00", CancellationToken.None));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _decode.DecodeEventAsync("I am a bad input", CancellationToken.None));
        }

        [Test]
        public async Task EmptyType_ShouldHaveEmptyNode()
        {
            IType emptyType = new U32();
            var node = await _decode.DecodeAsync(emptyType, CancellationToken.None);

            Assert.That(node, Is.Not.Null);
            Assert.That(node.IsEmpty, Is.False);
        }

        //[Test]
        //[TestCase("0x000300000063000000CA9A3B0000000000")]
        //[TestCase("0x000200000000010305040000006287113400000000")]
        //[TestCase("0x000200000000010307070000000310CA435500000000")]
        //public void DecodeEvent_FromRealUseCaseDebugging_ShouldSucceed(string hex)
        //{
        //    EventRecord ev = new EventRecord();
        //    ev.Create(hex);

        //    Assert.That(ev, Is.Not.Null);

        //    var eventNode = _decode.DecodeEvent(ev);

        //    Assert.That(eventNode, Is.Not.Null);
        //    var module = eventNode.Module;
        //}
    }
}
