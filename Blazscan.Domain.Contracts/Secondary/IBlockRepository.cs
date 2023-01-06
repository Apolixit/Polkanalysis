using Ajuna.NetApi.Model.Types.Base;
using Blazscan.Domain.Contracts.Dto.Block;
using Blazscan.Domain.Contracts.Dto.Event;
using Blazscan.Polkadot.NetApiExt.Generated.Model.frame_system;

namespace Blazscan.Domain.Contracts.Secondary
{
    public interface IBlockRepository
    {
        /// <summary>
        /// Allow to subscribe to new generated blocks
        /// </summary>
        /// <param name="blockCallback">Return the new finalized block</param>
        /// <param name="cancellationToken"></param>
        Task SubscribeNewBlocksAsync(Action<BlockLightDto> blockCallback, CancellationToken cancellationToken);

        /// <summary>
        /// Return the last finalized block
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<BlockLightDto?> GetLastBlockAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Get full details for this block
        /// </summary>
        /// <param name="blockId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<BlockDto> GetBlockDetailsAsync(uint blockId, CancellationToken cancellationToken);

        /// <summary>
        /// Get full details for this block
        /// </summary>
        /// <param name="blockHash"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<BlockDto> GetBlockDetailsAsync(Hash blockHash, CancellationToken cancellationToken);

        /// <summary>
        /// Get full details for this block
        /// </summary>
        /// <param name="blockHash"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<BlockDto> GetBlockDetailsAsync(string blockHash, CancellationToken cancellationToken);

        /// <summary>
        /// Return events associated to given block
        /// </summary>
        /// <param name="blockId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<EventDto>> GetEventsAsync(uint blockId, CancellationToken cancellationToken);

        /// <summary>
        /// Return events associated to given block
        /// </summary>
        /// <param name="blockHash"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<EventDto>> GetEventsAsync(string blockHash, CancellationToken cancellationToken);

        /// <summary>
        /// Return events associated to given block
        /// </summary>
        /// <param name="blockHash"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<EventDto>> GetEventsAsync(Hash blockHash, CancellationToken cancellationToken);

        /// <summary>
        /// Return extrincis associated to given block
        /// </summary>
        /// <param name="blockId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<EventDto>> GetExtrinsicsAsync(uint blockId, CancellationToken cancellationToken);

        /// <summary>
        /// Return extrincis associated to given block
        /// </summary>
        /// <param name="blockHash"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<EventDto>> GetExtrinsicsAsync(string blockHash, CancellationToken cancellationToken);

        /// <summary>
        /// Return extrincis associated to given block
        /// </summary>
        /// <param name="blockHash"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<EventDto>> GetExtrinsicsAsync(Hash blockHash, CancellationToken cancellationToken);

        /// <summary>
        /// Return the datetime from pallet timestamp
        /// </summary>
        /// <param name="blockHash"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DateTime> GetDateTimeFromTimestampAsync(Hash? blockHash, CancellationToken cancellationToken);
    }
}
