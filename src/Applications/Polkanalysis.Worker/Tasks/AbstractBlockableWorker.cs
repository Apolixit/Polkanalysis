using Microsoft.Extensions.Hosting;
using Polkanalysis.Worker.Parameters.Context;
using Polkanalysis.Worker.Parameters;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Service;
using MediatR;
using Polkanalysis.Domain.Contracts.Metrics;

namespace Polkanalysis.Worker.Tasks
{
    public abstract class AbstractBlockableWorker(
        ISubstrateService polkadotRepository, 
        IExplorerService explorerRepository, 
        PerimeterService perimeterService, 
        IMediator mediator, 
        IDomainMetrics domainMetrics, 
        ILogger logger) : BackgroundService
    {
        protected readonly ISubstrateService _substrateService = polkadotRepository;
        protected readonly IExplorerService _explorerService = explorerRepository;
        protected readonly PerimeterService _perimeterService = perimeterService;
        protected readonly IMediator _mediator = mediator;
        protected readonly IDomainMetrics _domainMetrics = domainMetrics;
        private readonly ILogger _logger = logger;

        protected BlockPerimeter _blockPerimeter = default!;
        protected abstract string WorkerName { get; }

        protected abstract Task AnalyseInnerAsync(BlockNumber blockNumber, Hash blockHash, CancellationToken stoppingToken);

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await RunAsync(stoppingToken);
        }

        /// <summary>
        /// Return the last block id
        /// </summary>
        /// <returns></returns>
        protected uint GetLastBlockId()
        {
            var lastHeader = _substrateService.Rpc.Chain.GetHeaderAsync(CancellationToken.None).Result;
            return (uint)lastHeader.Number.Value;
        }

        public async Task RunAsync(CancellationToken stoppingToken)
        {
            _blockPerimeter = _perimeterService.GetBlockPerimeter(GetLastBlockId);

            if (_blockPerimeter.IsSet)
            {
                await RequestBlocksAsync(stoppingToken);

                // Subscribe to new blocks
                await ListenNewBlockAndInsertInDatabaseAsync(stoppingToken);
            }
        }

        protected async Task RequestBlocksAsync(CancellationToken stoppingToken)
        {
            if (!_blockPerimeter.IsSet) throw new InvalidOperationException("Block perimeter is not properly set");

            var header = await _substrateService.Rpc.Chain.GetHeaderAsync(stoppingToken);

            if (header.Number.Value < _blockPerimeter.From)
            {
                _logger.LogWarning("[{workerName}] Current block number (={blockNumber}) is lower than FromBlock param (={from}), just go to subscribe new block", WorkerName, header.Number.Value, _blockPerimeter.From);
                return;
            }

            if (_blockPerimeter.To > header.Number.Value)
            {
                _logger.LogWarning("[{workerName}] _blockPerimeter.ToBlock block number (={to}) is greater than current max block (={lastBlock})", WorkerName, _blockPerimeter.To, header.Number.Value);
                _blockPerimeter.To = (uint)header.Number.Value;
            }

            for (uint i = _blockPerimeter.From; i < _blockPerimeter.To; i++)
            {
                var blockNumber = new BlockNumber(i);
                var hash = await _substrateService.Rpc.Chain.GetBlockHashAsync(blockNumber, stoppingToken);

                if (hash == null)
                {
                    _logger.LogError("[{workerName}] Block hash for block number {blockNum} is null", WorkerName, i);
                    break;
                }

                await AnalyseInnerAsync(blockNumber, hash, stoppingToken);
            }
        }

        protected async Task ListenNewBlockAndInsertInDatabaseAsync(CancellationToken stoppingToken)
        {
#pragma warning disable VSTHRD101 // Avoid unsupported async delegates
            await _substrateService.Rpc.Chain.SubscribeAllHeadsAsync(async (subscription, header) =>
            {
                var (blockNumber, blockHash, _) = await _explorerService.ExtractInformationsFromHeaderAsync(header, stoppingToken);
                await AnalyseInnerAsync(blockNumber, blockHash, stoppingToken);
            }, stoppingToken);
#pragma warning restore VSTHRD101 // Avoid unsupported async delegates
        }

        
    }
}
