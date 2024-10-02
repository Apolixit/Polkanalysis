using Algolia.Search.Clients;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Service;
using Polkanalysis.Domain.Tests.Abstract;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Polkanalysis.Domain.Contracts.Dto.Search.SearchResultDto;

namespace Polkanalysis.Domain.Tests.Service
{
    public class SearchServiceTest : DomainTestAbstract
    {
        private ISearchService _searchService;
        private ISubstrateService _substrateService;

        [SetUp]
        public void Setup()
        {
            _substrateService = Substitute.For<ISubstrateService>();

            mockDb();
            _searchService = new SearchService(_substrateService,
                                               _substrateDbContext,
                                               Substitute.For<ICoreService>(),
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

        private void mockDb()
        {
            _substrateDbContext.BlockInformation.AddRange(
                [
                new Infrastructure.Database.Contracts.Model.Blocks.BlockInformationModel()
                {
                    BlockNumber = 10,
                    BlockDate = DateTime.Now,
                    BlockHash = "0x4dd66ad0f33bfc8160508219bcb208aac75d3b13ae8fbea11c0d61aa9b0cfaf3",
                    ValidatorAddress = Alice.ToString(),
                    BlockchainName = "Polkadot",
                    EventsCount = 1,
                    ExtrinsicsCount = 1,
                    LogsCount = 1
                },
                new Infrastructure.Database.Contracts.Model.Blocks.BlockInformationModel()
                {
                    BlockNumber = 20,
                    BlockDate = DateTime.Now,
                    BlockHash = "0x4dd66ad0f33bfc8160508219bcb208aac75d3b13ae8fbea11c0d61aa9b0cfaf4",
                    ValidatorAddress = Bob.ToString(),
                    BlockchainName = "Polkadot",
                    EventsCount = 1,
                    ExtrinsicsCount = 1,
                    LogsCount = 1
                }
                ]
            );
            _substrateDbContext.SaveChanges();
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

        [Test]
        public async Task SearchAsync_WithValidBlockNumber_ShouldSucceedAsync()
        {
            var searchResult = await _searchService.SearchAsync("10", CancellationToken.None);

            Assert.That(searchResult, Is.Not.Null);

            var searchResultList = searchResult.ToList();
            Assert.That(searchResultList.Count, Is.EqualTo(1));
            Assert.That(searchResultList[0].ResultType, Is.EqualTo(SearchResultType.BlockNumber));
        }

        [Test]
        public async Task SearchAsync_WithValidBlockHash_ShouldSucceedAsync()
        {
            var searchResult = await _searchService.SearchAsync("0x4dd66ad0f33bfc8160508219bcb208aac75d3b13ae8fbea11c0d61aa9b0cfaf4", CancellationToken.None);

            var searchResultList = searchResult.ToList();
            Assert.That(searchResultList.Count, Is.EqualTo(1));
            Assert.That(searchResultList[0].ResultType, Is.EqualTo(SearchResultType.BlockHash));
        }

        [Test]
        public async Task SearchAsync_WithValidAccount_ShouldSucceedAsync()
        {
            _substrateService.Storage.System.AccountAsync(new SubstrateAccount(Alice.ToString()), CancellationToken.None).Returns(new Infrastructure.Blockchain.Contracts.Pallet.System.AccountInfo()
            {
            });

            var searchResult = await _searchService.SearchAsync(Alice.ToString(), CancellationToken.None);

            var searchResultList = searchResult.ToList();
            Assert.That(searchResultList.Count, Is.EqualTo(1));
            Assert.That(searchResultList[0].ResultType, Is.EqualTo(expected: SearchResultType.SubstrateAddress));
        }
    }
}
