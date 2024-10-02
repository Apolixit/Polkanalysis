using Algolia.Search.Clients;
using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Dto.Search;
using Polkanalysis.Domain.Contracts.Dto.Staking.Pool;
using Polkanalysis.Domain.Contracts.Primary.Search.SearchData;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database;
using Substrate.NET.Utils;
using Substrate.NET.Utils.Address;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Service
{
    public class SearchService : ISearchService
    {
        private readonly ISubstrateService _substrateService;
        private readonly ICoreService _coreService;
        private readonly SubstrateDbContext _db;
        private readonly ILogger<SearchService> _logger;

        public SearchService(ISubstrateService _substrateService, SubstrateDbContext db, ICoreService coreService,/* ISearchClient searchClient,*/ ILogger<SearchService> logger)
        {
            this._substrateService = _substrateService;
            _db = db;
            _coreService = coreService;
            _logger = logger;
        }

        

        /// <summary>
        /// Try to define what kind of query it is
        /// </summary>
        /// <param name="query"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SearchType>> TryDefineSearchTypeAsync(string query, CancellationToken token)
        {
            Guard.Against.NullOrEmpty(query, nameof(query));

            var searchTypes = new List<SearchType>();

            uint queryBlock;
            if (uint.TryParse(query, out queryBlock))
            {
                var blockHeader = await _substrateService.Rpc.Chain.GetHeaderAsync(token);

                if (blockHeader.Number.Value >= queryBlock)
                    searchTypes.Add(SearchType.BlockNumber);
            }

            if (SubstrateCheck.CheckHash(query))
            {
                searchTypes.Add(SearchType.BlockHash);
            }
            
            if (AddressExtension.IsValidAccountAddress(query) || AddressExtension.IsValidPublicKey(query))
            {
                searchTypes.Add(SearchType.Account);
            }

            return searchTypes;
        }

        public async Task<IEnumerable<SearchResultDto>> SearchAsync(string query, CancellationToken token)
        {
            var searchResult = new List<SearchResultDto>();
            var searchTypes = await TryDefineSearchTypeAsync(query, token);

            if (searchTypes.Any(x => x == SearchType.BlockNumber))
            {
                var blockNum = await SearchBlockByNumberAsync(uint.Parse(query), token);
                if (blockNum is not null)
                    searchResult.Add(blockNum);
            }
            else if (searchTypes.Any(x => x == SearchType.BlockHash))
            {
                var blockHash = await SearchBlockByHashAsync(query, token);
                if (blockHash is not null)
                    searchResult.Add(blockHash);
            }
            else if (searchTypes.Any(x => x == SearchType.Account))
            {
                var account = await SearchAccountAsync(query, token);
                if (account is not null)
                    searchResult.Add(account);
            }

            return searchResult;
        }

        #region Search into Infrastructure
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        private async Task<SearchResultDto?> SearchAccountAsync(string query, CancellationToken token)
        {
            var account = new SubstrateAccount(query);
            var res = await _substrateService.Storage.System.AccountAsync(account, token);
            //var res = await _db.EventSystemNewAccount.FirstOrDefaultAsync(x => x.AccountAddress.ToLower() == query.ToLower(), token);

            string description = "";
            if (res is not null)
            {
                description = $"Account {query} exists on {_substrateService.BlockchainName}";

                return new SearchResultDto()
                {
                    ResultType = SearchResultDto.SearchResultType.SubstrateAddress,
                    When = DateTime.Now,
                    Url = $"account/{query}",
                    Description = description
                };
            }

            // Is the account destroyed ?
            var destroyed = await _db.EventSystemKilledAccount.FirstOrDefaultAsync(x => x.AccountAddress.Equals(query, StringComparison.CurrentCultureIgnoreCase), token);

            if (destroyed is not null)
            {
                description += $" Account has been destroyed on block {destroyed.BlockDate}";
                return new SearchResultDto()
                {
                    ResultType = SearchResultDto.SearchResultType.SubstrateAddress,
                    When = DateTime.Now,
                    Url = $"account/{query}",
                    Description = description
                };
            }

            return null;
        }

        /// <summary>
        /// Search block hash into the database
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        private async Task<SearchResultDto?> SearchBlockByHashAsync(string hash, CancellationToken token)
        {
            var res = _db.BlockInformation.FirstOrDefault(x => x.BlockHash.ToLower() == hash.ToLower());
            if (res is null)
                return null;

            return new SearchResultDto()
            {
                ResultType = SearchResultDto.SearchResultType.BlockHash,
                When = await _coreService.GetDateTimeFromTimestampAsync(new Hash(hash), token),
                Url = $"block/{res.BlockNumber}",
                Description = $"This is the hash of the block number {res.BlockNumber}"
            };
        }

        /// <summary>
        /// Search block number into the database
        /// </summary>
        /// <param name="query"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        private async Task<SearchResultDto?> SearchBlockByNumberAsync(uint blockNum, CancellationToken token)
        {
            var res = _db.BlockInformation.FirstOrDefault(x => x.BlockNumber == blockNum);

            if (res is null)
                return null;

            return new SearchResultDto()
            {
                ResultType = SearchResultDto.SearchResultType.BlockNumber,
                When = await _coreService.GetDateTimeFromTimestampAsync(new Hash(res.BlockHash), token),
                Url = $"block/{res.BlockNumber}",
                Description = $"This is the block number {res.BlockNumber}"
            };
        }
        #endregion

        #region Search into Algolia
        //private async Task PoolSearchIndexorAsync(string query, CancellationToken token)
        //{
        //    SearchIndex poolName = _searchClient.InitIndex("poolName");
        //    var poolResult = await poolName.SearchAsync<PoolSearchData>(new Algolia.Search.Models.Search.Query(query), ct: token);
        //}

        /// <summary>
        /// Insert Pool data into the indexor
        /// </summary>
        /// <param name="poolLight"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        //private async Task PoolInsertIndexorAsync(IEnumerable<PoolLightDto> poolsLight, CancellationToken token)
        //{
        //    SearchIndex poolName = _searchClient.InitIndex("poolName");

        //    await poolName.SaveObjectsAsync(
        //        poolsLight.Select(poolLight => new PoolSearchData(poolLight.PoolId, poolLight.Name, poolLight.Status)), ct: token);
        //}
        #endregion
    }
}
