using Substrate.NetApi;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Dto.Event;
using Polkanalysis.Domain.Contracts.Exception;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Dto.Extrinsic;
using Substrate.NetApi.Model.Extrinsics;
using Polkanalysis.Domain.Contracts.Dto;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Adapter.Block;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Polkanalysis.Domain.Contracts.Core.Display;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Babe.Enums;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Babe;
using Ardalis.GuardClauses;
using Polkanalysis.Domain.Helper;
using Polkanalysis.Domain.Contracts.Dto.Logs;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;

namespace Polkanalysis.Domain.Service
{
    public class ExplorerService : IExplorerService
    {
        private readonly ISubstrateService _substrateService;
        private readonly ISubstrateDecoding _substrateDecode;
        private readonly IModelBuilder _modelBuilder;
        private readonly IAccountService _accountRepository;
        private readonly ILogger<ExplorerService> _logger;
        private BlockLightDto? _lastBlock;
        //private BlockParameterLike _blockParameter;

        public ExplorerService(
            ISubstrateService substrateNodeRepository,
            ISubstrateDecoding substrateDecode,
            IModelBuilder modelBuilder,
            IAccountService accountRepository,
            ILogger<ExplorerService> logger)
        {
            _substrateService = substrateNodeRepository;
            _substrateDecode = substrateDecode;
            _modelBuilder = modelBuilder;
            _accountRepository = accountRepository;
            _logger = logger;

            //_blockParameter = new BlockParameterLike(_substrateService);
        }

        public async Task<SubstrateAccount> GetBlockAuthorAsync(uint blockId, CancellationToken cancellationToken)
            => await GetBlockAuthorAsync((BlockParameterLike)blockId, cancellationToken);

        /// <summary>
        /// Return the validator block
        /// 
        /// Sources :
        /// https://github.com/polkadot-js/api/blob/master/packages/api-derive/src/chain/util.ts
        /// https://github.com/polkadot-js/api/blob/master/packages/api-derive/src/type/util.ts
        /// https://github.com/polkadot-js/api/blob/master/packages/types/src/generic/ConsensusEngineId.ts
        /// </summary>
        /// <param name="blockHash"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected async Task<SubstrateAccount> GetBlockAuthorAsync(BlockParameterLike block, CancellationToken cancellationToken)
        {
            var blockHash = await block.ToBlockHashAsync(_substrateService);

            // Get validators from given block
            var blockValidators = await _substrateService.At(blockHash).Storage.Session.ValidatorsAsync(cancellationToken);
            if (blockValidators is null)
                throw new InvalidOperationException($"Error while fetching validators for block {blockHash}");

            var blockHeader = await _substrateService.Rpc.Chain.GetHeaderAsync(blockHash, cancellationToken);

            var digestLogs = blockHeader.Digest.Logs.Select(log =>
            {
                var buildLog = new EnumDigestItem();
                buildLog.Create(log);
                return buildLog;
            });

            SubstrateAccount? blockAuthor = null;
            var preruntime = digestLogs.FirstOrDefault(x => x.Value == DigestItem.PreRuntime);
            var consensus = digestLogs.FirstOrDefault(x => x.Value == DigestItem.Consensus);
            var seal = digestLogs.FirstOrDefault(x => x.Value == DigestItem.Seal);

            if (preruntime != null)
            {
                (Nameable name, BaseVec<U8> data) = BuildAuthorData(preruntime);
                blockAuthor = extractAuthor(name, data.Value.ToBytes(), blockValidators);
            }

            if (blockAuthor == null && consensus != null)
            {
                (Nameable name, BaseVec<U8> data) = BuildAuthorData(consensus);
                blockAuthor = extractAuthor(name, data.Value.ToBytes(), blockValidators);
            }

            if (blockAuthor == null && seal != null)
            {
                (Nameable name, BaseVec<U8> data) = BuildAuthorData(seal);
                blockAuthor = extractAuthor(name, data.Value.ToBytes(), blockValidators);
            }

            if (blockAuthor != null)
                return blockAuthor;

            throw new InvalidOperationException($"Unable to retrieve validator from block num {await block.ToBlockNumberAsync(_substrateService)}");

            static (Nameable name, BaseVec<U8> data) BuildAuthorData(EnumDigestItem digestItem)
            {
                var castedValue = (BaseTuple<NameableSize4, BaseVec<U8>>)digestItem.Value2;
                return ((Nameable)castedValue.Value[0], (BaseVec<U8>)castedValue.Value[1]);
            }
        }

