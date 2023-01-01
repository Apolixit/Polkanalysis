using Ajuna.NetApi.Model.Types.Base;
using Blazscan.Domain.Contracts;
using Blazscan.Domain.Contracts.Dto.Block;

namespace Blazscan.Infrastructure.Mock.Repository
{
    public class BlockRepositoryMock : IBlockRepository
    {
        public Task<BlockDto> GetBlockDetailsAsync(uint blockId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<BlockDto> GetBlockDetailsAsync(Hash blockHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<DateTime> GetDateTimeFromTimestampAsync(Hash? blockHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<BlockLightDto?> GetLastBlockAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SubscribeNewBlocksAsync(Action<BlockLightDto> blockCallback, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
