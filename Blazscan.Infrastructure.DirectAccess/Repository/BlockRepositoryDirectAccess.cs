using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;
using Blazscan.Domain.Contracts;
using Blazscan.Domain.Contracts.Dto.Block;
using Blazscan.Domain.Contracts.Exception;
using Blazscan.Domain.Contracts.Repository;
using Blazscan.SubstrateDecode.Abstract;

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

        public async Task<BlockDto> GetBlockDetailsAsync(uint blockId)
        {
            var blockNumber = new BlockNumber();
            blockNumber.Create(blockId);

            var blockHash = await _substrateService.Client.Chain.GetBlockHashAsync(blockNumber);
            var blockDetails = await _substrateService.Client.Chain.GetBlockAsync(blockHash);

            //var blockModel = new BlockDto() { 
            //    Date
            //}
            //blockModel.Header = new HeaderDto(blockDetails.Block.Header);

            var filteredExtrinsic = blockDetails.Block.Extrinsics.Where(e => e.Method.ModuleIndex != 54);
            foreach(var extrinsic in filteredExtrinsic)
            {
                var extrinsicDecode = _substrateDecode.DecodeExtrinsic(extrinsic);
            }
            
            //var logDecode = _substrateDecode.DecodeLog(blockDetails.Block.Header.Digest.Logs);
            return null;
        }

        public Task<BlockLightDto?> GetLastBlockAsync()
        {
            return Task.Run(() => _lastBlock);
        }

        public async Task SubscribeNewBlocksAsync(Action<BlockLightDto> blockCallback)
        {
            await _substrateService.Client.Chain.SubscribeAllHeadsAsync(async (string s, Header h) =>
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
            });
        }
    }
}
