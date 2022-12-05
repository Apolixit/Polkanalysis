using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;
using Blazscan.Domain.Contracts;
using Blazscan.Domain.Contracts.Dto.Block;
using Blazscan.Domain.Contracts.Repository;
using Blazscan.SubstrateDecode.Extrinsic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Infrastructure.DirectAccess.Repository
{
    public class BlockRepositoryDirectAccess : IBlockRepository
    {
        private readonly ISubstrateNodeRepository _substrateService;
        private BlockDto? _lastBlock;

        public BlockRepositoryDirectAccess(ISubstrateNodeRepository substrateNodeRepository)
        {
            _substrateService = substrateNodeRepository;
        }

        public async Task<BlockDetailsDto> GetBlockDetailsAsync(uint blockId)
        {
            var blockNumber = new BlockNumber();
            blockNumber.Create(blockId);

            var blockHash = await _substrateService.Client.Chain.GetBlockHashAsync(blockNumber);
            //_substrateService.Client.SystemStorage.ExtrinsicData
            var blockDetails = await _substrateService.Client.Chain.GetBlockAsync(blockHash);

            var blockModel = new BlockDetailsDto();
            blockModel.Header = new HeaderDto(blockDetails.Block.Header);

            var ex = blockDetails.Block.Extrinsics.Last();
            //ex.Method
            //_substrateService.Client.StorageKeyDict
            var extrinsicDecode = new ExtrinsicDecode(_substrateService);
            extrinsicDecode.ReadExtrinsic(ex);
            return new BlockDetailsDto();
        }

        public Task<BlockDto?> GetLastBlockAsync()
        {
            return Task.Run(() => _lastBlock);
        }

        public async Task SubscribeNewBlocksAsync(Action<BlockDto> blockCallback)
        {
            await _substrateService.Client.Chain.SubscribeAllHeadsAsync(async (string s, Header h) =>
            {
                var blockNumber = new BlockNumber();
                blockNumber.Create((uint)h.Number.Value);

                var currentHash = await _substrateService.Client.Chain.GetBlockHashAsync(blockNumber);
                _lastBlock = new BlockDto()
                {
                    BlockHash = currentHash.Value,
                    BlockNumber = (int)blockNumber.Value,
                };

                blockCallback(_lastBlock);
            });
        }
    }
}
