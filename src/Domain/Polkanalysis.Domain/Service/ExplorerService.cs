using Substrate.NetApi;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Dto.Event;
using Polkanalysis.Domain.Contracts.Exception;
using Polkanalysis.Domain.Contracts.Dto.Extrinsic;
using Substrate.NetApi.Model.Extrinsics;
using Polkanalysis.Domain.Contracts.Dto;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Adapter.Block;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Babe.Enums;
using Substrate.NET.Utils;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Babe;
using Ardalis.GuardClauses;
using Polkanalysis.Domain.Helper;
using Polkanalysis.Domain.Contracts.Dto.Logs;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.DispatchInfo;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Error;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Display;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime;
using Polkanalysis.Domain.Helper.Enumerables;
using Substrate.NetApi.Model.Meta;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.ExtrinsicTmp;

namespace Polkanalysis.Domain.Service
{
    public class ExplorerService : IExplorerService
    {
        private readonly ISubstrateService _substrateService;
        private readonly ICoreService _coreService;
        private readonly ISubstrateDecoding _substrateDecode;
        private readonly IAccountService _accountRepository;
        private readonly ILogger<ExplorerService> _logger;
        private BlockLightDto? _lastBlock;

        public ExplorerService(
            ISubstrateService substrateNodeRepository,
            ISubstrateDecoding substrateDecode,
            IAccountService accountRepository,
            ILogger<ExplorerService> logger,
            ICoreService coreService)
        {
            _substrateService = substrateNodeRepository;
            _substrateDecode = substrateDecode;
            _accountRepository = accountRepository;
            _logger = logger;
            _coreService = coreService;
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
                throw new NotImplementedException("Need to implement Aura concensus !");
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
        public static bool IsBabeConcensus(Nameable nameable) => nameable.Display() == "BABE";
        public static bool IsAuraConcensus(Nameable nameable) => nameable.Display() == "aura";
        public static bool IsPowConcensus(Nameable nameable) => nameable.Display() == "pow_";
        public static bool IsNimbusConcensus(Nameable nameable) => nameable.Display() == "nmbs";
        public static bool IsGranPaConcensus(Nameable nameable) => nameable.Display() == "FRNK";

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

            if (blockData == null)
                throw new BlockException($"{blockData} for block hash = {blockHash.Value} is null");

            var (blockDate, eventsCount, blockAuthor) = await WaiterHelper.WaitAndReturnAsync(
                _coreService.GetDateTimeFromTimestampAsync(blockHash, cancellationToken),
                _substrateService.At(blockHash).Storage.System.EventCountAsync(cancellationToken),
                GetBlockAuthorAsync(block, cancellationToken));

            // I get the last finalized head (i.e. validate by granpa finality) and assume that every block ahead are not
            // finalized
            var (lastFinalizedBlockHash, authorIdentity) = await WaiterHelper.WaitAndReturnAsync(
                _substrateService.Rpc.Chain.GetFinalizedHeadAsync(cancellationToken),
                _accountRepository.GetAccountIdentityAsync(blockAuthor, cancellationToken));

            var finalizedBlockData = await _substrateService.Rpc.Chain.GetBlockAsync(lastFinalizedBlockHash, cancellationToken);
            var currentBlockStatus = blockData.GetBlock().Header.Number.Value <= finalizedBlockData.GetBlock().Header.Number.Value ? GlobalStatusDto.BlockStatusDto.Finalized : GlobalStatusDto.BlockStatusDto.Broadcasted;

            return new BlockLightDto()
            {
                Hash = blockHash,
                Number = (uint)blockData.GetBlock().Header.Number.Value,
                Status = currentBlockStatus,
                NbExtrinsics = (uint)blockData.GetBlock().GetExtrinsics().Length,
                NbEvents = eventsCount.Value,
                NbLogs = (uint)blockData.GetBlock().Header.Digest.Logs.Count,
                When = ModelBuilder.DisplayElapsedTime(blockDate),
                BlockDate = blockDate,
                ValidatorIdentity = authorIdentity,
                ValidatorAddress = authorIdentity.Address,
                Justification = blockData.Justification?.ToString()
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
            var currentDateTask = _coreService.GetDateTimeFromTimestampAsync(blockHash, cancellationToken);
            var eventsCountTask = _substrateService.At(blockHash).Storage.System.EventCountAsync(cancellationToken);
            var blockExecutionPhaseTask = _substrateService.At(blockHash).Storage.System.ExecutionPhaseAsync(cancellationToken);
            var specVersionTask = _substrateService.Rpc.State.GetRuntimeVersionAsync(blockHash.Bytes, cancellationToken);
            var eventsTask = _substrateService.At(blockHash).Storage.System.EventsAsync(cancellationToken);
            var metadataWithVersionTask = _substrateService.At(blockHash).GetMetadataWithVersionAsync(CancellationToken.None);
            var (currentDate, eventsCount, blockExecutionPhase, specVersion, blockDetails, blockEvents, metadataWithVersion) = await WaiterHelper.WaitAndReturnAsync(currentDateTask, eventsCountTask, blockExecutionPhaseTask, specVersionTask, blockDetailsTask, eventsTask, metadataWithVersionTask);

            if (blockDetails == null)
                throw new BlockException($"{blockDetails} for block hash = {blockHash.Value} is null");

            var extrinsicsList = blockDetails.GetBlock().GetExtrinsics().ToList();
            
            //foreach (var extrinsic in extrinsicsList)
            //{
            //    var extrinsicDecode = await _substrateDecode.DecodeExtrinsicAsync(extrinsic, metadata, cancellationToken);
            //}

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
            var authorIdentity = await _accountRepository.GetAccountIdentityAsync(blockAuthor, cancellationToken);
            var header = blockDetails.GetBlock().Header;

            var blockDto = new BlockDto()
            {
                Date = ModelBuilder.BuildDateDto(currentDate),
                ExtrinsicsRoot = header.ExtrinsicsRoot.Value,
                ParentHash = header.ParentHash.Value,
                StateRoot = header.StateRoot.Value,
                Number = header.Number.Value,
                Hash = blockHash.Value,
                Status = status,
                NbExtrinsics = (uint)blockDetails.GetBlock().GetExtrinsics().Length,
                NbEvents = eventsCount is not null ? eventsCount.Value : default,
                NbLogs = (uint)header.Digest.Logs.Count,
                SpecVersion = specVersion is not null ? specVersion.SpecVersion : default,
                Validator = authorIdentity,
                MetadataMajorVersion = metadataWithVersion.majorVersion
            };

            return blockDto;
        }

        public async Task<LifetimeDto?> GetExtrinsicsLifetimeAsync(uint blockNumber, IExtrinsic extrinsic, CancellationToken cancellationToken)
        {
            if(extrinsic.Era is null) return null;

            var result = new LifetimeDto();
            result.IsImmortal = extrinsic.Era.IsImmortal;
            
            if(!result.IsImmortal)
            {
                result.FromBlock = (uint)extrinsic.Era.EraStart(blockNumber);
                result.ToBlock = (uint)extrinsic.Era.EraStart(blockNumber) + (uint)extrinsic.Era.Period;

                return result;
            }
            return result;
        }

        /// <summary>
        /// Return the fees paid for this extrinsic
        /// </summary>
        /// <param name="events"></param>
        /// <param name="extrinsicIndex"></param>
        /// <returns></returns>
        public async Task<double?> GetExtrinsicsFeesAsync(EventRecord[] events, int extrinsicIndex, CancellationToken cancellationToken)
        {
            IEnumerable<EventRecord> eventLinkedToCurrentExtrinsic = getEventsLinkedToExtrinsic(events, extrinsicIndex);

            foreach (var feedPaidEvent in eventLinkedToCurrentExtrinsic)
            {
                if (feedPaidEvent.Event.Value is null) continue;

                if (feedPaidEvent.Event.Value!.Value == RuntimeEvent.TransactionPayment)
                {
                    var systemEventValue = feedPaidEvent.Event.Value!.Value2.GetValue<Infrastructure.Blockchain.Contracts.Pallet.TransactionPayment.Enums.Event>();

                    if (systemEventValue == Infrastructure.Blockchain.Contracts.Pallet.TransactionPayment.Enums.Event.TransactionFeePaid)
                    {
                        var feeBig = feedPaidEvent.Event.Value!.Value2.GetValue2().As<BaseTuple<SubstrateAccount, U128, U128>>().Value[1].As<U128>();
                        var chainInfo = await _substrateService.Rpc.System.PropertiesAsync(cancellationToken);

                        return feeBig.ToDouble(chainInfo.TokenDecimals);
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Return the status of an extrinsic
        /// </summary>
        /// <param name="events"></param>
        /// <param name="extrinsicIndex"></param>
        /// <returns></returns>
        public async Task<ExtrinsicStatusDto> GetExtrinsicsStatusAsync(EventRecord[] events, int extrinsicIndex, CancellationToken cancellationToken)
        {
            IEnumerable<EventRecord> eventLinkedToCurrentExtrinsic = getEventsLinkedToExtrinsic(events, extrinsicIndex);

            foreach (var systemEvent in eventLinkedToCurrentExtrinsic)
            {
                if (systemEvent.Event.Value is null) continue;

                //var decode = await _substrateDecode.DecodeEventAsync(systemEvent, cancellationToken);
                if (systemEvent.Event.Value!.Value == RuntimeEvent.System)
                {
                    var systemEventValue = systemEvent.Event.Value!.Value2.GetValue<Event>();

                    if (systemEventValue == Event.ExtrinsicSuccess)
                        return ExtrinsicStatusDto.Success();

                    if (systemEventValue == Event.ExtrinsicFailed)
                    {
                        var enumError = systemEvent.Event.Value!.Value2.GetValue2().As<BaseTuple<EnumDispatchError, DispatchInfo>>().Value[0].As<EnumDispatchError>();
                        var documentation = MessageFromDispatchError(enumError);
                        return ExtrinsicStatusDto.Error(documentation);
                    }
                }
            }

            return ExtrinsicStatusDto.System();
        }

        /// <summary>
        /// Return events associated to the given extrinsic
        /// </summary>
        /// <param name="events">All the events from the block</param>
        /// <param name="extrinsicIndex">The extrinsic index position</param>
        /// <returns></returns>
        private static IEnumerable<EventRecord> getEventsLinkedToExtrinsic(EventRecord[] events, int extrinsicIndex)
        {
            return events.Where(e =>
            {
                if (e.Phase.Value == Phase.ApplyExtrinsic)
                {
                    var applyExtrinsicIndex = ((U32)e.Phase.Value2).Value;
                    return applyExtrinsicIndex == extrinsicIndex;
                }

                return false;
            });
        }

        private string MessageFromDispatchError(EnumDispatchError dispatchError)
        {
            switch (dispatchError.Value)
            {
                case DispatchError.Module:
                    var moduleError = (ModuleError)dispatchError.Value2;
                    return $"{dispatchError.Value};{(RuntimeEvent)moduleError.Index.Value};{moduleError.Index.Value};{Utils.Bytes2HexString(moduleError.Error.Value.ToBytes())}";

                case DispatchError.Token:
                    var enumTokenError = (EnumTokenError)dispatchError.Value2;
                    return $"{dispatchError.Value};{enumTokenError.Value}";

                case DispatchError.Arithmetic:
                    var enumArithmeticError = (EnumArithmeticError)dispatchError.Value2;
                    return $"{dispatchError.Value};{enumArithmeticError.Value}";

                case DispatchError.Transactional:
                    var enumTransactionalError = (EnumTransactionalError)dispatchError.Value2;
                    return $"{dispatchError.Value};{enumTransactionalError.Value}";

                default:
                    return dispatchError.Value.ToString();
            }
        }

        

        public async Task<BlockLightDto?> GetLastBlockAsync(CancellationToken cancellationToken)
        {
            //var lastHeader = await _substrateService.Rpc.Chain.GetHeaderAsync(cancellationToken);
            //var (_, blockHash, _) = await ExtractInformationsFromHeaderAsync(lastHeader, cancellationToken);

            //return await GetBlockLightAsync(blockHash, cancellationToken);
            return (await GetLastBlocksAsync(1, cancellationToken)).SingleOrDefault();
        }

        /// <summary>
        /// Return the last N finalized blocks
        /// </summary>
        /// <param name="nbBlock"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
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
            var (events, blockNumber, metadata) = await WaiterHelper.WaitAndReturnAsync(
                _substrateService.At(blockHash).Storage.System.EventsAsync(cancellationToken),
                block.ToBlockNumberAsync(_substrateService),
                _substrateService.At(blockHash).GetMetadataAsync(CancellationToken.None));

            var eventsList = events.Value.ToList();

            var eventsDto = new List<EventDto>();

            var eventsWithNode = await eventsList.ExtendWith(ev => _substrateDecode.DecodeEventAsync(ev, metadata, cancellationToken))
                .WaitAllAndGetResultAsync();

            foreach (var item in eventsWithNode)
            {
                var index = (uint)eventsList.IndexOf(item.Item1);
                try
                {
                    eventsDto.Add(
                    ModelBuilder.BuildEventDto(
                        blockNumber,
                        item.Item2,
                        index,
                        GetExtrinsicIndexFromEvent(item.Item1))
                    );
                } catch(Exception ex)
                {
                    _logger.LogError(ex, $"Error while processing event num {index}");
                }
                
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
            var (blockHash, blockNumber) = await WaiterHelper.WaitAndReturnAsync(
                block.ToBlockHashAsync(_substrateService), 
                block.ToBlockNumberAsync(_substrateService));

            var (blockDetails, metadata, events) = await WaiterHelper.WaitAndReturnAsync(
                _substrateService.Rpc.Chain.GetBlockAsync(blockHash, cancellationToken),
                _substrateService.At(blockHash).GetMetadataAsync(cancellationToken),
                _substrateService.At(blockHash).Storage.System.EventsAsync(cancellationToken));

            if (blockDetails is null)
                throw new BlockException($"{blockDetails} for block hash = {blockHash.Value} is null");

            var extrinsicsDto = new List<ExtrinsicDto>();
            var extrinsics = blockDetails.GetBlock().GetExtrinsics().ToList();

            List<Task> extrinsicsBuilderTask = new();
            foreach (var extrinsic in extrinsics)
            {
                extrinsicsBuilderTask.Add(buildExtrinsicInnerAsync(blockHash, blockNumber, metadata, events, extrinsicsDto, extrinsics, extrinsic, cancellationToken));
            }

            await Task.WhenAll(extrinsicsBuilderTask);

            return extrinsicsDto;
        }

        private async Task buildExtrinsicInnerAsync(Hash blockHash, BlockNumber blockNumber, MetaData metadata, BaseVec<EventRecord> events, List<ExtrinsicDto> extrinsicsDto, List<IExtrinsic> extrinsics, IExtrinsic extrinsic, CancellationToken cancellationToken)
        {
            var extrinsicIndex = (uint)extrinsics.ToList().IndexOf(extrinsic);
            UserIdentityDto? caller = null;
            if (extrinsic.Account is not null)
                caller = await _accountRepository.At(blockHash.Value).GetAccountIdentityAsync(extrinsic.Account.Value, cancellationToken);

            var (extrinsicNode, fees, status, lifetime) = await WaiterHelper.WaitAndReturnAsync(
                _substrateDecode.DecodeExtrinsicAsync(extrinsic, metadata, cancellationToken),
                GetExtrinsicsFeesAsync(events, (int)extrinsicIndex, cancellationToken),
                GetExtrinsicsStatusAsync(events, (int)extrinsicIndex, cancellationToken),
                GetExtrinsicsLifetimeAsync(blockNumber, extrinsic, cancellationToken));

            extrinsicsDto.Add(
                new ExtrinsicDto()
                {
                    BlockNumber = blockNumber,
                    //Hash = Utils.Bytes2HexString(extrinsic.Encode()),
                    JsonParameters = extrinsicNode.ToJson(),
                    ExtrinsicId = $"{blockNumber}-{extrinsicIndex}",
                    Index = extrinsicIndex,
                    PalletName = extrinsicNode.Name,
                    CallEventName = extrinsicNode.Children[0].Name,
                    Caller = caller,
                    EstimatedFees = fees,
                    Lifetime = lifetime,
                    Nonce = extrinsic.Nonce,
                    RealFees = fees,
                    Status = status
                });
        }

        /// <summary>
        /// Return the extrinsic index link to this event
        /// </summary>
        /// <param name="eventRecord"></param>
        /// <returns></returns>
        public static uint? GetExtrinsicIndexFromEvent(EventRecord eventRecord)
        {
            if (eventRecord.Phase.Value == Phase.ApplyExtrinsic)
            {
                return ((U32)eventRecord.Phase.Value2).Value;
            }

            return null;
        }

        public async Task<IEnumerable<EventDto>?> GetEventsLinkedToExtrinsicsAsync(
            ExtrinsicDto extrinsicDto,
            CancellationToken cancellationToken)
        {
            var block = new BlockParameterLike(extrinsicDto.BlockNumber);

            var blockDetails = await _substrateService.Rpc.Chain.GetBlockAsync(
                await block.ToBlockHashAsync(_substrateService), cancellationToken);
            if (blockDetails == null)
                throw new BlockException($"{blockDetails} for block number = {extrinsicDto.BlockNumber} is null");

            return await GetEventsLinkedToExtrinsicsAsync(extrinsicDto, blockDetails.GetBlock().GetExtrinsics(), cancellationToken);
        }

        public async Task<IEnumerable<EventDto>?> GetEventsLinkedToExtrinsicsAsync(
            ExtrinsicDto extrinsicDto,
            IEnumerable<IExtrinsic> extrinsics,
            CancellationToken cancellationToken)
        {
            var blockLight = await GetBlockLightAsync(extrinsicDto.BlockNumber, cancellationToken);

            // Return every events linked to this block
            var events = (await _substrateService.At(extrinsicDto.BlockNumber).Storage.System.EventsAsync(cancellationToken)).Value.ToList();

            // Doc here :
            // https://polkadot.js.org/docs/api/cookbook/blocks#how-do-i-map-extrinsics-to-their-events
            // Event Phase must be "Apply extrinsic" dans his value must be equal to extrinsic index
            IEnumerable<EventRecord> eventLinkedToCurrentExtrinsic = events.Where(e =>
            {
                if (e.Phase.Value == Phase.ApplyExtrinsic)
                {
                    var applyExtrinsicIndex = ((U32)e.Phase.Value2).Value;
                    return applyExtrinsicIndex == extrinsicDto.Index;
                }
                return false;
            });

            var eventsLinkedDto = new List<EventDto>();
            foreach (var eventLinked in eventLinkedToCurrentExtrinsic)
            {
                var e = ModelBuilder.BuildEventDto(
                    extrinsicDto.BlockNumber,
                    await _substrateDecode.DecodeEventAsync(eventLinked, cancellationToken),
                    (uint)events.IndexOf(eventLinked),
                    extrinsicDto.Index);
                eventsLinkedDto.Add(e);
            }

            return eventsLinkedDto;
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
            var (blockHash, blockNumber) = await WaiterHelper.WaitAndReturnAsync(block.ToBlockHashAsync(_substrateService), block.ToBlockNumberAsync(_substrateService));
            var events = (await _substrateService.At(blockHash).Storage.System.EventsAsync(cancellationToken)).Value.ToList();

            var selectedEvent = events[(int)eventIndex];
            var eventNode = await _substrateDecode.DecodeEventAsync(selectedEvent, cancellationToken);

            return ModelBuilder.BuildEventDto(
                    blockNumber,
                    eventNode,
                    eventIndex,
                    GetExtrinsicIndexFromEvent(selectedEvent));
        }

        public async Task<IEnumerable<EventRecord>> FindEventAsync(BaseVec<EventRecord> events, MetaData metadata, RuntimeEvent palletName, Enum eventName, CancellationToken token)
        {
            var eventsFiltered = new List<EventRecord>();
            foreach (var ev in events.Value)
            {
                var eventNode = await _substrateDecode.DecodeEventAsync(ev, metadata, token);
                if (eventNode.Module.ToString() == palletName.ToString() &&
                eventNode.Method.ToString() == eventName.ToString())
                {
                    eventsFiltered.Add(ev);
                }
            }

            return eventsFiltered;
        }


        public async Task SubscribeSpecificEventAsync(RuntimeEvent palletName, Enum eventName, MetaData metadata, Action<EventRecord> callback, CancellationToken token)
        {
            await _substrateService.Events.SubscribeEventsAsync((events) =>
            {
                FindEventAsync(events, metadata, palletName, eventName, token).Result
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

        public async Task<(BlockNumber blockNumber, Hash blockHash, IBlockData blockDetails)> ExtractInformationsFromHeaderAsync(Header header, CancellationToken token)
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
