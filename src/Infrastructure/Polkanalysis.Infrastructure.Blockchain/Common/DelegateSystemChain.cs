using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
using Polkanalysis.Infrastructure.Blockchain.Exceptions;
using Polkanalysis.Infrastructure.Database;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Blocks;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Infrastructure.Blockchain.Common
{
    /// <summary>
    /// Get data associated to the System Parachain, especially the block number & the hash
    /// </summary>
    public class DelegateSystemChain : IDelegateSystemChain
    {
        private readonly ISubstrateService _substrateService;
        private readonly SubstrateDbContext _db;
        protected readonly ILogger<DelegateSystemChain> _logger;

        // Lock to avoid concurrency issue
        private static readonly object lockDatabase = new object();

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

                if(peopleChainBlockHash is null)
                    throw new InvalidDataFromSystemParachainException($"[{systemChainName}] Unable to get hash from blocknumber {blockNumber}", blockNumber);

                return peopleChainBlockHash;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[{systemChainName}] Unable to get hash from blocknumber {blockNumber}", systemChainName, blockNumber);
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
            Guard.Against.NullOrEmpty(sourceChainBlockHash);
            Guard.Against.NullOrEmpty(systemChainName);

            // Thips is bad, I need to change this asap by calling Babe & Aura
            var sourceBlockTime = getBlocktimeFromBlockchainName(_substrateService.BlockchainName);
            var systemChainBlockTime = getBlocktimeFromBlockchainName(systemChainName);

            var sourceCurrentDate = await GetDateTimeFromTimestampAsync(_substrateService.AjunaClient, sourceChainBlockHash, token);
            var systemChainBlockNumberFromDatabase = getBlockNumberFromDateTime(sourceCurrentDate, systemChainName, token);

            if (systemChainBlockNumberFromDatabase is not null)
                return systemChainBlockNumberFromDatabase.Value;

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

            Guard.Against.Null(polkadotBlockData, message: $"Unable to get block data from [{_substrateService.BlockchainName}]_client.Chain.GetBlockAsync({sourceChainBlockHash})");
            Guard.Against.Null(polkadotCurrentBlockNum, message: $"Unable to get current block number from [{_substrateService.BlockchainName}]_client.Chain.GetBlockAsync({sourceChainBlockHash})");
            Guard.Against.Null(systemChainCurrentBlockNum, message: $"Unable to get current block number from [{systemChainName}]");

            var polkadotNumFromHash = polkadotBlockData.Block.Header.Number.Value;
            var polkadotCurrentNum = polkadotCurrentBlockNum.Block.Header.Number.Value;
            var peopleChainCurrentNum = systemChainCurrentBlockNum.Block.Header.Number.Value;

            var deltaBlock = (double)((double)sourceBlockTime / (double)systemChainBlockTime) * (polkadotCurrentNum - polkadotNumFromHash);
            var approxBlockFromSystemChain = (int)peopleChainCurrentNum - (int)deltaBlock;

            var blockFromSystemChain = await TryFindClosestBlockInSystemChainAsync(
                sourceCurrentDate,
                approxBlockFromSystemChain,
                systemChainClient,
                systemChainBlockTime,
                token);

            if (blockFromSystemChain is null)
                throw new InvalidDataFromSystemParachainException($"Unable to determine block at the same time from {_substrateService.BlockchainName} (block {polkadotBlockData.Block.Header.Number.Value} / Date = {sourceCurrentDate}) to SystemParachain {systemChainName}", (uint)polkadotBlockData.Block.Header.Number.Value);

            return blockFromSystemChain.Value;
        }

        /// <summary>
        /// Iterate on the timestamp of the chain to determine the block number that is the closest to the source block number
        /// </summary>
        /// <param name="sourceBlockNumber">The block number in the "source" chain</param>
        /// <param name="approxBlockSystemChain">The approximative block number of the target chain</param>
        /// <param name="systemChainClient">The client of the target chain</param>
        /// <param name="token"></param>
        /// <returns>The closest block of the system chain that fit the source blocknumber</returns>
        internal async Task<uint?> TryFindClosestBlockInSystemChainAsync(
            DateTime sourceTargetDate, 
            int approxBlockSystemChain, 
            SubstrateClient systemChainClient, 
            uint systemChainBlockTime,
            CancellationToken token)
        {
            int maxIteration = 10;
            int currentIteration = 0;

            int currentBlock = approxBlockSystemChain;
            while (currentIteration < maxIteration)
            {
                currentBlock = Math.Max(1, currentBlock);
                var midBlockHash = await systemChainClient.Chain.GetBlockHashAsync(new BlockNumber((uint)currentBlock), token);
                DateTime midTimestamp = await GetDateTimeFromTimestampAsync(systemChainClient, midBlockHash?.Value, token);

                // If the SystemParachain didn't exists at this date, let's quit
                if (currentBlock == 1 && midTimestamp > sourceTargetDate)
                    throw new SystemParachainDidntExistYetException($"SystemParachain didn't exist at {sourceTargetDate}");

                TimeSpan difference = sourceTargetDate - midTimestamp;
                var isBeforeTargetDate = difference.TotalMilliseconds >= 0;

                if (isBeforeTargetDate && difference.TotalMilliseconds <= systemChainBlockTime)
                    return (uint)currentBlock; // This is not absolutely valid, but let's try

                var nbBlockToShift = (int)Math.Floor((double)difference.TotalMilliseconds / (double)systemChainBlockTime);
                currentBlock += nbBlockToShift;

                currentIteration++;
            }

            return null;
        }

        /// <summary>
        /// Get the most recent block from a system chain that is the closest to the reference date
        /// </summary>
        /// <param name="referenceDate"></param>
        /// <param name="systemChainName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        protected uint? getBlockNumberFromDateTime(DateTime referenceDate, string systemChainName, CancellationToken token)
        {
            var blockTimeSystemChain = getBlocktimeFromBlockchainName(systemChainName);

            DateTime lowerBound = referenceDate.AddSeconds(-blockTimeSystemChain * 2);

            BlockInformationModel? block = null;
            lock (lockDatabase)
            {
                block = _db
                .BlockInformation
                .AsNoTracking()
                .Where(x => x.BlockchainName == systemChainName && x.BlockDate <= referenceDate && x.BlockDate >= lowerBound)
                .OrderByDescending(x => x.BlockDate)
                .FirstOrDefault();
            }

            return block?.BlockNumber;
        }

        public async Task<DateTime> GetDateTimeFromTimestampAsync(SubstrateClient client, string? blockHash, CancellationToken cancellationToken)
        {
            string parameters = RequestGenerator.GetStorage("Timestamp", "Now", type: 0, hashers: null, keys: null);
            var currentTimestamp = await client.GetStorageAsync<U64>(parameters, blockHash, cancellationToken);

            var dt = DateTime.UnixEpoch.AddMilliseconds(currentTimestamp.Value);

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
