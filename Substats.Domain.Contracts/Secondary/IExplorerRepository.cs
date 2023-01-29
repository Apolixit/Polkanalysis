﻿using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;
using Substats.Domain.Contracts.Dto.Block;
using Substats.Domain.Contracts.Dto.Event;
using Substats.Domain.Contracts.Dto.Extrinsic;
using Substats.Polkadot.NetApiExt.Generated.Model.frame_system;

namespace Substats.Domain.Contracts.Secondary
{
    public interface IExplorerRepository
    {
        #region Block
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
        /// <param name="blockHash">Block represented as string</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<BlockDto> GetBlockDetailsAsync(string blockHash, CancellationToken cancellationToken);

        /// <summary>
        /// Get some basic information about block
        /// </summary>
        /// <param name="blockData"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<BlockLightDto> GetBlockLightAsync(uint blockId, CancellationToken cancellationToken);

        /// <summary>
        /// Get some basic information about block
        /// </summary>
        /// <param name="blockHash"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<BlockLightDto> GetBlockLightAsync(Hash blockHash, CancellationToken cancellationToken);

        /// <summary>
        /// Get some basic information about block
        /// </summary>
        /// <param name="blockHash"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<BlockLightDto> GetBlockLightAsync(string blockHash, CancellationToken cancellationToken);
        #endregion

        #region Events
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
        /// Return full event details
        /// </summary>
        /// <param name="blockId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<EventDto> GetEventAsync(uint blockId, uint eventIndex, CancellationToken cancellationToken);

        /// <summary>
        /// Return full event details
        /// </summary>
        /// <param name="blockHash"></param>
        /// <param name="eventIndex"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<EventDto> GetEventAsync(Hash blockHash, uint eventIndex, CancellationToken cancellationToken);

        /// <summary>
        /// Return events related to this extrinsic
        /// </summary>
        /// <param name="extrinsicDto"></param>
        /// <param name="extrinsics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<EventDto>?> GetEventsLinkedToExtrinsicsAsync(ExtrinsicDto extrinsicDto, IEnumerable<Extrinsic> extrinsics, CancellationToken cancellationToken);

        /// <summary>
        /// Return events related to this extrinsic
        /// </summary>
        /// <param name="extrinsicDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<EventDto>?> GetEventsLinkedToExtrinsicsAsync(ExtrinsicDto extrinsicDto, CancellationToken cancellationToken);

        /// <summary>
        /// Subscribe for new events
        /// </summary>
        /// <param name="eventCallback"></param>
        /// <returns></returns>
        Task SubscribeEventAsync(Action<EventLightDto> eventCallback);
        #endregion

        #region Extrinsic
        /// <summary>
        /// Return extrincis associated to given block
        /// </summary>
        /// <param name="blockId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<ExtrinsicDto>> GetExtrinsicsAsync(uint blockId, CancellationToken cancellationToken);

        /// <summary>
        /// Return extrincis associated to given block
        /// </summary>
        /// <param name="blockHash"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<ExtrinsicDto>> GetExtrinsicsAsync(string blockHash, CancellationToken cancellationToken);

        /// <summary>
        /// Return extrincis associated to given block
        /// </summary>
        /// <param name="blockHash"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<ExtrinsicDto>> GetExtrinsicsAsync(Hash blockHash, CancellationToken cancellationToken);

        /// <summary>
        /// Return full extrinsic details
        /// </summary>
        /// <param name="blockId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ExtrinsicDto> GetExtrinsicAsync(uint blockId, uint extrinsicIndex, CancellationToken cancellationToken);

        /// <summary>
        /// Return full extrinsic details
        /// </summary>
        /// <param name="blockHash"></param>
        /// <param name="extrinsicIndex"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ExtrinsicDto> GetExtrinsicAsync(Hash blockHash, uint extrinsicIndex, CancellationToken cancellationToken);
        #endregion

        #region Time
        /// <summary>
        /// Return the datetime from pallet timestamp
        /// </summary>
        /// <param name="blockHash"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DateTime> GetDateTimeFromTimestampAsync(Hash? blockHash, CancellationToken cancellationToken);
        #endregion
    }
}