using Algolia.Search.Clients;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Service;
using Polkanalysis.Domain.Tests.Abstract;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.Service
{
    public class SearchServiceTest : DomainTestAbstract
    {
        private ISearchService _searchService;
        private ISubstrateService _substrateService;

        public SearchServiceTest()
        {
            _substrateService = Substitute.For<ISubstrateService>();

            _searchService = new SearchService(_substrateService,
                                               _substrateDbContext,
                                               Substitute.For<IExplorerService>(),
                                               //Substitute.For<ISearchClient>(),
                                               Substitute.For<ILogger<SearchService>>());

            var mockHash = new Hash("0x4dd66ad0f33bfc8160508219bcb208aac75d3b13ae8fbea11c0d61aa9b0cfaf3");
            _substrateService.Rpc.Chain.GetBlockHashAsync(new BlockNumber(21318590), CancellationToken.None).Returns(mockHash);
            _substrateService.Rpc.Chain.GetHeaderAsync(mockHash, CancellationToken.None).Returns(new Header()
            {
                Number = new Substrate.NetApi.Model.Types.Primitive.U64(21318591)
            });

            _substrateService.Rpc.Chain.GetHeaderAsync(CancellationToken.None).Returns(new Header()
            {
                Number = new Substrate.NetApi.Model.Types.Primitive.U64(21318591)
            });
        }

        [Test]
        public async Task TryDefineSearchType_WithValidBlockNumber_ShouldReturnBlockNumberTypeAsync()
        {
            var searchType = await _searchService.TryDefineSearchTypeAsync("21318590", CancellationToken.None);

            Assert.That(searchType, Is.Not.Null);
            Assert.That(searchType.Any(x => x == SearchType.BlockNumber), Is.True);
        }

        [Test]
        public async Task TryDefineSearchType_WithInValidBlockNumber_ShouldNotReturnBlockNumberTypeAsync()
        {
            var searchType = await _searchService.TryDefineSearchTypeAsync("21318592", CancellationToken.None);

            Assert.That(searchType, Is.Not.Null);
            Assert.That(searchType.Any(x => x == SearchType.BlockNumber), Is.False);
        }

        [Test]
        public async Task TryDefineSearchType_WithValidHash_ShouldNotReturnBlockHashTypeAsync()
        {
            var searchType = await _searchService.TryDefineSearchTypeAsync("0x4dd66ad0f33bfc8160508219bcb208aac75d3b13ae8fbea11c0d61aa9b0cfaf3", CancellationToken.None);

            Assert.That(searchType, Is.Not.Null);
            Assert.That(searchType.Any(x => x == SearchType.BlockHash), Is.True);
        }

        [Test]
        [TestCase("16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS")]
        [TestCase("J9hZnYNyhYrQxatHARFvWeDoSThsA6KUMymqK2P6R7Q1hSE")]
        [TestCase("5He5uUCWMLXvfJmSWTcD2ZHDerBU4VH91z92SekRcctuGifV")]
        public async Task TryDefineSearchType_WithValidHash_ShouldNotReturnBlockHashTypeAsync(string accountAddress)
        {
            var searchType = await _searchService.TryDefineSearchTypeAsync(accountAddress, CancellationToken.None);

            Assert.That(searchType, Is.Not.Null);
            Assert.That(searchType.Count(), Is.EqualTo(1));
            Assert.That(searchType.Any(x => x == SearchType.Account), Is.True);
        }

        [Test]
        [TestCase("0xf6a27c9d9868b21ffd9f5220fe90872336419ff32c21adbbd42232923ee0f301")]
        public async Task TryDefineSearchType_WithValidPublicKey_ShouldNotReturnAccountTypeAsync(string accountAddress)
        {
            var searchType = await _searchService.TryDefineSearchTypeAsync(accountAddress, CancellationToken.None);

            Assert.That(searchType, Is.Not.Null);
            Assert.That(searchType.Count(), Is.EqualTo(2));
            Assert.That(searchType.Any(x => x == SearchType.BlockHash), Is.True);
            Assert.That(searchType.Any(x => x == SearchType.Account), Is.True);
        }
    }
}
