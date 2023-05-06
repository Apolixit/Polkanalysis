using Substrate.NetApi;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Dto.Event;
using Polkanalysis.Domain.Contracts.Exception;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Dto.Extrinsic;
using Substrate.NetApi.Model.Extrinsics;
using Polkanalysis.Domain.Contracts.Dto;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.Adapter.Block;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.SystemCore.Enums;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotRuntime;
using Polkanalysis.Domain.Contracts.Secondary.Contracts;

namespace Polkanalysis.Domain.Repository
{
    public class PolkadotExplorerRepository : IExplorerRepository
    {
        private readonly ISubstrateRepository _substrateService;
        private readonly ISubstrateDecoding _substrateDecode;
        private readonly IModelBuilder _modelBuilder;
        private readonly IBlockchainMapping _mapping;
        private readonly ILogger<PolkadotExplorerRepository> _logger;
        private BlockLightDto? _lastBlock;
        private BlockParameterLike _blockParameter;

        public PolkadotExplorerRepository(
            ISubstrateRepository substrateNodeRepository,
            ISubstrateDecoding substrateDecode,
            IModelBuilder modelBuilder,
            ILogger<PolkadotExplorerRepository> logger)
        {
            _substrateService = substrateNodeRepository;
            _substrateDecode = substrateDecode;
            _modelBuilder = modelBuilder;
            _logger = logger;

            _blockParameter = new BlockParameterLike(_substrateService);
        }

        public async Task<BlockLightDto> GetBlockLightAsync(uint blockId, CancellationToken cancellationToken)
            => await GetBlockLightAsync(await _blockParameter.FromBlockNumberAsync(blockId), cancellationToken);

        public Task<BlockLightDto> GetBlockLightAsync(string blockHash, CancellationToken cancellationToken)
            => GetBlockLightAsync(_blockParameter.FromBlockHash(blockHash), cancellationToken);

        public Task<BlockLightDto> GetBlockLightAsync(Hash blockHash, CancellationToken cancellationToken)
            => GetBlockLightAsync(_blockParameter.FromBlockHash(blockHash), cancellationToken);
        protected async Task<BlockLightDto> GetBlockLightAsync(BlockParameterLike block, CancellationToken cancellationToken)
        {
            var blockHash = await block.ToBlockHashAsync();
            var blockData = await _substrateService.Rpc.Chain.GetBlockAsync(blockHash, cancellationToken);
            if (blockData == null)
                throw new BlockException($"{blockData} for block hash = {blockHash.Value} is null");

            var blockDate = await GetDateTimeFromTimestampAsync(blockHash, cancellationToken);

            return _modelBuilder.BuildBlockLightDto(blockHash, blockData, blockDate);
        }

        public async Task<BlockDto> GetBlockDetailsAsync(uint blockId, CancellationToken cancellationToken) => await GetBlockDetailsAsync(await _blockParameter.FromBlockNumberAsync(blockId), cancellationToken);

        public Task<BlockDto> GetBlockDetailsAsync(string blockHash, CancellationToken cancellationToken)
            => GetBlockDetailsAsync(_blockParameter.FromBlockHash(blockHash), cancellationToken);

        public Task<BlockDto> GetBlockDetailsAsync(Hash blockHash, CancellationToken cancellationToken)
            => GetBlockDetailsAsync(_blockParameter.FromBlockHash(blockHash), cancellationToken);

