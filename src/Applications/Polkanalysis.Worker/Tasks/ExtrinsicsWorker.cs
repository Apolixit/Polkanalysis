using Microsoft.Extensions.Logging;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Worker.Parameters;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using MediatR;
using Polkanalysis.Domain.Contracts.Primary.Monitored.Extrinsics;
using Polkanalysis.Domain.Contracts.Metrics;

namespace Polkanalysis.Worker.Tasks
{
    /// <summary>
    /// Fetch extrinsics and call the domain to insert the information into the database
    /// </summary>
    /// <param name="substrateService"></param>
    /// <param name="explorerservice"></param>
    /// <param name="perimeterService"></param>
    /// <param name="logger"></param>
    /// <param name="domainMetrics"></param>
    /// <param name="mediator"></param>
    public class ExtrinsicsWorker(
        ISubstrateService substrateService,
        IExplorerService explorerservice,
        PerimeterService perimeterService,
        ILogger<ExtrinsicsWorker> logger,
        IDomainMetrics domainMetrics,
        IMediator mediator) : AbstractBlockableWorker(substrateService, explorerservice, perimeterService, mediator, domainMetrics, logger)
    {
        private readonly ILogger<ExtrinsicsWorker> _logger = logger;
        protected override string WorkerName => nameof(ExtrinsicsWorker);

        protected override async Task AnalyseInnerAsync(BlockNumber blockNumber, Hash blockHash, CancellationToken stoppingToken)
        {
            try
            {
                var monitorTask = MonitorRatioExtrinsicsAnalyzedAsync(blockNumber.Value, stoppingToken);
                var saveExtrinsicsTask = SaveExtrinsicInformationAsync(blockNumber, stoppingToken);

                await Task.WhenAll(monitorTask, saveExtrinsicsTask);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[{workerName}] Fail to get events from block {blockNum}", WorkerName, blockNumber.Value);
            }

        }

        private async Task SaveExtrinsicInformationAsync(BlockNumber blockNumber, CancellationToken token)
        {
            // Save extrinsic information into database
            await _mediator.Send(new SavedExtrinsicsCommand(blockNumber), token);
        }

        private async Task MonitorRatioExtrinsicsAnalyzedAsync(uint blockNumber, CancellationToken token)
        {
            if (blockNumber % 100 == 0)
            {
                var lastBlock = await _substrateService.Rpc.Chain.GetHeaderAsync(token);
                _domainMetrics.RecordRatioExtrinsicsAnalyzedOnTotal(((double)blockNumber / (double)lastBlock.Number.Value) * 100, _substrateService.BlockchainName);
            }
        }
    }
}
