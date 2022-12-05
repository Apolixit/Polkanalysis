using Blazscan.Domain.Contracts.Dto.Block;

namespace Blazscan.Domain.Contracts
{
    public interface IBlockRepository
    {
        /// <summary>
        /// Allow to subscribe to new generated blocks
        /// </summary>
        /// <param name="blockCallback">Return the new finalized block</param>
        Task SubscribeNewBlocksAsync(Action<BlockDto> blockCallback);

        /// <summary>
        /// Return the last finalized block
        /// </summary>
        /// <returns></returns>
        Task<BlockDto?> GetLastBlockAsync();

        /// <summary>
        /// Get full details for this block
        /// </summary>
        /// <returns></returns>
        Task<BlockDetailsDto> GetBlockDetailsAsync(uint blockId);
    }
}
