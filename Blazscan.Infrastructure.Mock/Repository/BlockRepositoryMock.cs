using Blazscan.Domain.Contracts;
using Blazscan.Domain.Contracts.Dto.Block;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Infrastructure.Mock.Repository
{
    public class BlockRepositoryMock : IBlockRepository
    {
        public Task<BlockDto> GetBlockDetailsAsync(uint blockId)
        {
            throw new NotImplementedException();
        }

        public Task<BlockLightDto?> GetLastBlockAsync()
        {
            throw new NotImplementedException();
        }

        public Task SubscribeNewBlocksAsync(Action<BlockLightDto> blockCallback)
        {
            throw new NotImplementedException();
        }
    }
}