        protected async Task<BlockDto> GetBlockDetailsAsync(BlockParameterLike block, CancellationToken cancellationToken)
        {
            var blockHash = await block.ToBlockHashAsync();
            var blockDetailsTask = _substrateService.Rpc.Chain.GetBlockAsync(blockHash, cancellationToken);

            var currentDateTask = GetDateTimeFromTimestampAsync(blockHash, cancellationToken);
            var eventsCountTask = _substrateService.At(blockHash).Storage.System.EventCountAsync(cancellationToken);
            var blockExecutionPhaseTask = _substrateService.At(blockHash).Storage.System.ExecutionPhaseAsync(cancellationToken);
            var specVersionTask = _substrateService.Rpc.State.GetRuntimeVersionAtAsync(blockHash.Value, cancellationToken);

            await Task.WhenAll(new Task[] { 
                currentDateTask, 
                eventsCountTask, 
                blockExecutionPhaseTask, 
                specVersionTask, 
                blockDetailsTask });

            var blockDetails = blockDetailsTask.Result;
            if (blockDetails == null)
                throw new BlockException($"{blockDetails} for block hash = {blockHash.Value} is null");

            var filteredExtrinsic = blockDetails.Block.Extrinsics.Where(e => e.Method.ModuleIndex != 54);
            foreach (var extrinsic in filteredExtrinsic)
            {
                var extrinsicDecode = _substrateDecode.DecodeExtrinsic(extrinsic);
            }

            var status = blockExecutionPhaseTask.Result.Value switch
            {
                Phase.ApplyExtrinsic => GlobalStatusDto.BlockStatusDto.Broadcasted,
                Phase.Initialization => GlobalStatusDto.BlockStatusDto.InBlock,
                Phase.Finalization => GlobalStatusDto.BlockStatusDto.Finalized,
                _ => GlobalStatusDto.BlockStatusDto.Retracted
            };
            //var digest = await _substrateService.At(blockHash).Storage.System.DigestAsync(cancellationToken);

            //foreach (var log in blockDetails.Block.Header.Digest.Logs) // TODO Check with Cedric
            //{
            //    var buildLogs = new EnumDigestItem();
            //    buildLogs.Create(log);
            //}
            //var logDecode = _substrateDecode.DecodeLog(blockDetails.Block.Header.Digest.Logs);
            //var founded1 = logDecode.Has(DigestItem.PreRuntime);
            //var founded = logDecode.Find(DigestItem.PreRuntime);

            //await _substrateService.Client.Core.Author.PendingExtrinsicAsync
            //var resMagic0 = await _substrateService.Client.Core.Author.PendingExtrinsicAsync(cancellationToken);
            //var resMagic1 = await _substrateService.Client.BabeStorage.AuthorVrfRandomness(cancellationToken);
            //var currentSlot = await _substrateService.Client.BabeStorage.CurrentSlot(cancellationToken);
            //var epochIndex = await _substrateService.Client.BabeStorage.EpochIndex(cancellationToken);
            //var epochStart = await _substrateService.Client.BabeStorage.EpochStart(cancellationToken);
            //var initializeMagic = await _substrateService.Client.BabeStorage.Initialized(cancellationToken);
            //var nextAuthorities = await _substrateService.Client.BabeStorage.NextAuthorities(cancellationToken);
            //var randomness = await _substrateService.Client.BabeStorage.Randomness(cancellationToken);
            //var nextEpochConfig = await _substrateService.Client.BabeStorage.NextEpochConfig(cancellationToken);
            //var resMagic2 = await _substrateService.Client.Core.InvokeAsync<object>("grandpa_proveFinality", new object[1] { blockDetails.Block.Header.Number.Value }, cancellationToken);

            var blockDto = new BlockDto()
            {
                Date = _modelBuilder.BuildDateDto(await currentDateTask),
                ExtrinsicsRoot = blockDetails.Block.Header.ExtrinsicsRoot,
                ParentHash = blockDetails.Block.Header.ParentHash,
                StateRoot = blockDetails.Block.Header.StateRoot,
                Number = blockDetails.Block.Header.Number.Value,
                Hash = blockHash,
                Status = status,
                NbExtrinsics = (uint)blockDetails.Block.Extrinsics.Length,
                NbEvents = (await eventsCountTask).Value,
                NbLogs = (uint)blockDetails.Block.Header.Digest.Logs.Count,
                SpecVersion = (await specVersionTask).SpecVersion,
                Validator = null,
            };

            return blockDto;
        }

        ///// <summary>
        ///// Typscript implementation here : https://github.com/polkadot-js/api/blob/ed426108f276daaef7e940b8cc773239c05c9b06/packages/api-derive/src/chain/util.ts#L28
        ///// </summary>
        ///// <param name="cancellationToken"></param>
        ///// <returns></returns>
        //private async Task<ValidatorDto> GetBlockAuthor(Hash blockHash, CancellationToken cancellationToken)
        //{
        //    // Get current list of validators
        //    var validators = await _substrateService.Client.SessionStorage.Validators(cancellationToken);