        private SubstrateAccount? extractAuthor(Nameable name, byte[] data, BaseVec<SubstrateAccount> blockValidators)
        {
            if (IsBabeConcensus(name))
            {
                var preDigest = new EnumPreDigest();
                preDigest.Create(data);

                U32? authorityIndex = preDigest.Value switch
                {
                    PreDigest.Primary => ((PrimaryPreDigest)preDigest.Value2).AuthorityIndex,
                    PreDigest.SecondaryPlain => ((SecondaryPlainPreDigest)preDigest.Value2).AuthorityIndex,
                    PreDigest.SecondaryVRF => ((SecondaryVRFPreDigest)preDigest.Value2).AuthorityIndex,
                    _ => null
                };

                if (authorityIndex == null) return null;
                return blockValidators.Value[authorityIndex.Value];
            }
            else if (IsAuraConcensus(name))
            {
                // Call Aura PreDigest
                // ConsensusEngineId.ts
                return null;
            }
            // For pow & Nimbus, the bytes are the actual author
            else if (IsPowConcensus(name) || IsNimbusConcensus(name))
            {
                var validatorAccount = new SubstrateAccount();
                validatorAccount.Create(data);

                return validatorAccount;
            }

            return null;
        }

        /// <summary>
        /// https://github.com/polkadot-js/api/blob/master/packages/types/src/generic/ConsensusEngineId.ts#L11
        /// </summary>
        /// <returns></returns>
        public bool IsBabeConcensus(Nameable nameable) => nameable.Display() == "BABE";
        public bool IsAuraConcensus(Nameable nameable) => nameable.Display() == "aura";
        public bool IsPowConcensus(Nameable nameable) => nameable.Display() == "pow_";
        public bool IsNimbusConcensus(Nameable nameable) => nameable.Display() == "nmbs";
        public bool IsGranPaConcensus(Nameable nameable) => nameable.Display() == "FRNK";

        public async Task<BlockLightDto> GetBlockLightAsync(uint blockId, CancellationToken cancellationToken)
            => await GetBlockLightAsync(new BlockParameterLike(blockId), cancellationToken);

        public Task<BlockLightDto> GetBlockLightAsync(string blockHash, CancellationToken cancellationToken)
            => GetBlockLightAsync(new BlockParameterLike(blockHash), cancellationToken);

        public Task<BlockLightDto> GetBlockLightAsync(Hash blockHash, CancellationToken cancellationToken)
            => GetBlockLightAsync(new BlockParameterLike(blockHash), cancellationToken);
        protected async Task<BlockLightDto> GetBlockLightAsync(BlockParameterLike block, CancellationToken cancellationToken)
        {
            var blockHash = await block.ToBlockHashAsync(_substrateService);
            var blockData = await _substrateService.Rpc.Chain.GetBlockAsync(blockHash, cancellationToken);

            //_logger.LogInformation($"Block hash = {blockHash} / Block num = {blockData.Block.Header.Number}");
            if (blockData == null)
                throw new BlockException($"{blockData} for block hash = {blockHash.Value} is null");

            var blockDateTask = GetDateTimeFromTimestampAsync(blockHash, cancellationToken);
            var eventsCountTask = _substrateService.At(blockHash).Storage.System.EventCountAsync(cancellationToken);
            var blockAuthorTask = GetBlockAuthorAsync(block, cancellationToken);

            var (blockDate, eventsCount, blockAuthor) = await WaiterHelper.WaitAndReturnAsync(blockDateTask, eventsCountTask, blockAuthorTask);

            var authorIdentity = await _accountRepository.GetAccountAddressAsync(blockAuthor, cancellationToken);

            // I get the last finalized head (i.e. validate by granpa finality) and assume that every block ahead are not
            // finalized
            var lastFinalizedBlockHash = await _substrateService.Rpc.Chain.GetFinalizedHeadAsync(cancellationToken);
            var finalizedBlockData = await _substrateService.Rpc.Chain.GetBlockAsync(lastFinalizedBlockHash, cancellationToken);
            var currentBlockStatus = blockData.Block.Header.Number.Value <= finalizedBlockData.Block.Header.Number.Value ? GlobalStatusDto.BlockStatusDto.Finalized : GlobalStatusDto.BlockStatusDto.Broadcasted;

            return new BlockLightDto()
            {
                Hash = blockHash,
                Number = blockData.Block.Header.Number.Value,
                Status = currentBlockStatus,
                NbExtrinsics = (uint)blockData.Block.Extrinsics.Length,
                NbEvents = eventsCount.Value,
                NbLogs = (uint)blockData.Block.Header.Digest.Logs.Count,
                When = _modelBuilder.DisplayElapsedTime(blockDate),
                Validator = authorIdentity
            };
        }

