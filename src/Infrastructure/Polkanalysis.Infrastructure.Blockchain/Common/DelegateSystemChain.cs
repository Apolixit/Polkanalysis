using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
using Polkanalysis.Infrastructure.Blockchain.Exceptions;
using Polkanalysis.Infrastructure.Database;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Infrastructure.Blockchain.Common
{
    public class DelegateSystemChain : IDelegateSystemChain
    {
        private readonly ISubstrateService _substrateService;
        private readonly SubstrateDbContext _db;
        protected readonly ILogger<DelegateSystemChain> _logger;

        public DelegateSystemChain(ISubstrateService substrateService, SubstrateDbContext db, ILogger<DelegateSystemChain> logger)
        {
            _substrateService = substrateService;
            _db = db;
            _logger = logger;
        }

        /// <summary>
        /// Get the associated hash from an other chain
        /// </summary>
        /// <param name="systemChainClient"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<Hash> GetAssociatedHashFromOtherChainAsync(SubstrateClient systemChainClient, string systemChainName, uint blockNumber, CancellationToken token)
        {
            try
            {
                var peopleChainBlockHash = await systemChainClient.Chain.GetBlockHashAsync(new BlockNumber(blockNumber), token);

                return peopleChainBlockHash;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[{systemChainName}] Unable to get hash from blocknumber {blockNumber}");
                throw new InvalidDataFromSystemParachainException($"[{systemChainName}] Unable to get hash from blocknumber {blockNumber}", blockNumber);
            }
        }

        /// <summary>
        /// For a given block, try to determine if the System chain exists and if true, return its block number
        /// First we try to get the block number from the database
        /// If not found, we try to get it by approximation using the pallet timestamp
        /// </summary>
        /// <param name="systemChainClient">A SystemParachain (https://wiki.polkadot.network/docs/learn-system-chains)</param>
        /// <param name="token"></param>
        /// <returns>0 if the SystemParachain does not exists, otherwise return its blocknumber</returns>
        public async Task<uint> CurrentBlockForSystemChainAsync(SubstrateClient systemChainClient, string systemChainName, string sourceChainBlockHash, CancellationToken token)
        {
            // Todo Romain, return a class
            Guard.Against.NullOrEmpty(sourceChainBlockHash, nameof(sourceChainBlockHash));
            Guard.Against.NullOrEmpty(systemChainName, nameof(systemChainName));

            // Thips is bad, I need to change this asap by calling Babe & Aura
            var sourceBlockTime = getBlocktimeFromBlockchainName(_substrateService.BlockchainName);
            var systemChainBlockTime = getBlocktimeFromBlockchainName(systemChainName);

            var polkadotCurrentDate = await GetDateTimeFromTimestampAsync(_substrateService.AjunaClient, sourceChainBlockHash, token);
            var systemChainBlockNumber = await getBlockNumberFromDateTimeAsync(polkadotCurrentDate, systemChainName, token);

            if (systemChainBlockNumber is not null)
                return systemChainBlockNumber.Value;

            var polkadotBlockDataTask = _substrateService.AjunaClient.Chain.GetBlockAsync(new Hash(sourceChainBlockHash), token);
            var polkadotCurrentBlockNumTask = _substrateService.AjunaClient.Chain.GetBlockAsync(token);
            var systemChainCurrentBlockNumTask = systemChainClient.Chain.GetBlockAsync(token);
            var tasks = new List<Task>()
            {
                polkadotBlockDataTask, polkadotCurrentBlockNumTask, systemChainCurrentBlockNumTask
            };

            await Task.WhenAll(tasks.ToArray());

            var polkadotBlockData = await polkadotBlockDataTask;
            var polkadotCurrentBlockNum = await polkadotCurrentBlockNumTask;
            var systemChainCurrentBlockNum = await systemChainCurrentBlockNumTask;

            Guard.Against.Null(polkadotBlockData, nameof(polkadotBlockData), message: $"Unable to get block data from [{_substrateService.BlockchainName}]_client.Chain.GetBlockAsync({sourceChainBlockHash})");
            Guard.Against.Null(polkadotCurrentBlockNum, nameof(polkadotCurrentBlockNum), message: $"Unable to get current block number from [{_substrateService.BlockchainName}]_client.Chain.GetBlockAsync({sourceChainBlockHash})");
            Guard.Against.Null(systemChainCurrentBlockNum, nameof(systemChainCurrentBlockNum), message: $"Unable to get current block number from [{systemChainName}]");

            // This is not good and just aproximative, need to change
            var deltaBlock = (sourceBlockTime / systemChainBlockTime) * polkadotCurrentBlockNum.Block.Header.Number.Value - polkadotBlockData.Block.Header.Number.Value;
            var approxBlockFromSystemChain = (int)systemChainCurrentBlockNum.Block.Header.Number.Value - (int)deltaBlock;
            // If system chain does not exists => return 0
            //if (deltaBlock > systemChainCurrentBlockNum.Block.Header.Number.Value) return 0;

            var blockFromSystemChain = await FindClosestBlockInSystemChainAsync(
                (uint)polkadotCurrentBlockNum.Block.Header.Number.Value,
                approxBlockFromSystemChain,
                systemChainClient, token);
            return blockFromSystemChain;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceBlockNumber">The block number in the "source" chain</param>
        /// <param name="approxBlockSystemChain">The approximative block number of the target chain</param>
        /// <param name="systemChainClient">The client of the target chain</param>
        /// <param name="token"></param>
        /// <returns>The closest block of the system chain that fit the source blocknumber</returns>
        internal async Task<uint> FindClosestBlockInSystemChainAsync(uint sourceBlockNumber, int approxBlockSystemChain, SubstrateClient systemChainClient, CancellationToken token)
        {
            uint approxBlockSystemChainPositive = (uint)Math.Max(1, approxBlockSystemChain);

            var sourceBlockHash = await systemChainClient.Chain.GetBlockHashAsync(new BlockNumber(sourceBlockNumber), token);
            DateTime targetTimestamp = await GetDateTimeFromTimestampAsync(_substrateService.AjunaClient, sourceBlockHash?.Value, token);

            // Limit the search range around the approximate block (e.g., ±100 blocks)
            uint minBlock = approxBlockSystemChainPositive - 100;
            uint maxBlock = approxBlockSystemChainPositive + 100;

            // Initialize binary search to find the closest time-matching block in SystemParachain that is <= targetTimestamp
            uint closestBlock = approxBlockSystemChainPositive;
            TimeSpan smallestDifference = TimeSpan.MaxValue;

            while (minBlock <= maxBlock)
            {
                uint midBlock = Math.Max(1, (minBlock + maxBlock) / 2);
                var midBlockHash = await systemChainClient.Chain.GetBlockHashAsync(new BlockNumber(midBlock), token);
                DateTime midTimestamp = await GetDateTimeFromTimestampAsync(_substrateService.AjunaClient, midBlockHash?.Value, token);

                // Only consider midBlock if its timestamp is <= targetTimestamp
                if (midTimestamp <= targetTimestamp)
                {
                    TimeSpan difference = targetTimestamp - midTimestamp;

                    // Update if this difference is smaller than the current smallest difference
                    if (difference < smallestDifference)
                    {
                        smallestDifference = difference;
                        closestBlock = midBlock;
                    }

                    // Move the search range up, as we're looking for a closer timestamp, if possible
                    minBlock = midBlock + 1;
                }
                else
                {
                    // If midTimestamp > targetTimestamp, search in the lower range
                    maxBlock = midBlock - 1;
                }
            }

            return closestBlock;
        }

        /// <summary>
        /// Get the most recent block from a system chain that is the closest to the reference date
        /// </summary>
        /// <param name="referenceDate"></param>
        /// <param name="systemChainName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        protected async Task<uint?> getBlockNumberFromDateTimeAsync(DateTime referenceDate, string systemChainName, CancellationToken token)
        {
            var blockTimeSystemChain = getBlocktimeFromBlockchainName(systemChainName);

            DateTime lowerBound = referenceDate.AddSeconds(-blockTimeSystemChain * 2);

            var block = await _db
                .BlockInformation
                .AsNoTracking()
                .Where(x => x.BlockchainName == systemChainName && x.BlockDate <= referenceDate && x.BlockDate >= lowerBound)
                .OrderByDescending(x => x.BlockDate)
                .FirstOrDefaultAsync(token);

            return block?.BlockNumber;
        }

        public async Task<DateTime> GetDateTimeFromTimestampAsync(SubstrateClient client, string? blockHash, CancellationToken cancellationToken)
        {
            string parameters = RequestGenerator.GetStorage("Timestamp", "Now", type: 0, hashers: null, keys: null);
            var currentTimestamp = await client.GetStorageAsync<U64>(parameters, blockHash, cancellationToken);

            var dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(currentTimestamp.Value);

            return dt;
        }

        /// <summary>
        /// Todo : remove it when time to refacto
        /// </summary>
        /// <returns></returns>
        protected static uint getBlocktimeFromBlockchainName(string name)
        {
            return name switch
            {
                "Polkadot" => 6_000,
                "PeopleChain" => 12_000,
                _ => throw new NotSupportedException($"Unable to get blocktime from {name}")
            };
        }
    }
}
