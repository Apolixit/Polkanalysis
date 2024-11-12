using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Service;
using Polkanalysis.Domain.Tests.Abstract;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
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
    internal class CoreServiceTests : DomainTestAbstract
    {
        protected ICoreService _coreService;
        protected ISubstrateService _substrateService;

        [SetUp]
        public void Start()
        {
            _substrateService = Substitute.For<ISubstrateService>();
            _coreService = new CoreService(_substrateService, Substitute.For<ILogger<CoreService>>());
        }

        [Test]
        public async Task GetDateTimeFromTimestampAsync_WithNullInput_ShouldReturnNowDateAsync()
        {
            _substrateService.Storage.Timestamp.NowAsync(CancellationToken.None).Returns(new U64(0));

            var res1 = await _coreService.GetDateTimeFromTimestampAsync(blockHash: null, CancellationToken.None);
            var res2 = await _coreService.GetDateTimeFromTimestampAsync(blockNum: null, CancellationToken.None);

            var expectedDate = DateTime.UnixEpoch;
            Assert.That(res1, Is.EqualTo(expectedDate));
            Assert.That(res2, Is.EqualTo(expectedDate));
        }

        [Test]
        public async Task GetDateTimeFromTimestampAsync_WithNonNullBlockHash_ShouldReturnPastStorageDateTimeAsync()
        {
            ulong nbTickInOneYear = 365 * 60 * 60 * 24 * (ulong)Math.Pow(10, 3);

            _substrateService.Storage.Timestamp.NowAsync(CancellationToken.None).Returns(new U64(nbTickInOneYear));

            var res1 = await _coreService.GetDateTimeFromTimestampAsync(blockHash: null, CancellationToken.None);
            var res2 = await _coreService.GetDateTimeFromTimestampAsync(blockNum: null, CancellationToken.None);

            var expectedDate = new DateTime(1971, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            Assert.That(res1, Is.EqualTo(expectedDate));
            Assert.That(res2, Is.EqualTo(expectedDate));
        }
    }
}