        public async Task<BlockDto> GetBlockDetailsAsync(uint blockId, CancellationToken cancellationToken) => await GetBlockDetailsAsync(new BlockParameterLike(blockId), cancellationToken);

        public Task<BlockDto> GetBlockDetailsAsync(string blockHash, CancellationToken cancellationToken)
            => GetBlockDetailsAsync(new BlockParameterLike(blockHash), cancellationToken);

        public Task<BlockDto> GetBlockDetailsAsync(Hash blockHash, CancellationToken cancellationToken)
            => GetBlockDetailsAsync(new BlockParameterLike(blockHash), cancellationToken);

        protected async Task<BlockDto> GetBlockDetailsAsync(BlockParameterLike block, CancellationToken cancellationToken)
        {
            var blockHash = await block.ToBlockHashAsync(_substrateService);
            var blockDetailsTask = _substrateService.Rpc.Chain.GetBlockAsync(blockHash, cancellationToken);

            var currentDateTask = GetDateTimeFromTimestampAsync(blockHash, cancellationToken);
            var eventsCountTask = _substrateService.At(blockHash).Storage.System.EventCountAsync(cancellationToken);
            var blockExecutionPhaseTask = _substrateService.At(blockHash).Storage.System.ExecutionPhaseAsync(cancellationToken);
            var specVersionTask = _substrateService.Rpc.State.GetRuntimeVersionAtAsync(blockHash.Value, cancellationToken);

            var (currentDate, eventsCount, blockExecutionPhase, specVersion, blockDetails) = await WaiterHelper.WaitAndReturnAsync(currentDateTask, eventsCountTask, blockExecutionPhaseTask, specVersionTask, blockDetailsTask);

            if (blockDetails == null)
                throw new BlockException($"{blockDetails} for block hash = {blockHash.Value} is null");

            var filteredExtrinsic = blockDetails.Block.Extrinsics.Where(e => e.Method.ModuleIndex != 54);
            //var filteredExtrinsic = blockDetails.Block.Extrinsics;
            foreach (var extrinsic in filteredExtrinsic)
            {
                var extrinsicDecode = _substrateDecode.DecodeExtrinsic(extrinsic);
            }

            var status = blockExecutionPhase is null ? GlobalStatusDto.BlockStatusDto.Finalized : blockExecutionPhase.Value switch
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

            var blockAuthor = await GetBlockAuthorAsync(block, cancellationToken);
            var authorIdentity = await _accountRepository.GetAccountAddressAsync(blockAuthor, cancellationToken);

            var blockDto = new BlockDto()
            {
                Date = _modelBuilder.BuildDateDto(currentDate),
                ExtrinsicsRoot = blockDetails.Block.Header.ExtrinsicsRoot.Value,
                ParentHash = blockDetails.Block.Header.ParentHash.Value,
                StateRoot = blockDetails.Block.Header.StateRoot.Value,
                Number = blockDetails.Block.Header.Number.Value,
                Hash = blockHash.Value,
                Status = status,
                NbExtrinsics = (uint)blockDetails.Block.Extrinsics.Length,
                NbEvents = eventsCount is not null ? eventsCount.Value : default,
                NbLogs = (uint)blockDetails.Block.Header.Digest.Logs.Count,
                SpecVersion = specVersion is not null ? specVersion.SpecVersion : default,
                Validator = authorIdentity,
            };

            return blockDto;
        }

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

        public async Task<DateTime> GetDateTimeFromTimestampAsync(uint? blockNum, CancellationToken cancellationToken)
        {
            var blockHash = blockNum is null ? null : (await _substrateService.Rpc.Chain.GetBlockHashAsync(new BlockNumber(blockNum.Value), CancellationToken.None));

            return await GetDateTimeFromTimestampAsync(blockHash, cancellationToken);
        }

        public async Task<BlockLightDto?> GetLastBlockAsync(CancellationToken cancellationToken)
        {
            //var lastHeader = await _substrateService.Rpc.Chain.GetHeaderAsync(cancellationToken);
            //var (_, blockHash, _) = await ExtractInformationsFromHeaderAsync(lastHeader, cancellationToken);

            //return await GetBlockLightAsync(blockHash, cancellationToken);
            return (await GetLastBlocksAsync(1, cancellationToken)).SingleOrDefault();
        }

