using Ajuna.NetApi;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;
using Blake2Core;
using Substats.Domain.Contracts;
using Substats.Domain.Contracts.Dto.Block;
using Substats.Domain.Contracts.Dto.Event;
using Substats.Domain.Contracts.Exception;
using Substats.Domain.Contracts.Secondary;
using Substats.Domain.Contracts.Runtime;
using Newtonsoft.Json.Linq;
using Microsoft.VisualStudio.Threading;
using System;
using System.Reflection.Metadata.Ecma335;
using Substats.Domain.Contracts.Dto.Extrinsic;
using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Types;
using System.Runtime.InteropServices;
using Substats.Domain.Contracts.Dto;
using System.Text;
using Microsoft.Extensions.Logging;
using Substats.Domain.Contracts.Dto.User;
using Substats.Domain.Contracts.Secondary.Repository;
using Substats.Domain.Adapter.Block;
using Substats.Domain.Contracts.Secondary.Pallet.System;
using Substats.Domain.Contracts.Helpers;

namespace Substats.Domain.Repository
{
    public class PolkadotExplorerRepository : IExplorerRepository
    {
        private readonly ISubstrateRepository _substrateService;
        private readonly ISubstrateDecoding _substrateDecode;
        private readonly IModelBuilder _modelBuilder;
        private readonly ILogger<PolkadotExplorerRepository> _logger;
        private BlockLightDto? _lastBlock;

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
        }

        private async Task<Hash> buildHashAsync(uint blockId, CancellationToken cancellationToken)
        {
            var blockNumber = new BlockNumber();
            blockNumber.Create(blockId);

            var blockHash = await _substrateService.Rpc.Chain.GetBlockHashAsync(blockNumber, cancellationToken);

            if (blockHash == null)
                throw new BlockException($"{nameof(blockHash)} from given blockId (={blockId}) is null");

            return blockHash;
        }

        private Hash buildHash(string hash)
        {
            var blockHash = new Hash();
            blockHash.Create(hash);

            if (hash == null)
                throw new InvalidOperationException($"blockHash = {hash} is not a valid hash");

            return blockHash;
        }

        public Task<BlockLightDto> GetBlockLightAsync(uint blockId, CancellationToken cancellationToken)
            => GetBlockLightAsync(new BlockParameterLike(blockId), cancellationToken);

        public Task<BlockLightDto> GetBlockLightAsync(string blockHash, CancellationToken cancellationToken)
            => GetBlockLightAsync(new BlockParameterLike(blockHash), cancellationToken);

        public Task<BlockLightDto> GetBlockLightAsync(Hash blockHash, CancellationToken cancellationToken)
            => GetBlockLightAsync(new BlockParameterLike(blockHash), cancellationToken);
        protected async Task<BlockLightDto> GetBlockLightAsync(BlockParameterLike block, CancellationToken cancellationToken)
        {
            var blockHash = block.ToBlockHash();
            var blockData = await _substrateService.Rpc.Chain.GetBlockAsync(blockHash, cancellationToken);
            if (blockData == null)
                throw new BlockException($"{blockData} for block hash = {blockHash.Value} is null");

            var blockDate = await GetDateTimeFromTimestampAsync(blockHash, cancellationToken);

            return _modelBuilder.BuildBlockLightDto(blockHash, blockData, blockDate);
        }

        public Task<BlockDto> GetBlockDetailsAsync(uint blockId, CancellationToken cancellationToken)
            => GetBlockDetailsAsync(new BlockParameterLike(blockId), cancellationToken);

        public Task<BlockDto> GetBlockDetailsAsync(string blockHash, CancellationToken cancellationToken)
            => GetBlockDetailsAsync(new BlockParameterLike(blockHash), cancellationToken);

        public Task<BlockDto> GetBlockDetailsAsync(Hash blockHash, CancellationToken cancellationToken)
            => GetBlockDetailsAsync(new BlockParameterLike(blockHash), cancellationToken);

