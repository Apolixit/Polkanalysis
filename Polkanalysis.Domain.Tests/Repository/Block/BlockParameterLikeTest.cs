using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
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

            //_blockParameterLike = new BlockParameterLike(_substrateService);
        }

        [Test]
        [TestCase(10)]
        public async Task FromNumber_WithValidBlockNumber_ShouldWorkAsync(int number)
        {
            var res = await new BlockParameterLike((uint)number).EnsureBlockNumberIsValidAsync(_substrateService);
            Assert.That(res, Is.True);
        }

        [Test]
        [TestCase(100)]
        [Description("Call a block number which has been produce yet. Should fail")]
        public async Task FromNumber_WithInvalidBlockNumber_ShouldFailAsync(int number)
        {
            _substrateService.Rpc.Chain.GetHeaderAsync().Returns(new Header()
            {
                Number = new Substrate.NetApi.Model.Types.Primitive.U64(50)
            });

            var isBlockValid = await new BlockParameterLike((uint)number).EnsureBlockNumberIsValidAsync(_substrateService);
            Assert.That(isBlockValid, Is.False);
        }

        /// <summary>
        /// No block number neither block hash set
        /// </summary>
        [Test]
        public void NoInputs_ShouldFail()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async () => await new BlockParameterLike(blockHash: null!).ToBlockHashAsync(_substrateService));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await new BlockParameterLike(blockHash: null!).ToBlockNumberAsync(_substrateService));
        }

        [Test]
        public async Task ToBlockHash_WithBlockNumberSet_ShouldWorkAsync()
        {
            _blockParameterLike = new BlockParameterLike(10);

            var blockHash = await _blockParameterLike.ToBlockHashAsync(_substrateService);
            Assert.That(blockHash.Bytes, Is.EqualTo(new Hash("0x00").Bytes));
        }

        [Test]
        public async Task ToBlockHash_WithBlockHashSet_ShouldReturnSelfAsync()
        {
            _blockParameterLike = new BlockParameterLike("0x00");

            var blockHash = await _blockParameterLike.ToBlockHashAsync(_substrateService);
            Assert.That(blockHash.Bytes, Is.EqualTo(new Hash("0x00").Bytes));
        }

        [Test]
        public async Task ToBlockHash_WithBlockError_ShouldFailAsync()
        {
            _blockParameterLike = new BlockParameterLike(10);

            _substrateService.Rpc.Chain.GetBlockHashAsync(Arg.Any<BlockNumber>(), Arg.Any<CancellationToken>()).ReturnsNull();

            Assert.ThrowsAsync<BlockException>(async () => await _blockParameterLike.ToBlockHashAsync(_substrateService));
        }
    }
}
