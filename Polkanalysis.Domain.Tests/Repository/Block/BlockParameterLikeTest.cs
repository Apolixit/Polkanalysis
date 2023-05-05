using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Polkanalysis.Domain.Adapter.Block;
using Polkanalysis.Domain.Contracts.Exception;
using Polkanalysis.Domain.Contracts.Secondary;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.Repository.Block
{
    public class BlockParameterLikeTest
    {
        private readonly ISubstrateRepository _substrateService;
        public BlockParameterLike _blockParameterLike;

        public BlockParameterLikeTest()
        {
            _substrateService = Substitute.For<ISubstrateRepository>();
        }

        [SetUp]
        public void Setup()
        {
            _substrateService.Rpc.Chain.GetHeaderAsync().Returns(new Header()
            {
                Number = new Substrate.NetApi.Model.Types.Primitive.U64(20)
            });

            _substrateService.Rpc.Chain.GetBlockHashAsync(Arg.Any<BlockNumber>(), Arg.Any<CancellationToken>()).Returns(
                new Hash("0x00"));

            _blockParameterLike = new BlockParameterLike(_substrateService);
        }

        [Test]
        [TestCase(10)]
        public async Task FromNumber_WithValidBlockNumber_ShouldWorkAsync(int number)
        {
            var res = await _blockParameterLike.FromBlockNumberAsync((uint)number);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [TestCase(100)]
        public void FromNumber_WithInvalidBlockNumber_ShouldFail(int number)
        {
            _substrateService.Rpc.Chain.GetHeaderAsync().Returns(new Header()
            {
                Number = new Substrate.NetApi.Model.Types.Primitive.U64(50)
            });

            Assert.ThrowsAsync<BlockException>(async () => await _blockParameterLike.FromBlockNumberAsync((uint)number));
        }

        /// <summary>
        /// No block number neither block hash set
        /// </summary>
        [Test]
        public void NoInputs_ShouldFail()
        {
            Assert.ThrowsAsync<InvalidOperationException>(_blockParameterLike.ToBlockHashAsync);
            Assert.ThrowsAsync<InvalidOperationException>(_blockParameterLike.ToBlockNumberAsync);
        }

        [Test]
        public async Task ToBlockHash_WithBlockNumberSet_ShouldWorkAsync()
        {
            _blockParameterLike = await _blockParameterLike.FromBlockNumberAsync(10);
            Assert.That(await _blockParameterLike.ToBlockHashAsync(), Is.EqualTo(new Hash("0x00")));
        }

        [Test]
        public async Task ToBlockHash_WithBlockHashSet_ShouldReturnSelfAsync()
        {
            _blockParameterLike = _blockParameterLike.FromBlockHash("0x00");
            Assert.That(await _blockParameterLike.ToBlockHashAsync(), Is.EqualTo(new Hash("0x00")));
        }

        [Test]
        public async Task ToBlockHash_WithBlockError_ShouldFailAsync()
        {
            _blockParameterLike = await _blockParameterLike.FromBlockNumberAsync(10);

            _substrateService.Rpc.Chain.GetBlockHashAsync(Arg.Any<BlockNumber>(), Arg.Any<CancellationToken>()).ReturnsNull();

            Assert.ThrowsAsync<BlockException>(_blockParameterLike.ToBlockHashAsync);
        }
    }
}