        protected async Task<BlockDto> GetBlockDetailsAsync(BlockParameterLike block, CancellationToken cancellationToken)
        {
            var blockHash = block.ToBlockHash();
            var blockDetails = await _substrateService.Rpc.Chain.GetBlockAsync(blockHash, cancellationToken);
            if (blockDetails == null)
                throw new BlockException($"{blockDetails} for block hash = {blockHash.Value} is null");

            var currentDate = await GetDateTimeFromTimestampAsync(blockHash, cancellationToken);

            //var eventsCount = await _substrateService.Api.Core.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U32>(SystemStorage.EventCountParams(), blockHash.Value, cancellationToken);
            var eventsCount = await _substrateService.At(blockHash).Storage.System.EventCountAsync(cancellationToken);

            //var blockExecutionPhase = await _substrateService.Api.Core.GetStorageAsync<EnumPhase>(SystemStorage.ExecutionPhaseParams(), blockHash.Value, cancellationToken);
            var blockExecutionPhase = await _substrateService.At(blockHash).Storage.System.ExecutionPhaseAsync(cancellationToken);

            //var blockAuthor = await _substrateService.Client.Core.GetStorageAsync<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>(AuthorshipStorage.AuthorParams(), blockHash.Value, cancellationToken);
            //var blockAuthor2 = await _substrateService.Client.Core.GetStorageAsync<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>(AuthorshipStorage.AuthorParams(), cancellationToken);

            //var staking = await _substrateService.Client.GetStorageAsync<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>(
            //    AuthorshipStorage.AuthorParams(), blockhash, cancellationToken);

            var filteredExtrinsic = blockDetails.Block.Extrinsics.Where(e => e.Method.ModuleIndex != 54);
            //var filteredExtrinsic = blockDetails.Block.Extrinsics;
            foreach (var extrinsic in filteredExtrinsic)
            {
                var extrinsicDecode = _substrateDecode.DecodeExtrinsic(extrinsic);
            }


            //var digest = await _substrateService.Client.SystemStorage.Digest(cancellationToken);

            // BaseTuple<Substats.Polkadot.NetApiExt.Generated.Types.Base.Arr4U8, Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>

            //var digest = await _substrateService.Api.Core.GetStorageAsync<Substats.Polkadot.NetApiExt.Generated.Model.sp_runtime.generic.digest.Digest>(SystemStorage.DigestParams(), blockHash.Value, cancellationToken);
            var digest = await _substrateService.At(blockHash).Storage.System.DigestAsync(cancellationToken);

            foreach (var log in blockDetails.Block.Header.Digest.Logs) // TODO Check with Cedric
            {
                var buildLogs = new EnumDigestItem();
                buildLogs.Create(log);
            }
            var logDecode = _substrateDecode.DecodeLog(blockDetails.Block.Header.Digest.Logs);
            var founded1 = logDecode.Has(DigestItem.PreRuntime);
            var founded = logDecode.Find(DigestItem.PreRuntime);

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
                Date = _modelBuilder.BuildDateDto(currentDate),
                ExtrinsicsRoot = blockDetails.Block.Header.ExtrinsicsRoot,
                ParentHash = blockDetails.Block.Header.ParentHash,
                StateRoot = blockDetails.Block.Header.StateRoot,
                Number = blockDetails.Block.Header.Number.Value,
                Hash = blockHash,
                Status = GlobalStatusDto.BlockStatusDto.Broadcasted,
                NbExtrinsics = (uint)blockDetails.Block.Extrinsics.Length,
                NbEvents = eventsCount.Value,
                NbLogs = (uint)blockDetails.Block.Header.Digest.Logs.Count,
                SpecVersion = _substrateService.RuntimeVersion.SpecVersion,
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
            Func<string, int, Task<int>> s = async (s, h) =>
            {
                //await Task.CompletedTask;
                return 2;
            };

            //Task<int> ss = s;
            var sss = await s("hihi", 2);

            //Func<string, Header, Task> subscribe = async (string s, Header h) =>
            Action<string, Header> subscribe = async (s, h) =>
            {
                //var blockHash = await buildHashAsync((uint)h.Number.Value, CancellationToken.None);
                //var blockHash = await buildHashAsync(0, CancellationToken.None);

                //Hash currentHash = await _substrateService.Client.Chain.GetBlockHashAsync(blockHash);
                //_lastBlock = await GetBlockLightAsync(currentHash, cancellationToken);
                blockCallback(_lastBlock);
            };
            await _substrateService.Rpc.Chain.SubscribeAllHeadsAsync(subscribe);
            //await SubscribeAllHeadsAsync(subscribe);
        }

