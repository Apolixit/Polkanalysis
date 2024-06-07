using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Runtime;
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
using Polkanalysis.Worker.Metrics;
using Substrate.NetApi;
using MediatR;
using Polkanalysis.Domain.Contracts.Primary.Monitored.Events;
using Polkanalysis.Domain.Contracts.Primary.Monitored.Blocks;

namespace Polkanalysis.Worker.Tasks
{
    public class EventsWorker : BackgroundService
    {
        private readonly ISubstrateService _polkadotRepository;
        private readonly IExplorerService _explorerRepository;
        private readonly ISubstrateDecoding _substrateDecode;
        private readonly PerimeterService _perimeterService;
        private readonly IEventsFactory _eventsFactory;
        private readonly IMediator _mediator;
        private readonly WorkerMetrics _workerMetrics;
        private readonly ILogger<EventsWorker> _logger;

        private BlockPerimeter _blockPerimeter;

        public EventsWorker(
            ISubstrateService polkadotRepository,
            IExplorerService explorerRepository,
            IEventsFactory eventsFactory,
            ISubstrateDecoding substrateDecode,
            PerimeterService perimeterService,
            ILogger<EventsWorker> logger,
            WorkerMetrics workerMetrics,
            IMediator mediator)
        {
            _polkadotRepository = polkadotRepository;
            _explorerRepository = explorerRepository;
            _eventsFactory = eventsFactory;
            _substrateDecode = substrateDecode;
            _perimeterService = perimeterService;
            _logger = logger;
            _workerMetrics = workerMetrics;
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
            //await ExampleBlockAndInsertInDatabaseAsync(stoppingToken);
        }

        protected uint GetLastBlockId()
        {
            var lastHeader = _polkadotRepository.Rpc.Chain.GetHeaderAsync(CancellationToken.None).Result;
            return (uint)lastHeader.Number.Value;
        }

