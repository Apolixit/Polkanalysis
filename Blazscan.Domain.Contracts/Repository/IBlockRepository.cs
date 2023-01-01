using Ajuna.NetApi.Model.Types.Base;
using Blazscan.Domain.Contracts.Dto.Block;

namespace Blazscan.Domain.Contracts
{
    public interface IBlockRepository
    {
        /// <summary>
        /// Allow to subscribe to new generated blocks
        /// </summary>
        /// <param name="blockCallback">Return the new finalized block</param>
        Task SubscribeNewBlocksAsync(Action<BlockLightDto> blockCallback, CancellationToken cancellationToken);

        /// <summary>
        /// Return the last finalized block
        /// </summary>
        /// <returns></returns>
        Task<BlockLightDto?> GetLastBlockAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Get full details for this block
        /// </summary>
        /// <returns></returns>
        Task<BlockDto> GetBlockDetailsAsync(uint blockId, CancellationToken cancellationToken);

        /// <summary>
        /// Get full details for this block
        /// </summary>
        /// <returns></returns>
        Task<BlockDto> GetBlockDetailsAsync(Hash blockHash, CancellationToken cancellationToken);

        /// <summary>
        /// Return the datetime from pallet timestamp
        /// </summary>
        /// <param name="blockHash"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DateTime> GetDateTimeFromTimestampAsync(Hash? blockHash, CancellationToken cancellationToken);
    }
}
