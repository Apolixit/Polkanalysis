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

namespace Polkanalysis.Worker.Tasks
{
    public class EventsWorker : BackgroundService
    {
        private readonly ISubstrateService _polkadotRepository;
        private readonly IExplorerService _explorerRepository;
        private readonly ISubstrateDecoding _substrateDecode;
        private readonly PerimeterService _perimeterService;
        private readonly IEventsFactory _eventsFactory;
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
            WorkerMetrics workerMetrics)
        {
            _polkadotRepository = polkadotRepository;
            _explorerRepository = explorerRepository;
            _eventsFactory = eventsFactory;
            _substrateDecode = substrateDecode;
            _perimeterService = perimeterService;
            _logger = logger;
            _workerMetrics = workerMetrics;
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
                _logger.LogWarning($"Current block number (={lastBlockdata.Block.Header.Number.Value}) is lower than FromBlock param (={_blockPerimeter.From}), just go to subscribe new block");
                return;
            }

            if (_blockPerimeter.To > lastBlockdata.Block.Header.Number.Value)
            {
                _logger.LogWarning($"_blockPerimeter.ToBlock block number (={_blockPerimeter.To}) is greater than current max block (={lastBlockdata.Block.Header.Number.Value})");
                _blockPerimeter.To = (uint)lastBlockdata.Block.Header.Number.Value;
            }

            for (uint i = _blockPerimeter.From; i < _blockPerimeter.To; i++)
            {
                var blockNumber = new BlockNumber(i);
                var hash = await _polkadotRepository.Rpc.Chain.GetBlockHashAsync(blockNumber, stoppingToken);

                if (hash == null)
                {
                    _logger.LogError($"Block hash for block number {i} is null");
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
                    _logger.LogWarning("No events associated to block num {blockId}", blockNumber);
                }
                else
                {
                    _logger.LogInformation($"Scan block num {blockNumber}, associated events = {events.Value.Length}");

                    for (int i = 0; i < events.Value.Length; i++)
                    {
                        var ev = events.Value[i];
                        var eventNode = _substrateDecode.DecodeEvent(ev);

                        // Is this event has to be insert in database ?
                        if (!_eventsFactory.Has(eventNode.Module, eventNode.Method))
                        {
                            _logger.LogDebug("[{module}][{method}] has no database event linked", eventNode.Module, eventNode.Method);
                            continue;
                        }
                        _logger.LogInformation("[{module}][{method}] is linked to database !", eventNode.Module, eventNode.Method);

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
                // Get events associated at each block
                var events = await _polkadotRepository.At(blockHash).Storage.System.EventsAsync(stoppingToken);

                if (events == null)
                {
                    _logger.LogWarning("No events associated to block num {blockId}", blockNumber);
                }
                else
                {
                    _logger.LogInformation($"Scan block num {blockNumber}, associated events = {events.Value.Length}");

                    // Get the ratio of events that has been analyzed compare to the total number of events
                    _workerMetrics.RecordEventAnalyzed((double)events.Value.Where(x => x.Event.HasBeenMapped).Count() / (double)events.Value.Count());

                    for (int i = 0; i < events.Value.Length; i++)
                    {
                        var ev = events.Value[i];
                        var eventNode = _substrateDecode.DecodeEvent(ev);

                        // Is this event has to be insert in database ?
                        if (!_eventsFactory.Has(eventNode.Module, eventNode.Method))
                        {
                            _logger.LogDebug("[{module}][{method}] has no database event linked", eventNode.Module, eventNode.Method);
                            continue;
                        }
                        _logger.LogInformation("[{module}][{method}] is linked to database !", eventNode.Module, eventNode.Method);

                        await InsertDatabaseAsync(blockNumber, currentDate, i, ev, eventNode);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fail to get events from block {blockNum}", blockNumber.Value);
            }

        }

        private async Task InsertDatabaseAsync(
            BlockNumber blockNumber,
            DateTime currentDate,
            int eventIndex,
            EventRecord ev,
            IEventNode eventNode)
        {
            var databaseModel = new EventModel(
                _polkadotRepository.BlockchainName,
                (int)blockNumber.Value,
                currentDate,
                eventIndex,
                eventNode.Module.ToString(),
                eventNode.Method.ToString())
            {
            };

            var subEvent = (BaseEnumType)ev.Event.Value!;
            await _eventsFactory.ExecuteInsertAsync(
                eventNode.Module,
                eventNode.Method,
                databaseModel,
                subEvent.GetValue2(), CancellationToken.None);
        }
    }
}
