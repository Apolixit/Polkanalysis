using Microsoft.Extensions.Logging;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Worker.Parameters.Context;
using Polkanalysis.Worker.Parameters;
using Substrate.NET.Utils;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.Metrics;
using Polkanalysis.Domain.Metrics;
using Substrate.NetApi;
using MediatR;
using Polkanalysis.Domain.Contracts.Primary.Monitored.Events;
using Polkanalysis.Domain.Contracts.Primary.Monitored.Blocks;
using Polkanalysis.Domain.Contracts.Primary.Monitored.Extrinsics;
using System;
using Polkanalysis.Infrastructure.Blockchain.Common.Rpc;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Metrics;

namespace Polkanalysis.Worker.Tasks
{
    public class EventsWorker : BackgroundService
    {
        private readonly ISubstrateService _polkadotRepository;
        private readonly IExplorerService _explorerRepository;
        private readonly PerimeterService _perimeterService;
        private readonly IMediator _mediator;
        private readonly IDomainMetrics _domainMetrics;
        private readonly ILogger<EventsWorker> _logger;

        private BlockPerimeter _blockPerimeter;

        public EventsWorker(
            ISubstrateService polkadotRepository,
            IExplorerService explorerRepository,
            ISubstrateDecoding substrateDecode,
            PerimeterService perimeterService,
            ILogger<EventsWorker> logger,
            IDomainMetrics domainMetrics,
            IMediator mediator)
        {
            _polkadotRepository = polkadotRepository;
            _explorerRepository = explorerRepository;
            _perimeterService = perimeterService;
            _logger = logger;
            _domainMetrics = domainMetrics;
            _mediator = mediator;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            RunAsync(stoppingToken);
        }

        public async Task RunAsync(CancellationToken stoppingToken)
        {
            _blockPerimeter = _perimeterService.GetBlockPerimeter(GetLastBlockId);

            if (_blockPerimeter.IsSet)
            {
                await RequestBlocksAsync(stoppingToken);
            }

            // Subscribe to new blocks
            await ListenNewBlockAndInsertInDatabaseAsync(stoppingToken);
        }

        protected uint GetLastBlockId()
        {
            var lastHeader = _polkadotRepository.Rpc.Chain.GetHeaderAsync(CancellationToken.None).Result;
            return (uint)lastHeader.Number.Value;
        }

        protected async Task RequestBlocksAsync(CancellationToken stoppingToken)
        {
            if (!_blockPerimeter.IsSet) throw new InvalidOperationException("Block perimeter is not properly set");

            var header = await _polkadotRepository.Rpc.Chain.GetHeaderAsync(stoppingToken);
            
            if (header.Number.Value < _blockPerimeter.From)
            {
                _logger.LogWarning("[{workerName}] Current block number (={blockNumber}) is lower than FromBlock param (={from}), just go to subscribe new block", nameof(EventsWorker), header.Number.Value, _blockPerimeter.From);
                return;
            }

            if (_blockPerimeter.To > header.Number.Value)
            {
                _logger.LogWarning("[{workerName}] _blockPerimeter.ToBlock block number (={to}) is greater than current max block (={lastBlock})", nameof(EventsWorker), _blockPerimeter.To, header.Number.Value);
                _blockPerimeter.To = (uint)header.Number.Value;
            }

            for (uint i = _blockPerimeter.From; i < _blockPerimeter.To; i++)
            {
                var blockNumber = new BlockNumber(i);
                var hash = await _polkadotRepository.Rpc.Chain.GetBlockHashAsync(blockNumber, stoppingToken);

                if (hash == null)
                {
                    _logger.LogError("[{workerName}] Block hash for block number {blockNum} is null", nameof(EventsWorker), i);
                    break;
                }

                await AnalyseBlockAsync(blockNumber, hash, stoppingToken);
            }
        }

        protected async Task ListenNewBlockAndInsertInDatabaseAsync(CancellationToken stoppingToken)
        {
#pragma warning disable VSTHRD101 // Avoid unsupported async delegates
            await _polkadotRepository.Rpc.Chain.SubscribeAllHeadsAsync(async (subscription, header) =>
            {
                var (blockNumber, blockHash, _) = await _explorerRepository.ExtractInformationsFromHeaderAsync(header, stoppingToken);
                await AnalyseBlockAsync(blockNumber, blockHash, stoppingToken);
            }, stoppingToken);
#pragma warning restore VSTHRD101 // Avoid unsupported async delegates
        }

        private async Task AnalyseBlockAsync(BlockNumber blockNumber, Hash blockHash, CancellationToken stoppingToken)
        {
            try
            {
                var monitorTask = MonitorBlockAsync(blockNumber.Value, stoppingToken);
                var saveBlockTask = SaveBlockInformationAsync(blockNumber, stoppingToken);
                var saveExtrinsicsTask = SaveExtrinsicInformationAsync(blockNumber, stoppingToken);
                var saveEventsTask = SaveEventsInformationAsync(blockNumber, stoppingToken);

                await Task.WhenAll(monitorTask, saveBlockTask, saveExtrinsicsTask, saveEventsTask);
                //await Task.WhenAll(saveEventsTask);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[{workerName}] Fail to get events from block {blockNum}", nameof(EventsWorker), blockNumber.Value);
            }

        }

        private async Task SaveBlockInformationAsync(BlockNumber blockNumber, CancellationToken token)
        {
            // Save block information into database
            await _mediator.Send(new SavedBlocksCommand(blockNumber), token);
        }

        private async Task SaveExtrinsicInformationAsync(BlockNumber blockNumber, CancellationToken token)
        {
            // Save extrinsic information into database
            await _mediator.Send(new SavedExtrinsicsCommand(blockNumber), token);
        }

        private async Task SaveEventsInformationAsync(BlockNumber blockNumber, CancellationToken token)
        {
            // Save event information into database
            var eventRes = await _mediator.Send(new SavedEventsCommand(blockNumber), token);
            if (eventRes.IsError)
            {
                _logger.LogError("[{workerName}] {errorReason}", nameof(EventsWorker), eventRes.Error.Description);
            }
        }

        #region Metrics
        /// <summary>
        /// Increase the number of blocks that has been analyzed
        /// Get the number of blocks that has been analyzed based on the total number of blocks.
        /// Information is pushed every 100 blocks
        /// </summary>
        /// <param name="events"></param>
        private async Task MonitorBlockAsync(uint blockNumber, CancellationToken token)
        {
            if (blockNumber % 100 == 0)
            {
                var lastBlock = await _polkadotRepository.Rpc.Chain.GetHeaderAsync(token);
                _domainMetrics.RecordRatioBlockAnalyzed(((double)blockNumber / (double)lastBlock.Number.Value) * 100, _polkadotRepository.BlockchainName);
            }
        }
        #endregion
    }
}
