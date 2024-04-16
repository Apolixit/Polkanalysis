using NSubstitute;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.Service.Block
{
    internal class ExplorerTimeTests : ExplorerServiceTests
    {
        [SetUp]
        public void Start()
        {
            
        }

        [Test]
        public async Task GetDateTimeFromTimestampAsync_WithNullInput_ShouldReturnNowDateAsync()
        {
            _substrateService.Storage.Timestamp.NowAsync(CancellationToken.None).Returns(new U64(0));

            var res1 = await _explorerRepository.GetDateTimeFromTimestampAsync(blockHash: null, CancellationToken.None);
            var res2 = await _explorerRepository.GetDateTimeFromTimestampAsync(blockNum: null, CancellationToken.None);

            var expectedDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            Assert.That(res1, Is.EqualTo(expectedDate));
            Assert.That(res2, Is.EqualTo(expectedDate));
        }

        [Test]
        public async Task GetDateTimeFromTimestampAsync_WithNonNullBlockHash_ShouldReturnPastStorageDateTimeAsync()
        {
            ulong nbTickInOneYear = 366 * 60 * 60 * 24 * (ulong)Math.Pow(10, 7);

            _substrateService.At(Arg.Any<Hash>()).Storage.Timestamp.NowAsync(CancellationToken.None).Returns(new U64(nbTickInOneYear));

            var res1 = await _explorerRepository.GetDateTimeFromTimestampAsync(blockHash: null, CancellationToken.None);
            var res2 = await _explorerRepository.GetDateTimeFromTimestampAsync(blockNum: null, CancellationToken.None);

            var expectedDate = new DateTime(1971, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            Assert.That(res1, Is.EqualTo(expectedDate));
            Assert.That(res2, Is.EqualTo(expectedDate));
        }
    }
}
