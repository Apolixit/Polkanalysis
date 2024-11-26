using Microsoft.Extensions.Logging;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Worker.Parameters;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using MediatR;
using Polkanalysis.Domain.Contracts.Primary.Monitored.Blocks;
using Polkanalysis.Domain.Contracts.Metrics;

namespace Polkanalysis.Worker.Tasks
{
    /// <summary>
    /// Fetch blocks and call the domain to insert the information into the database
    /// </summary>
    /// <param name="substrateService"></param>
    /// <param name="explorerservice"></param>
    /// <param name="perimeterService"></param>
    /// <param name="logger"></param>
    /// <param name="domainMetrics"></param>
    /// <param name="mediator"></param>
    public class BlockWorker(
        ISubstrateService substrateService,
        IExplorerService explorerservice,
        PerimeterService perimeterService,
        ILogger<BlockWorker> logger,
        IDomainMetrics domainMetrics,
        IMediator mediator) : AbstractBlockableWorker(substrateService, explorerservice, perimeterService, mediator, domainMetrics, logger)
    {
        private readonly ILogger<BlockWorker> _logger = logger;

        protected override string WorkerName => nameof(BlockWorker);

        protected override async Task AnalyseInnerAsync(BlockNumber blockNumber, Hash blockHash, CancellationToken stoppingToken)
        {
            try
            {
                var monitorTask = MonitorRatioBlocksAnalyzedAsync(blockNumber.Value, stoppingToken);
                var saveBlockTask = SaveBlockInformationAsync(blockNumber, stoppingToken);

                await Task.WhenAll(monitorTask, saveBlockTask);
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

        private async Task MonitorRatioBlocksAnalyzedAsync(uint blockNumber, CancellationToken token)
        {
            if (blockNumber % 100 == 0)
            {
                var lastBlock = await _substrateService.Rpc.Chain.GetHeaderAsync(token);
                _domainMetrics.RecordRatioBlockAnalyzedOnTotal(((double)blockNumber / (double)lastBlock.Number.Value) * 100, _substrateService.BlockchainName);
            }
        }
    }
}
