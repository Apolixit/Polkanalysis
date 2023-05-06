﻿using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.AjunaExtension;
using Polkanalysis.Infrastructure.Contracts.Database.Model.Events;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.SystemCore.Enums;
using Polkanalysis.DatabaseWorker.Parameters;

namespace Polkanalysis.DatabaseWorker
{
    internal class EventsWorker : BackgroundService
    {
        private readonly ISubstrateRepository _polkadotRepository;
        private readonly IExplorerRepository _explorerRepository;
        private readonly ISubstrateDecoding _substrateDecode;
        private readonly IEventsFactory _eventsFactory;
        private readonly BlockPerimeter _blockPerimeter;
        private readonly ILogger<EventsWorker> _logger;

        public EventsWorker(
            ISubstrateRepository polkadotRepository,
            IExplorerRepository explorerRepository,
            IEventsFactory eventsFactory,
            ISubstrateDecoding substrateDecode,
            BlockPerimeter blockPerimeter,
            ILogger<EventsWorker> logger)
        {
            _polkadotRepository = polkadotRepository;
            _explorerRepository = explorerRepository;
            _eventsFactory = eventsFactory;
            _substrateDecode = substrateDecode;
            _blockPerimeter = blockPerimeter;
            _logger = logger;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Connect to blockchain
            if (!_polkadotRepository.IsConnected())
            {
                await _polkadotRepository.ConnectAsync();
                _logger.LogInformation($"Succesfully connected to {_polkadotRepository.BlockchainName}");
            }

            if (_blockPerimeter.IsSet())
            {
                await RequestBlocksAsync(stoppingToken);
            }
            // Subscribe to new blocks
            await ListenNewBlockAndInsertInDatabaseAsync(stoppingToken);
            //await ExampleBlockAndInsertInDatabaseAsync(stoppingToken);

            
        }

        public async override Task StopAsync(CancellationToken cancellationToken)
        {
            await _polkadotRepository.CloseAsync();
            _logger.LogInformation($"Succesfully disconnected to {_polkadotRepository.BlockchainName}");

            await base.StopAsync(cancellationToken);
        }

        protected async Task RequestBlocksAsync(CancellationToken stoppingToken)
        {
            var lastBlockdata = await _polkadotRepository.Rpc.Chain.GetBlockAsync(stoppingToken);

            if (_blockPerimeter.FromBlock != null && lastBlockdata.Block.Header.Number.Value < _blockPerimeter.FromBlock.Value)
            {
                _logger.LogWarning($"Current block number (={lastBlockdata.Block.Header.Number.Value}) is lower than FromBlock param (={_blockPerimeter.FromBlock.Value}), just go to subscribe new block");
                return;
            }

            _blockPerimeter.ToBlock = _blockPerimeter.ToBlock ?? (uint)lastBlockdata.Block.Header.Number.Value;

            if (_blockPerimeter.ToBlock > lastBlockdata.Block.Header.Number.Value)
            {
                _logger.LogWarning($"_blockPerimeter.ToBlock block number (={_blockPerimeter.ToBlock.Value}) is greater than current max block (={lastBlockdata.Block.Header.Number.Value})");
                _blockPerimeter.ToBlock = (uint)lastBlockdata.Block.Header.Number.Value;
            }

            for (uint i = _blockPerimeter.FromBlock!.Value; i < _blockPerimeter.ToBlock!.Value; i++)
            {
                var blockNumber = new BlockNumber(i);
                var hash = await _polkadotRepository.Rpc.Chain.GetBlockHashAsync(blockNumber, stoppingToken);

                if(hash == null)
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

            foreach(var blockNum in blockNumbers)
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

            var subEvent = (BaseEnumType)ev.Event.Value.Value2;
            await _eventsFactory.ExecuteInsertAsync(
                eventNode.Module,
                eventNode.Method,
                databaseModel,
                subEvent.GetValue2(), CancellationToken.None);
        }
    }
}