        //    return 
        //}


        public async Task<DateTime> GetDateTimeFromTimestampAsync(Hash? blockHash, CancellationToken cancellationToken)
        {
            var currentTimestamp = blockHash switch
            {
                null => await _substrateService.Storage.Timestamp.NowAsync(cancellationToken),
                _ => await _substrateService.At(blockHash).Storage.Timestamp.NowAsync(cancellationToken)
            };

            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                .AddMilliseconds(currentTimestamp.Value);
        }

        public Task<BlockLightDto?> GetLastBlockAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() => _lastBlock, cancellationToken);
        }

        public async Task SubscribeNewBlocksAsync(Action<BlockLightDto> blockCallback, CancellationToken cancellationToken)
        {
#pragma warning disable VSTHRD101 // Avoid unsupported async delegates
            await _substrateService.Rpc.Chain.SubscribeAllHeadsAsync(async (subscription, header) =>
            {
                var (_, blockHash, _) = await ExtractInformationsFromHeaderAsync(header, cancellationToken);

                _lastBlock = await GetBlockLightAsync(blockHash, cancellationToken);
                blockCallback(_lastBlock);
            }, cancellationToken);
#pragma warning restore VSTHRD101 // Avoid unsupported async delegates
        }

        public Task<IEnumerable<EventDto>> GetEventsAsync(string blockHash, CancellationToken cancellationToken)
            => GetEventsAsync(_blockParameter.FromBlockHash(blockHash), cancellationToken);

        public async Task<IEnumerable<EventDto>> GetEventsAsync(uint blockId, CancellationToken cancellationToken)
            => await GetEventsAsync(await _blockParameter.FromBlockNumberAsync(blockId), cancellationToken);

        public Task<IEnumerable<EventDto>> GetEventsAsync(Hash blockHash, CancellationToken cancellationToken)
            => GetEventsAsync(_blockParameter.FromBlockHash(blockHash), cancellationToken);

        protected async Task<IEnumerable<EventDto>> GetEventsAsync(BlockParameterLike block, CancellationToken cancellationToken)
        {
            var blockHash = await block.ToBlockHashAsync();
            var events = await _substrateService.At(blockHash).Storage.System.EventsAsync(cancellationToken);

            var eventsDto = new List<EventDto>();

            foreach (var ev in events.Value)
            {
                var eventNode = _substrateDecode.DecodeEvent(ev);

                eventsDto.Add(
                    _modelBuilder.BuildEventDto(
                        await GetBlockLightAsync(blockHash, cancellationToken),
                        eventNode)
                    );
            }

            return eventsDto;
        }


        public Task<IEnumerable<ExtrinsicDto>> GetExtrinsicsAsync(string blockHash, CancellationToken cancellationToken)
            => GetExtrinsicsAsync(_blockParameter.FromBlockHash(blockHash), cancellationToken);

        public async Task<IEnumerable<ExtrinsicDto>> GetExtrinsicsAsync(uint blockId, CancellationToken cancellationToken) => await GetExtrinsicsAsync(await _blockParameter.FromBlockNumberAsync(blockId), cancellationToken);

        public Task<IEnumerable<ExtrinsicDto>> GetExtrinsicsAsync(Hash blockHash, CancellationToken cancellationToken)
            => GetExtrinsicsAsync(_blockParameter.FromBlockHash(blockHash), cancellationToken);

        public async Task<IEnumerable<ExtrinsicDto>> GetExtrinsicsAsync(BlockParameterLike block, CancellationToken cancellationToken)
        {
            var blockHash = await block.ToBlockHashAsync();
            var blockDetails = await _substrateService.Rpc.Chain.GetBlockAsync(blockHash, cancellationToken);
            if (blockDetails == null)
                throw new BlockException($"{blockDetails} for block hash = {blockHash.Value} is null");

            var extrinsicsDto = new List<ExtrinsicDto>();
            foreach (var extrinsic in blockDetails.Block.Extrinsics.Where(e => e.Method.ModuleIndex != 54))
            {
                var encodedExtrinsic = extrinsic.Encode();
                var hexExtrinsic = Utils.Bytes2HexString(encodedExtrinsic);
                var extrinsicHash = new Hash();
                extrinsicHash.Create(hexExtrinsic);
                var extrinsicFromEncoded = new Extrinsic(hexExtrinsic, ChargeTransactionPayment.Default());
                var extrinsicFromOfficial = new Extrinsic("0x280403000b207eba5c8501", ChargeTransactionPayment.Default());
                var isEqual = extrinsic.Equals(extrinsicFromEncoded);
                var isEqual2 = extrinsic.Equals(extrinsicFromOfficial);

                var blockLight = await GetBlockLightAsync(blockHash, cancellationToken);
                var extrinsicNode = _substrateDecode.DecodeExtrinsic(extrinsic);

                extrinsicsDto.Add(
                    _modelBuilder.BuildExtrinsicDto(
                        extrinsic,
                        blockLight,
                        extrinsicNode,
                        (uint)blockDetails.Block.Extrinsics.ToList().IndexOf(extrinsic))
                    );
            }

            return extrinsicsDto;
        }

        public async Task<IEnumerable<EventDto>?> GetEventsLinkedToExtrinsicsAsync(
            ExtrinsicDto extrinsicDto,
            CancellationToken cancellationToken)
        {
            var blockDetails = await _substrateService.Rpc.Chain.GetBlockAsync(
                extrinsicDto.Block.Hash, cancellationToken);
            if (blockDetails == null)
                throw new BlockException($"{blockDetails} for block hash = {extrinsicDto.Block.Hash} is null");

            return await GetEventsLinkedToExtrinsicsAsync(extrinsicDto, blockDetails.Block.Extrinsics, cancellationToken);
        }

        public async Task<IEnumerable<EventDto>?> GetEventsLinkedToExtrinsicsAsync(
            ExtrinsicDto extrinsicDto,
            IEnumerable<Extrinsic> extrinsics,
            CancellationToken cancellationToken)
        {
            var blockLight = await GetBlockLightAsync(extrinsicDto.Block.Hash, cancellationToken);

            // Return every events linked to this block
            //BaseVec<EventRecord> events = await _substrateService.Api.Core.GetStorageAsync<BaseVec<EventRecord>>(
            //    SystemStorage.EventsParams(), extrinsicDto.Block.Hash.Value, cancellationToken);
            var events = await _substrateService.At(extrinsicDto.Block.Hash).Storage.System.EventsAsync(cancellationToken);

            // Doc here :
            // https://polkadot.js.org/docs/api/cookbook/blocks#how-do-i-map-extrinsics-to-their-events
            // Event Phase must be "Apply extrinsic" dans his value must be equal to extrinsic index
            IEnumerable<EventRecord> eventLinkedToCurrentExtrinsic = events.Value.Where(e =>
            {
                if (e.Phase.Value == Phase.ApplyExtrinsic)
                {
                    var applyExtrinsicIndex = ((Substrate.NetApi.Model.Types.Primitive.U32)e.Phase.Value2).Value;
                    return applyExtrinsicIndex == extrinsicDto.Index;
                }
                return false;
            });

            var eventsLinked = eventLinkedToCurrentExtrinsic
                .Select(ev => _modelBuilder.BuildEventDto(
                    blockLight,
                    _substrateDecode.DecodeEvent(ev))
                );

            return eventsLinked;
        }

        public async Task SubscribeEventAsync(Action<EventLightDto> eventCallback, CancellationToken cancellationToken)
        {
            await _substrateService.Events.SubscribeEventsAsync((BaseVec<EventRecord> eventsReceived) =>
            {
                foreach (EventRecord eventReceived in eventsReceived.Value)
                {
                    if (!eventReceived.Event.HasBeenMapped)
                    {
                        // Log
                        _logger.LogWarning($"Event unmapped : from {eventReceived.Event.CoreType.Name} to {eventReceived.Event.DestinationType.Name}");
                        continue;
                    }
                    try
                    {
                        _logger.LogInformation($"Event mapped : {eventReceived.Event.Value.Value}");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning($"Event Hexadecimal: {Utils.Bytes2HexString(eventReceived.Encode())}");
                        _logger.LogError($"Read event failed : {ex}");
                    }
                }
            }, cancellationToken);
        }



        public async Task<EventDto> GetEventAsync(uint blockId, uint eventIndex, CancellationToken cancellationToken)
            => await GetEventAsync(await _blockParameter.FromBlockNumberAsync(blockId), eventIndex, cancellationToken);

        public Task<EventDto> GetEventAsync(string blockHash, uint eventIndex, CancellationToken cancellationToken)
            => GetEventAsync(_blockParameter.FromBlockHash(blockHash), eventIndex, cancellationToken);

        public Task<EventDto> GetEventAsync(Hash blockHash, uint eventIndex, CancellationToken cancellationToken)
            => GetEventAsync(_blockParameter.FromBlockHash(blockHash), eventIndex, cancellationToken);

        public async Task<EventDto> GetEventAsync(BlockParameterLike block, uint eventIndex, CancellationToken cancellationToken)
        {
            var blockHash = await block.ToBlockHashAsync();
            var events = await _substrateService.At(blockHash).Storage.System.EventsAsync(cancellationToken);

            var eventNode = _substrateDecode.DecodeEvent(events.Value[(int)eventIndex]);

            return _modelBuilder.BuildEventDto(
                    await GetBlockLightAsync(blockHash, cancellationToken),
                    eventNode);
        }

        public IEnumerable<EventRecord> FindEvent(
            BaseVec<EventRecord> events,
            RuntimeEvent palletName,
            Enum eventName)
        {
            foreach (var ev in events.Value)
            {
                var eventNode = _substrateDecode.DecodeEvent(ev);
                if (eventNode.Module.ToString() == palletName.ToString() &&
                eventNode.Method.ToString() == eventName.ToString())
                {
                    yield return ev;
                }
            }
        }

        public async Task SubscribeSpecificEventAsync(RuntimeEvent palletName, Enum eventName, Action<EventRecord> callback, CancellationToken token)
        {
            await _substrateService.Events.SubscribeEventsAsync((BaseVec<EventRecord> events) =>
            {
                FindEvent(events, palletName, eventName)
                .ToList()
                .ForEach(ev => callback(ev));
            }, token);
        }

        //public async Task SubscribeSpecificEventAsync(RuntimeEvent palletName, Enum eventName, Func<EventRecord, Task> callback, ListenerFilter filter, CancellationToken token)
        //{
        //    // Todo
        //}

        public async Task<ExtrinsicDto> GetExtrinsicAsync(uint blockId, uint extrinsicIndex, CancellationToken cancellationToken) 
            => await GetExtrinsicAsync(await _blockParameter.FromBlockNumberAsync(blockId), extrinsicIndex, cancellationToken);

        public Task<ExtrinsicDto> GetExtrinsicAsync(string blockHash, uint extrinsicIndex, CancellationToken cancellationToken)
            => GetExtrinsicAsync(_blockParameter.FromBlockHash(blockHash), extrinsicIndex, cancellationToken);

        public Task<ExtrinsicDto> GetExtrinsicAsync(Hash blockHash, uint extrinsicIndex, CancellationToken cancellationToken)
            => GetExtrinsicAsync(_blockParameter.FromBlockHash(blockHash), extrinsicIndex, cancellationToken);

        public Task<ExtrinsicDto> GetExtrinsicAsync(BlockParameterLike block, uint extrinsicIndex, CancellationToken cancellationToken)
        {
            var blockHash = block.ToBlockHashAsync();
            //TODO
            throw new NotImplementedException();
        }

        public async Task<(BlockNumber blockNumber, Hash blockHash, BlockData blockDetails)> ExtractInformationsFromHeaderAsync(Header header, CancellationToken token)
        {
            if (header == null) throw new ArgumentNullException("header");

            var blockNumber = new BlockNumber();
            blockNumber.Create((uint)header.Number.Value);

            var blockHash = await _substrateService.Rpc.Chain.GetBlockHashAsync(blockNumber, token);

            if (blockHash == null)
                throw new BlockException($"{nameof(blockHash)} from given blockId (={blockNumber.Value}) is null");

            var blockDetails = await _substrateService.Rpc.Chain.GetBlockAsync(blockHash, token);

            if (blockDetails == null)
                throw new BlockException($"{blockDetails} for block hash = {blockHash.Value} is null");

            return (blockNumber, blockHash, blockDetails);
        }
    }
}
