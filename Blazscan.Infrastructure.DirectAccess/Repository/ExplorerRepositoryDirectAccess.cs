using Ajuna.NetApi;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;
using Blake2Core;
using Blazscan.Domain.Contracts;
using Blazscan.Domain.Contracts.Dto.Block;
using Blazscan.Domain.Contracts.Dto.Event;
using Blazscan.Domain.Contracts.Exception;
using Blazscan.Domain.Contracts.Secondary;
using Blazscan.Domain.Contracts.Runtime;
using Blazscan.Polkadot.NetApiExt.Generated.Storage;
using Newtonsoft.Json.Linq;
using Microsoft.VisualStudio.Threading;
using System;
using System.Reflection.Metadata.Ecma335;
using Blazscan.Domain.Contracts.Dto.Extrinsic;
using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Types;
using System.Runtime.InteropServices;
using Blazscan.Polkadot.NetApiExt.Generated.Model.frame_system;
using Blazscan.Domain.Contracts.Dto;
using Blazscan.Infrastructure.DirectAccess.Helpers;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Blazscan.Infrastructure.DirectAccess.Repository
{
    public class ExplorerRepositoryDirectAccess : IExplorerRepository
    {
        private readonly ISubstrateNodeRepository _substrateService;
        private readonly ISubstrateDecoding _substrateDecode;
        private readonly IModelBuilder _modelBuilder;
        private readonly ILogger<ExplorerRepositoryDirectAccess> _logger;
        private BlockLightDto? _lastBlock;

        public ExplorerRepositoryDirectAccess(
            ISubstrateNodeRepository substrateNodeRepository,
            ISubstrateDecoding substrateDecode,
            IModelBuilder modelBuilder,
            ILogger<ExplorerRepositoryDirectAccess> logger)
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

            var blockHash = await _substrateService.Client.Chain.GetBlockHashAsync(blockNumber, cancellationToken);

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

        public async Task<BlockLightDto> GetBlockLightAsync(Hash blockHash, CancellationToken cancellationToken)
        {
            var blockData = await _substrateService.Client.Chain.GetBlockAsync(blockHash, cancellationToken);
            if (blockData == null)
                throw new BlockException($"{blockData} for block hash = {blockHash.Value} is null");

            var blockDate = await GetDateTimeFromTimestampAsync(blockHash, cancellationToken);

            return _modelBuilder.BuildBlockLightDto(blockHash, blockData, blockDate);
        }

        public async Task<BlockDto> GetBlockDetailsAsync(uint blockId, CancellationToken cancellationToken)
            => await GetBlockDetailsAsync(await buildHashAsync(blockId, cancellationToken), cancellationToken);

        public async Task<BlockDto> GetBlockDetailsAsync(string blockHash, CancellationToken cancellationToken)
            => await GetBlockDetailsAsync(buildHash(blockHash), cancellationToken);

        public async Task<BlockDto> GetBlockDetailsAsync(Hash blockHash, CancellationToken cancellationToken)
        {
            var blockDetails = await _substrateService.Client.Chain.GetBlockAsync(blockHash, cancellationToken);
            if (blockDetails == null)
                throw new BlockException($"{blockDetails} for block hash = {blockHash.Value} is null");

            var currentDate = await GetDateTimeFromTimestampAsync(blockHash, cancellationToken);

            var eventsCount = await _substrateService.Client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U32>(SystemStorage.EventCountParams(), blockHash.Value, cancellationToken);

            var blockExecutionPhase = await _substrateService.Client.GetStorageAsync<EnumPhase>(SystemStorage.ExecutionPhaseParams(), blockHash.Value, cancellationToken);

            //await _substrateService.Client.AuthorshipStorage.Author(cancellationToken);
            var blockAuthor = await _substrateService.Client.GetStorageAsync<Blazscan.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>(AuthorshipStorage.AuthorParams(), blockHash.Value, cancellationToken);
            var blockAuthor2 = await _substrateService.Client.GetStorageAsync<Blazscan.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>(AuthorshipStorage.AuthorParams(), cancellationToken);

            //var staking = await _substrateService.Client.GetStorageAsync<Blazscan.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>(
            //    AuthorshipStorage.AuthorParams(), blockhash, cancellationToken);

            var filteredExtrinsic = blockDetails.Block.Extrinsics.Where(e => e.Method.ModuleIndex != 54);
            //var filteredExtrinsic = blockDetails.Block.Extrinsics;
            foreach (var extrinsic in filteredExtrinsic)
            {
                var extrinsicDecode = _substrateDecode.DecodeExtrinsic(extrinsic);
            }

            //var logDecode = _substrateDecode.DecodeLog(blockDetails.Block.Header.Digest.Logs);



            var blockDto = new BlockDto()
            {
                Date = currentDate,
                When = TimeSpan.FromMilliseconds(DateTime.Now.Millisecond - currentDate.Millisecond),
                ExtrinsicsRoot = blockDetails.Block.Header.ExtrinsicsRoot,
                ParentHash = blockDetails.Block.Header.ParentHash,
                StateRoot = blockDetails.Block.Header.StateRoot,
                Number = blockDetails.Block.Header.Number.Value,
                Hash = blockHash,
                Status = Domain.Contracts.Dto.StatusDto.Broadcasted,
                NbExtrinsics = (uint)blockDetails.Block.Extrinsics.Length,
                NbEvents = eventsCount.Value,
                NbLogs = (uint)blockDetails.Block.Header.Digest.Logs.Count,
                SpecVersion = _substrateService.Client.RuntimeVersion.SpecVersion,
                Validator = null,
            };

            var a = await _substrateService.Client.State.GetMetaDataAsync();
            var b = await _substrateService.Client.StakingStorage.ValidatorCount(CancellationToken.None);
            var c = await _substrateService.Client.System.LocalListenAddressesAsync(cancellationToken);
            var d = await _substrateService.Client.AuthorshipStorage.Author(cancellationToken);
            var e = await _substrateService.Client.AuthorshipStorage.Uncles(cancellationToken);

            return blockDto;
        }



        public async Task<DateTime> GetDateTimeFromTimestampAsync(Hash? blockHash, CancellationToken cancellationToken)
        {
            var currentTimestamp = blockHash switch
            {
                null => await _substrateService.Client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U64>(TimestampStorage.NowParams(), cancellationToken),
                _ => await _substrateService.Client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U64>(TimestampStorage.NowParams(), blockHash.Value, cancellationToken)
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
            Func<string, int, Task<int>> s = async (string s, int h) =>
            {
                //await Task.CompletedTask;
                return 2;
            };

            //Task<int> ss = s;
            var sss = await s("hihi", 2);

            //Func<string, Header, Task> subscribe = async (string s, Header h) =>
            Action<string, Header> subscribe = async (string s, Header h) =>
            {
                //var blockHash = await buildHashAsync((uint)h.Number.Value, CancellationToken.None);
                //var blockHash = await buildHashAsync(0, CancellationToken.None);

                //Hash currentHash = await _substrateService.Client.Chain.GetBlockHashAsync(blockHash);
                //_lastBlock = await GetBlockLightAsync(currentHash, cancellationToken);
                blockCallback(_lastBlock);
            };
            await _substrateService.Client.Chain.SubscribeAllHeadsAsync(subscribe);
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
        public async Task<IEnumerable<EventDto>> GetEventsAsync(string blockHash, CancellationToken cancellationToken)
            => await GetEventsAsync(buildHash(blockHash), cancellationToken);

        public async Task<IEnumerable<EventDto>> GetEventsAsync(uint blockId, CancellationToken cancellationToken)
            => await GetEventsAsync(await buildHashAsync(blockId, cancellationToken), cancellationToken);

        public async Task<IEnumerable<EventDto>> GetEventsAsync(Hash blockHash, CancellationToken cancellationToken)
        {
            var events = await _substrateService.Client.GetStorageAsync<BaseVec<Polkadot.NetApiExt.Generated.Model.frame_system.EventRecord>>(
                SystemStorage.EventsParams(), blockHash.Value, cancellationToken);

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


        public async Task<IEnumerable<ExtrinsicDto>> GetExtrinsicsAsync(string blockHash, CancellationToken cancellationToken)
            => await GetExtrinsicsAsync(buildHash(blockHash), cancellationToken);

        public async Task<IEnumerable<ExtrinsicDto>> GetExtrinsicsAsync(uint blockId, CancellationToken cancellationToken)
            => await GetExtrinsicsAsync(await buildHashAsync(blockId, cancellationToken), cancellationToken);

        public async Task<IEnumerable<ExtrinsicDto>> GetExtrinsicsAsync(Hash blockHash, CancellationToken cancellationToken)
        {
            var blockDetails = await _substrateService.Client.Chain.GetBlockAsync(blockHash, cancellationToken);
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
                        blockDetails.Block.Extrinsics.ToList().IndexOf(extrinsic))
                    );
            }

            return extrinsicsDto;
        }

        public async Task<IEnumerable<EventDto>?> GetEventsLinkedToExtrinsicsAsync(
            ExtrinsicDto extrinsicDto,
            CancellationToken cancellationToken)
        {
            var blockDetails = await _substrateService.Client.Chain.GetBlockAsync(
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
            BaseVec<EventRecord> events = await _substrateService.Client.GetStorageAsync<BaseVec<EventRecord>>(
                SystemStorage.EventsParams(), extrinsicDto.Block.Hash.Value, cancellationToken);

            // Doc here :
            // https://polkadot.js.org/docs/api/cookbook/blocks#how-do-i-map-extrinsics-to-their-events
            for (int i = 0; i < extrinsics.Count(); i++)
            {
                // Event Phase must be "Apply extrinsic" dans his value must be equal to extrinsic index
                IEnumerable<EventRecord> eventLinkedToCurrentExtrinsic = events.Value.Where(e =>
                {
                    if (e.Phase.Value == Phase.ApplyExtrinsic)
                    {
                        var applyExtrinsicIndex = ((Ajuna.NetApi.Model.Types.Primitive.U32)e.Phase.Value2).Value;
                        return applyExtrinsicIndex == i;
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

            return null;
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
                                _substrateDecode.DecodeEvent(eventReceived.Event)
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

            await _substrateService.Client.SubscribeStorageKeyAsync(SystemStorage.EventsParams(), eventChangeset, CancellationToken.None);
        }

        public Task<BlockLightDto> GetBlockLightAsync(uint blockId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<BlockLightDto> GetBlockLightAsync(string blockHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<EventDto> GetEventAsync(uint blockId, uint eventIndex, CancellationToken cancellationToken)
            => await GetEventAsync(await buildHashAsync(blockId, cancellationToken), eventIndex, cancellationToken);

        public async Task<EventDto> GetEventAsync(Hash blockHash, uint eventIndex, CancellationToken cancellationToken)
        {
            var events = await _substrateService.Client.GetStorageAsync<BaseVec<EventRecord>>(
                SystemStorage.EventsParams(), blockHash.Value, cancellationToken);

            var eventNode = _substrateDecode.DecodeEvent(events.Value[eventIndex]);

            return _modelBuilder.BuildEventDto(
                    await GetBlockLightAsync(blockHash, cancellationToken),
                    eventNode);
        }

        public async Task<ExtrinsicDto> GetExtrinsicAsync(uint blockId, uint extrinsicIndex, CancellationToken cancellationToken)
            => await GetExtrinsicAsync(await buildHashAsync(blockId, cancellationToken), extrinsicIndex, cancellationToken);

        public Task<ExtrinsicDto> GetExtrinsicAsync(Hash blockHash, uint extrinsicIndex, CancellationToken cancellationToken)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