        protected async Task RequestBlocksAsync(CancellationToken stoppingToken)
        {
            if (!_blockPerimeter.IsSet) throw new InvalidOperationException("Block perimeter is not properly set");

            var lastBlockdata = await _polkadotRepository.Rpc.Chain.GetBlockAsync(stoppingToken);

            if (lastBlockdata.Block.Header.Number.Value < _blockPerimeter.From)
            {
                _logger.LogWarning("[{workerName}] Current block number (={blockNumber}) is lower than FromBlock param (={from}), just go to subscribe new block", nameof(EventsWorker), lastBlockdata.Block.Header.Number.Value, _blockPerimeter.From);
                return;
            }

            if (_blockPerimeter.To > lastBlockdata.Block.Header.Number.Value)
            {
                _logger.LogWarning("[{workerName}] _blockPerimeter.ToBlock block number (={to}) is greater than current max block (={lastBlock})", nameof(EventsWorker), _blockPerimeter.To, lastBlockdata.Block.Header.Number.Value);
                _blockPerimeter.To = (uint)lastBlockdata.Block.Header.Number.Value;
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

        protected async Task ExampleBlockAndInsertInDatabaseAsync(CancellationToken stoppingToken)
        {
            /*
             * Balances balance set : 445655
             * Balances dust lost : 15328960
             * Balances endowed : 15328997
             * Balances reserved : 15328854
             * Balances slashed : 14148296
             * Balances transfer : 15329002
             * Balances unreserved : 15328862
             * 
             * Identity identity cleared : 15316948
             * Identity identity killed :
             * Identity identity set : 15317368
             * 
             * System killed account : 15328960
             * System new account : 15328966
             */
            var blockNumbers = new List<uint>()
            {
                15328960, 15328997, 15328854, 14148296, 15329002, 15328862, 15316948, 15317368, 15328960, 15328966
            };

            foreach (var blockNum in blockNumbers)
            {
                var hash = await _polkadotRepository.Rpc.Chain.GetBlockHashAsync(new BlockNumber(blockNum), stoppingToken);
                var blockData = await _polkadotRepository.Rpc.Chain.GetBlockAsync(hash, stoppingToken);
                var (blockNumber, blockHash, _) = await _explorerRepository.ExtractInformationsFromHeaderAsync(blockData.Block.Header, stoppingToken);
                var currentDate = await _explorerRepository.GetDateTimeFromTimestampAsync(blockHash, stoppingToken);

                // Get events associated at each block
                var events = await _polkadotRepository.At(blockHash).Storage.System.EventsAsync(stoppingToken);

                if (events == null)
                {
                    _logger.LogWarning("[{workerName}]  No events associated to block num {blockId}", nameof(EventsWorker), blockNumber);
                }
                else
                {
                    _logger.LogInformation("[{workerName}] Scan block num {blockNumber}, associated events = {eventsCount}", nameof(EventsWorker), blockNumber, events.Value.Length);

                    for (int i = 0; i < events.Value.Length; i++)
                    {
                        var ev = events.Value[i];
                        var eventNode = _substrateDecode.DecodeEvent(ev);

                        // Is this event has to be insert in database ?
                        if (!_eventsFactory.Has(eventNode.Module, eventNode.Method))
                        {
                            _logger.LogDebug("[{workerName}][{module}][{method}] has no database event linked", nameof(EventsWorker), eventNode.Module, eventNode.Method);
                            continue;
                        }
                        _logger.LogInformation("[{workerName}][{module}][{method}] is linked to database !", nameof(EventsWorker), eventNode.Module, eventNode.Method);

                        await InsertDatabaseAsync(blockNumber, currentDate, i, ev, eventNode);
                    }
                }
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
            var currentDate = await _explorerRepository.GetDateTimeFromTimestampAsync(blockHash, stoppingToken);

            try
            {
                await MonitorBlockAsync(blockNumber.Value, stoppingToken);
                await SaveBlockInformationAsync(blockNumber);

                // Get events associated at each block
                var events = await _polkadotRepository.At(blockHash).Storage.System.EventsAsync(stoppingToken);

                if (events == null)
                {
                    _logger.LogWarning("[{workerName}] No events associated to block num {blockId}", nameof(EventsWorker), blockNumber);
                }
                else
                {
                    _logger.LogInformation("[{workerName}] Scan block num {blockNumber}, associated events = {eventsCount}", nameof(EventsWorker), blockNumber, events.Value.Length);

                    var ratio = PushEventAnalyzedByBlockRatio(events);

                    for (int i = 0; i < events.Value.Length; i++)
                    {
                        var ev = events.Value[i];

                        //if (!ev.Event.HasBeenMapped) continue;

                        try
                        {
                            var eventNode = _substrateDecode.DecodeEvent(ev);

                            // Is this event has to be insert in database ?
                            if (!_eventsFactory.Has(eventNode.Module, eventNode.Method))
                            {
                                _logger.LogDebug("[{workerName}][{module}][{method}] has no database event linked", nameof(EventsWorker), eventNode.Module, eventNode.Method);
                                continue;
                            }
                            _logger.LogInformation("[{workerName}][{module}][{method}] is linked to database. Ratio = {ratio}", nameof(EventsWorker), eventNode.Module, eventNode.Method, ratio);

                            await InsertDatabaseAsync(blockNumber, currentDate, i, ev, eventNode);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, "[{workerName}] Unable to successfully decode event index {eventIndex} from block {blockNum}. Event value = ({eventHex}). Ratio = {ratio}", nameof(EventsWorker), i, blockNumber, Utils.Bytes2HexString(ev.Bytes), ratio);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[{workerName}] Fail to get events from block {blockNum}", nameof(EventsWorker), blockNumber.Value);
            }

        }

        private async Task SaveBlockInformationAsync(BlockNumber blockNumber)
        {
            // Save block information into database
            await _mediator.Send(new SavedBlocksCommand(blockNumber));
        }

        private async Task InsertDatabaseAsync(
            BlockNumber blockNumber,
            DateTime currentDate,
            int eventIndex,
            EventRecord ev,
            IEventNode eventNode)
        {
            var res = await _mediator.Send(new SavedEventsCommand(blockNumber, currentDate, eventIndex, ev, eventNode));
            
            if (res.IsSuccess)
            {
                _workerMetrics.IncreaseAnalyzedEventsCount();
            } else
            {
                _logger.LogError("[{workerName}] {errorReason}", nameof(EventsWorker), res.Error.Description);
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
            _workerMetrics.IncreaseBlockCount();
            if (blockNumber % 100 == 0)
            {
                var lastBlock = await _polkadotRepository.Rpc.Chain.GetHeaderAsync(token);
                _workerMetrics.RatioBlockAnalyzed(((double)blockNumber / (double)lastBlock.Number.Value) * 100);
            }
        }

        /// <summary>
        /// Get the ratio of events that has been analyzed compare to the total number of events
        /// </summary>
        /// <param name="events"></param>
        private double PushEventAnalyzedByBlockRatio(BaseVec<EventRecord> events)
        {
            var ratio = (double)events.Value.Where(x => x.Event.HasBeenMapped).Count() / (double)events.Value.Count();
            _workerMetrics.RecordEventAnalyzed(ratio);

            return ratio;
        }
        #endregion
    }
}
