using Ajuna.NetApi;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;
using Blake2Core;
using Blazscan.Domain.Contracts;
using Blazscan.Domain.Contracts.Dto.Block;
using Blazscan.Domain.Contracts.Exception;
using Blazscan.Domain.Contracts.Repository;
using Blazscan.Domain.Contracts.Runtime;
using Blazscan.Polkadot.NetApiExt.Generated.Storage;
using Newtonsoft.Json.Linq;

namespace Blazscan.Infrastructure.DirectAccess.Repository
{
    public class BlockRepositoryDirectAccess : IBlockRepository
    {
        private readonly ISubstrateNodeRepository _substrateService;
        private readonly ISubstrateDecoding _substrateDecode;
        private BlockLightDto? _lastBlock;

        public BlockRepositoryDirectAccess(
            ISubstrateNodeRepository substrateNodeRepository,
            ISubstrateDecoding substrateDecode)
        {
            _substrateService = substrateNodeRepository;
            _substrateDecode = substrateDecode;
        }

        public async Task<BlockDto> GetBlockDetailsAsync(uint blockId, CancellationToken cancellationToken)
        {
            var blockNumber = new BlockNumber();
            blockNumber.Create(blockId);

            var blockHash = await _substrateService.Client.Chain.GetBlockHashAsync(blockNumber, cancellationToken);
            return await GetBlockDetailsAsync(blockHash, cancellationToken);
        }

        public async Task<BlockDto> GetBlockDetailsAsync(Hash blockHash, CancellationToken cancellationToken)
        {
            var blockDetails = await _substrateService.Client.Chain.GetBlockAsync(blockHash, cancellationToken);
            if (blockDetails == null)
                throw new BlockException($"{blockDetails} for block hash = {blockHash.Value} is null");

            var currentDate = await GetDateTimeFromTimestampAsync(blockHash, cancellationToken);

            var eventsCount = await _substrateService.Client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U32>(SystemStorage.EventCountParams(), blockHash.Value, cancellationToken);
            
            var blockExecutionPhase = await _substrateService.Client.GetStorageAsync<Blazscan.Polkadot.NetApiExt.Generated.Model.frame_system.EnumPhase>(SystemStorage.ExecutionPhaseParams(), blockHash.Value, cancellationToken);

            //await _substrateService.Client.AuthorshipStorage.Author(cancellationToken);
            var blockAuthor = await _substrateService.Client.GetStorageAsync<Blazscan.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>(AuthorshipStorage.AuthorParams(), blockHash.Value, cancellationToken);

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
            //var a = await _substrateService.Client.RuntimeVersion.SpecVersion;
            // Try to get event from first extrinsic
            //var events = await _substrateService.Client.SystemStorage.Events(CancellationToken.None);
            //foreach(var e in events.Value)
            //{

            //}
            return blockDto;
        }

        public async Task<int?> GetBlockEvents(uint blockId)
        {
            var blockNumber = new BlockNumber();
            blockNumber.Create(blockId);
            var blockHash = await _substrateService.Client.Chain.GetBlockHashAsync(blockNumber);

            //0x26AA394EEA5630E07C48AE0C9558CEF780D41E5E16056765BC8461851072C9D7
            var parameters1 = RequestGenerator.GetStorage("System", "Events", Ajuna.NetApi.Model.Meta.Storage.Type.Plain, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Identity}, new Ajuna.NetApi.Model.Types.IType[] {
                        blockHash});

            var atParameters = new object[2] { SystemStorage.EventsParams(), blockHash.Value };
            string text = await _substrateService.Client.InvokeAsync<string>("state_getStorage", atParameters, CancellationToken.None);
            var result = new BaseVec<Polkadot.NetApiExt.Generated.Model.frame_system.EventRecord>();
            if (text != null && text.Length > 0)
            {
                result.Create(text);
            }


            string parameters2 = SystemStorage.EventsParams();
            var events1 = await _substrateService.Client.GetStorageAsync<BaseVec<Polkadot.NetApiExt.Generated.Model.frame_system.EventRecord>>(parameters1, CancellationToken.None);
            var events2 = await _substrateService.Client.GetStorageAsync<BaseVec<Polkadot.NetApiExt.Generated.Model.frame_system.EventRecord>>(parameters2, CancellationToken.None);

            return null;
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
            Action<string, Header> subscribe = async (string s, Header h) =>
            {
                var blockNumber = new BlockNumber();
                blockNumber.Create((uint)h.Number.Value);

                Hash currentHash = await _substrateService.Client.Chain.GetBlockHashAsync(blockNumber);
                //if (currentHash == null)
                //    throw new HashException($"Hash from blockNumber = {blockNumber} is null");

                _lastBlock = new BlockLightDto()
                {
                    Hash = currentHash,
                    Number = (ulong)blockNumber.Value,
                    Status = Domain.Contracts.Dto.StatusDto.Broadcasted,
                    When = TimeSpan.Zero
                };

                blockCallback(_lastBlock);
            };
            await _substrateService.Client.Chain.SubscribeAllHeadsAsync(subscribe);
        }
    }
}
