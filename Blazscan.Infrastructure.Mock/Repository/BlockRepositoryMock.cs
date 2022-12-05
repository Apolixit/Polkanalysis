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
        public Task<BlockDetailsDto> GetBlockDetailsAsync(uint blockId)
        {
            throw new NotImplementedException();
        }

        public Task<BlockDto?> GetLastBlockAsync()
        {
            throw new NotImplementedException();
        }

        public Task SubscribeNewBlocksAsync(Action<BlockDto> blockCallback)
        {
            throw new NotImplementedException();
        }
    }
}