        public async Task<IEnumerable<BlockLightDto>> GetLastBlocksAsync(int nbBlock, CancellationToken cancellationToken)
        {
            Guard.Against.NegativeOrZero(nbBlock, nameof(nbBlock));
            if (nbBlock > 1000)
                throw new ArgumentException($"{nameof(nbBlock)} should be lower than 1000 (currently : {nbBlock}");

            // We get the last produced block
            var lastHeader = await _substrateService.Rpc.Chain.GetHeaderAsync(cancellationToken);

            int lastBlockNumber = (int)lastHeader.Number.Value;

            var blocksTaskDto = new List<Task<BlockLightDto>>();
            for (var i = lastBlockNumber - nbBlock; i < lastBlockNumber; i++)
            {
                _logger.LogTrace($"Request data from block num {i}");
                blocksTaskDto.Add(GetBlockLightAsync((uint)i, cancellationToken));
            }

            var blocksDto = await Task.WhenAll(blocksTaskDto.ToArray());
            return blocksDto;
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
            => GetEventsAsync(new BlockParameterLike(blockHash), cancellationToken);

        public async Task<IEnumerable<EventDto>> GetEventsAsync(uint blockId, CancellationToken cancellationToken)
            => await GetEventsAsync(new BlockParameterLike(blockId), cancellationToken);

        public Task<IEnumerable<EventDto>> GetEventsAsync(Hash blockHash, CancellationToken cancellationToken)
            => GetEventsAsync(new BlockParameterLike(blockHash), cancellationToken);

        protected async Task<IEnumerable<EventDto>> GetEventsAsync(BlockParameterLike block, CancellationToken cancellationToken)
        {
            var blockHash = await block.ToBlockHashAsync(_substrateService);
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
            => GetExtrinsicsAsync(new BlockParameterLike(blockHash), cancellationToken);

        public async Task<IEnumerable<ExtrinsicDto>> GetExtrinsicsAsync(uint blockId, CancellationToken cancellationToken) => await GetExtrinsicsAsync(new BlockParameterLike(blockId), cancellationToken);

        public Task<IEnumerable<ExtrinsicDto>> GetExtrinsicsAsync(Hash blockHash, CancellationToken cancellationToken)
            => GetExtrinsicsAsync(new BlockParameterLike(blockHash), cancellationToken);

        public async Task<IEnumerable<ExtrinsicDto>> GetExtrinsicsAsync(BlockParameterLike block, CancellationToken cancellationToken)
        {
            var blockHash = await block.ToBlockHashAsync(_substrateService);
            var blockDetails = await _substrateService.Rpc.Chain.GetBlockAsync(blockHash, cancellationToken);
            
            if (blockDetails is null)
                throw new BlockException($"{blockDetails} for block hash = {blockHash.Value} is null");

            var extrinsicsDto = new List<ExtrinsicDto>();
            // blockDetails.Block.Extrinsics.Where(e => e.Method.ModuleIndex != 54)
            foreach (var extrinsic in blockDetails.Block.Extrinsics.Where(e => e.Method.ModuleIndex != 54))
            {
                var encodedExtrinsic = extrinsic.Encode();
                var hexExtrinsic = Utils.Bytes2HexString(encodedExtrinsic);
                var extrinsicHash = new Hash(hexExtrinsic);
                var extrinsicFromEncoded = new Extrinsic(hexExtrinsic, ChargeTransactionPayment.Default());
                //var extrinsicFromOfficial = new Extrinsic("0x280403000b207eba5c8501", ChargeTransactionPayment.Default());
                var isEqual = extrinsic.Equals(extrinsicFromEncoded);
                //var isEqual2 = extrinsic.Equals(extrinsicFromOfficial);

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
                    var applyExtrinsicIndex = ((U32)e.Phase.Value2).Value;
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
            await _substrateService.Events.SubscribeEventsAsync((eventsReceived) =>
            {
                foreach (EventRecord eventReceived in eventsReceived.Value)
                {
                    //if (!eventReceived.Event.HasBeenMapped)
                    //{
                    //    // Log
                    //    _logger.LogWarning($"Event unmapped : from {eventReceived.Event.CoreType.Name} to {eventReceived.Event.DestinationType.Name}");
                    //    continue;
                    //}
                    try
                    {
                        _logger.LogInformation($"Event mapped : {eventReceived.Event.Value}");
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
            => await GetEventAsync(new BlockParameterLike(blockId), eventIndex, cancellationToken);

        public Task<EventDto> GetEventAsync(string blockHash, uint eventIndex, CancellationToken cancellationToken)
            => GetEventAsync(new BlockParameterLike(blockHash), eventIndex, cancellationToken);

        public Task<EventDto> GetEventAsync(Hash blockHash, uint eventIndex, CancellationToken cancellationToken)
            => GetEventAsync(new BlockParameterLike(blockHash), eventIndex, cancellationToken);

        public async Task<EventDto> GetEventAsync(BlockParameterLike block, uint eventIndex, CancellationToken cancellationToken)
        {
            var blockHash = await block.ToBlockHashAsync(_substrateService);
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
            await _substrateService.Events.SubscribeEventsAsync((events) =>
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
            => await GetExtrinsicAsync(new BlockParameterLike(blockId), extrinsicIndex, cancellationToken);

        public Task<ExtrinsicDto> GetExtrinsicAsync(string blockHash, uint extrinsicIndex, CancellationToken cancellationToken)
            => GetExtrinsicAsync(new BlockParameterLike(blockHash), extrinsicIndex, cancellationToken);

        public Task<ExtrinsicDto> GetExtrinsicAsync(Hash blockHash, uint extrinsicIndex, CancellationToken cancellationToken)
            => GetExtrinsicAsync(new BlockParameterLike(blockHash), extrinsicIndex, cancellationToken);

        public Task<ExtrinsicDto> GetExtrinsicAsync(BlockParameterLike block, uint extrinsicIndex, CancellationToken cancellationToken)
        {
            var blockHash = block.ToBlockHashAsync(_substrateService);
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

        //public async Task<IEnumerable<BlockLightDto>> GetBlocksAsync(int nbLastBlocks, CancellationToken cancellationToken)
        //{
        //    Guard.Against.NegativeOrZero(nbLastBlocks);
        //    if (nbLastBlocks > 1000)
        //        throw new ArgumentException($"{nameof(nbLastBlocks)} should be lower than 1000 (currently : {nbLastBlocks}");

        //    var lastBlockNum = (await _substrateService.Rpc.Chain.GetBlockAsync()).Block.Header.Number.Value;

        //    var blockHash = await _substrateService.Rpc.Chain.GetBlockHashAsync(new BlockNumber((uint)lastBlockNum), cancellationToken);
        //    var bl = await GetBlockLightAsync(_blockParameter.FromBlockHash(blockHash), cancellationToken);
        //    return new List<BlockLightDto>() { bl };
        //    //var blocksHash = await Task.WhenAll(Enumerable.Range((int)lastBlockNum - nbLastBlocks, (int)lastBlockNum)
        //    //    .Select(x =>
        //    //{
        //    //    return _substrateService.Rpc.Chain.GetBlockHashAsync(new BlockNumber((uint)x));
        //    //}));

        //    //var blocksData = await Task.WhenAll(blocksHash.Select(hash =>
        //    //{
        //    //    return GetBlockLightAsync(_blockParameter.FromBlockHash(hash), cancellationToken);
        //    //}));

        //    //return blocksData;
        //}

        public async Task<IEnumerable<LogDto>> GetLogsAsync(uint blockId, CancellationToken cancellationToken)
        {
            var block = new BlockParameterLike(blockId);
            var blockHash = await block.ToBlockHashAsync(_substrateService);

            var blockHeader = await _substrateService.Rpc.Chain.GetHeaderAsync(blockHash, cancellationToken);

            var logsDto = new List<LogDto>();

            for (int i = 0; i < blockHeader.Digest.Logs.Count; i++)
            {
                var buildLog = new EnumDigestItem();
                buildLog.Create(blockHeader.Digest.Logs[i]);

                var digestCasted = (BaseTuple<NameableSize4, BaseVec<U8>>)buildLog.Value2;

                var logDto = new LogDto();
                logDto.BlockNumber = blockId;
                logDto.LogIndex = i;
                logDto.LogType = buildLog.Value;

                logDto.ConsensusName = ((Nameable)digestCasted.Value[0]).Display();
                logDto.DateHex = Utils.Bytes2HexString(((BaseVec<U8>)digestCasted.Value[1]).Value.ToBytes());

                logsDto.Add(logDto);
            }

            return logsDto;
        }
    }
}