        //public async Task<string> SubscribeAllHeadsAsync(Func<string, Header, Task> action)
        //{
        //    return await _substrateService.Client.Chain.SubscribeAllHeadsAsync(await action, CancellationToken.None);
        //}
        //public async Task<string> SubscribeAllHeadsAsync(Func<string, Header, Task> callback, CancellationToken token)
        //{
        //    string text = await _substrateService.Client.InvokeAsync<string>("chain_subscribeAllHeads", null, token);
        //    _client.Listener.RegisterCallBackHandler(text, callback);
        //    return text;
        //}
        public Task<IEnumerable<EventDto>> GetEventsAsync(string blockHash, CancellationToken cancellationToken)
            => GetEventsAsync(new BlockParameterLike(blockHash), cancellationToken);

        public Task<IEnumerable<EventDto>> GetEventsAsync(uint blockId, CancellationToken cancellationToken)
            => GetEventsAsync(new BlockParameterLike(blockId), cancellationToken);

        public Task<IEnumerable<EventDto>> GetEventsAsync(Hash blockHash, CancellationToken cancellationToken)
            => GetEventsAsync(new BlockParameterLike(blockHash), cancellationToken);

        protected async Task<IEnumerable<EventDto>> GetEventsAsync(BlockParameterLike block, CancellationToken cancellationToken)
        {
            var blockHash = block.ToBlockHash();
            var events = await _substrateService.At(blockHash).Storage.System.EventsAsync(cancellationToken);

            var eventsDto = new List<EventDto>();

            foreach (var ev in events)
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

        public Task<IEnumerable<ExtrinsicDto>> GetExtrinsicsAsync(uint blockId, CancellationToken cancellationToken)
            => GetExtrinsicsAsync(new BlockParameterLike(blockId), cancellationToken);

        public Task<IEnumerable<ExtrinsicDto>> GetExtrinsicsAsync(Hash blockHash, CancellationToken cancellationToken)
            => GetExtrinsicsAsync(new BlockParameterLike(blockHash), cancellationToken);

        public async Task<IEnumerable<ExtrinsicDto>> GetExtrinsicsAsync(BlockParameterLike block, CancellationToken cancellationToken)
        {
            var blockHash = block.ToBlockHash();
            var blockDetails = await _substrateService.Rpc.Chain.GetBlockAsync(blockHash, cancellationToken);
            if (blockDetails == null)
                throw new BlockException($"{blockDetails} for block hash = {blockHash.Value} is null");

            var extrinsicsDto = new List<ExtrinsicDto>();
            foreach (var extrinsic in blockDetails.Block.Extrinsics.Where(e => e.Method.ModuleIndex != 54))
            {
                var encodedExtrinsic = encodeExtrinsic(extrinsic);
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
            IEnumerable<EventRecord> eventLinkedToCurrentExtrinsic = events.Where(e =>
            {
                if (e.Phase.Value == Phase.ApplyExtrinsic)
                {
                    var applyExtrinsicIndex = ((Ajuna.NetApi.Model.Types.Primitive.U32)e.Phase.Value2).Value;
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


        public byte[] encodeExtrinsic(Extrinsic extrinsic)
        {
            var result = new List<byte>();
            //var r = new byte[] { Convert.ToByte(enumPallet) };
            //result.AddRange(r);
            //result.AddRange(param);


            int p = 0;

            result.Add(Convert.ToByte(extrinsic.Signed));
            result.Add(extrinsic.TransactionVersion);
            if (extrinsic.Signed)
            {
                result.AddRange(extrinsic.Account.Encode());
                result.AddRange(extrinsic.Signature);
                result.AddRange(extrinsic.Era.Encode());
                result.AddRange(extrinsic.Nonce.Encode());
                result.AddRange(extrinsic.Charge.Encode());
            }

            result.AddRange(extrinsic.Method.Encode());

            return result.ToArray();
            //int p = 0;
            //CompactInteger.Decode(memory.ToArray(), ref p);
            //int num = 1;
            //byte b = memory.Slice(p, num).ToArray()[0];
            //Signed = b >= 128;
            //TransactionVersion = (byte)(b - (Signed ? 128 : 0));
            //p += num;
            //if (Signed)
            //{
            //    num = 1;
            //    _ = memory.Slice(p, num).ToArray()[0];
            //    p += num;
            //    num = 32;
            //    byte[] publicKey = memory.Slice(p, num).ToArray();
            //    p += num;
            //    num = 1;
            //    byte keyType = memory.Slice(p, num).ToArray()[0];
            //    p += num;
            //    Account account = new Account();
            //    account.Create((KeyType)keyType, publicKey);
            //    Account = account;
            //    num = 64;
            //    Signature = memory.Slice(p, num).ToArray();
            //    p += num;
            //    num = 1;
            //    byte[] array = memory.Slice(p, num).ToArray();
            //    if (array[0] != 0)
            //    {
            //        num = 2;
            //        array = memory.Slice(p, num).ToArray();
            //    }

            //    Era = Era.Decode(array);
            //    p += num;
            //    Nonce = CompactInteger.Decode(memory.ToArray(), ref p);
            //    Charge = chargeType;
            //    Charge.Decode(memory.ToArray(), ref p);
            //}

            //num = 2;
            //byte[] array2 = memory.Slice(p, num).ToArray();
            //p += num;
            //byte[] parameters = memory.Slice(p).ToArray();
            //Method = new Method(array2[0], array2[1], parameters);
        }

        public async Task SubscribeEventAsync(Action<EventLightDto> eventCallback)
        {
            Action<string, StorageChangeSet> eventChangeset = (subscriptionId, storageChangeSet) =>
            {
                var hexString = SubstrateHelper.getChangesetData(storageChangeSet);

                // No data
                if (string.IsNullOrEmpty(hexString)) return;

                var eventsReceived = new BaseVec<EventRecord>();
                eventsReceived.Create(hexString);

                foreach (EventRecord eventReceived in eventsReceived.Value)
                {
                    try
                    {
                        eventCallback(
                            _modelBuilder.BuildEventLightDto(
                                _substrateDecode.DecodeEvent(eventReceived)
                                )
                            );
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning($"Event Hexadecimal: {Utils.Bytes2HexString(eventReceived.Encode())}");
                        _logger.LogError($"Read event failed : {ex}");
                    }
                }
            };

            await _substrateService.Rpc.SubscribeStorageKeyAsync(SystemStorage.EventsParams(), eventChangeset, CancellationToken.None);
        }

        

        public Task<EventDto> GetEventAsync(uint blockId, uint eventIndex, CancellationToken cancellationToken)
            => GetEventAsync(new BlockParameterLike(blockId), eventIndex, cancellationToken);

        public Task<EventDto> GetEventAsync(string blockHash, uint eventIndex, CancellationToken cancellationToken)
            => GetEventAsync(new BlockParameterLike(blockHash), eventIndex, cancellationToken);

        public Task<EventDto> GetEventAsync(Hash blockHash, uint eventIndex, CancellationToken cancellationToken)
            => GetEventAsync(new BlockParameterLike(blockHash), eventIndex, cancellationToken);

        public async Task<EventDto> GetEventAsync(BlockParameterLike block, uint eventIndex, CancellationToken cancellationToken)
        {
            var blockHash = block.ToBlockHash();
            var events = await _substrateService.At(blockHash).Storage.System.EventsAsync(cancellationToken);

            var eventNode = _substrateDecode.DecodeEvent(events.ToList()[(int)eventIndex]);

            return _modelBuilder.BuildEventDto(
                    await GetBlockLightAsync(blockHash, cancellationToken),
                    eventNode);
        }

        public Task<ExtrinsicDto> GetExtrinsicAsync(uint blockId, uint extrinsicIndex, CancellationToken cancellationToken)
            => GetExtrinsicAsync(new BlockParameterLike(blockId), extrinsicIndex, cancellationToken);

        public Task<ExtrinsicDto> GetExtrinsicAsync(string blockHash, uint extrinsicIndex, CancellationToken cancellationToken)
            => GetExtrinsicAsync(new BlockParameterLike(blockHash), extrinsicIndex, cancellationToken);

        public Task<ExtrinsicDto> GetExtrinsicAsync(Hash blockHash, uint extrinsicIndex, CancellationToken cancellationToken)
            => GetExtrinsicAsync(new BlockParameterLike(blockHash), extrinsicIndex, cancellationToken);

        public Task<ExtrinsicDto> GetExtrinsicAsync(BlockParameterLike block, uint extrinsicIndex, CancellationToken cancellationToken)
        {
            var blockHash = block.ToBlockHash();
            //TODO
            throw new NotImplementedException();
        }
    }
}
