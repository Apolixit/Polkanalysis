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
    /// <summary>
    /// Fetch events and call the domain to insert the information into the database
    /// </summary>
    public class EventsWorker : AbstractBlockableWorker
    {
        private readonly ISubstrateService _polkadotRepository;
        private readonly IExplorerService _explorerRepository;
        private readonly PerimeterService _perimeterService;
        private readonly IMediator _mediator;
        private readonly IDomainMetrics _domainMetrics;
        private readonly ILogger<EventsWorker> _logger;
        protected override string WorkerName => nameof(EventsWorker);

        public EventsWorker(
            ISubstrateService substrateService,
            IExplorerService explorerservice,
            PerimeterService perimeterService,
            ILogger<EventsWorker> logger,
            IDomainMetrics domainMetrics,
            IMediator mediator) : base(substrateService, explorerservice, perimeterService, mediator, domainMetrics, logger)
        {
            _polkadotRepository = polkadotRepository;
            _explorerRepository = explorerRepository;
            _perimeterService = perimeterService;
            _logger = logger;
            _domainMetrics = domainMetrics;
            _mediator = mediator;
        }

        protected override async Task AnalyseInnerAsync(BlockNumber blockNumber, Hash blockHash, CancellationToken stoppingToken)
        {
            try
            {
                var monitorTask = MonitorRatioEventsAnalyzedAsync(blockNumber.Value, stoppingToken);
                var saveEventsTask = SaveEventsInformationAsync(blockNumber, stoppingToken);

                await Task.WhenAll(monitorTask, saveEventsTask);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[{workerName}] Fail to get events from block {blockNum}", WorkerName, blockNumber.Value);
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
                _logger.LogError("[{workerName}] {errorReason}", WorkerName, eventRes.Error.Description);
            }
        }

        #region Metrics
        private async Task MonitorRatioEventsAnalyzedAsync(uint blockNumber, CancellationToken token)
        {
            if (blockNumber % 100 == 0)
            {
                var lastBlock = await _substrateService.Rpc.Chain.GetHeaderAsync(token);
                _domainMetrics.RecordRatioEventsAnalyzedOnTotal(((double)blockNumber / (double)lastBlock.Number.Value) * 100, _substrateService.BlockchainName);
            }
        }
        #endregion
    }
}
