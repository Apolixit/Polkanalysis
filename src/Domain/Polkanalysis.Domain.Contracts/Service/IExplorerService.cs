using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Dto.Event;
using Polkanalysis.Domain.Contracts.Dto.Extrinsic;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Polkanalysis.Domain.Contracts.Dto.Logs;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Substrate.NetApi.Model.Meta;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.ExtrinsicTmp;

namespace Polkanalysis.Domain.Contracts.Service
{
    public interface IExplorerService
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
        /// Return the last N finalized blocks
        /// </summary>
        /// <param name="nbBlock">The number of blocks to retrieve</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<BlockLightDto>> GetLastBlocksAsync(int nbBlock, CancellationToken cancellationToken);

        /// <summary>
        /// Get full details for this block
        /// </summary>
        /// <param name="blockId">The ID of the block</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<BlockDto> GetBlockDetailsAsync(uint blockId, CancellationToken cancellationToken);

        /// <summary>
        /// Get full details for this block
        /// </summary>
        /// <param name="blockHash">The hash of the block</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<BlockDto> GetBlockDetailsAsync(Hash blockHash, CancellationToken cancellationToken);

        /// <summary>
        /// Get full details for this block
        /// </summary>
        /// <param name="blockHash">The hash of the block represented as string</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<BlockDto> GetBlockDetailsAsync(string blockHash, CancellationToken cancellationToken);

        /// <summary>
        /// Get the author of the block
        /// </summary>
        /// <param name="blockId">The ID of the block</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<SubstrateAccount> GetBlockAuthorAsync(uint blockId, CancellationToken cancellationToken);

        /// <summary>
        /// Get some basic information about the block
        /// </summary>
        /// <param name="blockId">The ID of the block</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<BlockLightDto> GetBlockLightAsync(uint blockId, CancellationToken cancellationToken);

        /// <summary>
        /// Get some basic information about the block
        /// </summary>
        /// <param name="blockHash">The hash of the block</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<BlockLightDto> GetBlockLightAsync(Hash blockHash, CancellationToken cancellationToken);

        /// <summary>
        /// Get some basic information about the block
        /// </summary>
        /// <param name="blockHash">The hash of the block represented as string</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<BlockLightDto> GetBlockLightAsync(string blockHash, CancellationToken cancellationToken);
        #endregion

        #region Events
        /// <summary>
        /// Return events associated with the given block
        /// </summary>
        /// <param name="blockId">The ID of the block</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<EventDto>> GetEventsAsync(uint blockId, CancellationToken cancellationToken);

        /// <summary>
        /// Return events associated with the given block
        /// </summary>
        /// <param name="blockHash">The hash of the block</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<EventDto>> GetEventsAsync(string blockHash, CancellationToken cancellationToken);

        /// <summary>
        /// Return events associated with the given block
        /// </summary>
        /// <param name="blockHash">The hash of the block</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<EventDto>> GetEventsAsync(Hash blockHash, CancellationToken cancellationToken);

        /// <summary>
        /// Return full event details
        /// </summary>
        /// <param name="blockId">The ID of the block</param>
        /// <param name="eventIndex">The index of the event</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<EventDto> GetEventAsync(uint blockId, uint eventIndex, CancellationToken cancellationToken);

        /// <summary>
        /// Return full event details
        /// </summary>
        /// <param name="blockHash">The hash of the block</param>
        /// <param name="eventIndex">The index of the event</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<EventDto> GetEventAsync(Hash blockHash, uint eventIndex, CancellationToken cancellationToken);

        /// <summary>
        /// Return events related to this extrinsic
        /// </summary>
        /// <param name="extrinsicDto">The extrinsic DTO</param>
        /// <param name="extrinsics">The list of extrinsics</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<EventDto>?> GetEventsLinkedToExtrinsicsAsync(ExtrinsicDto extrinsicDto, IEnumerable<IExtrinsic> extrinsics, CancellationToken cancellationToken);

        /// <summary>
        /// Return events related to this extrinsic
        /// </summary>
        /// <param name="extrinsicDto">The extrinsic DTO</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<EventDto>?> GetEventsLinkedToExtrinsicsAsync(ExtrinsicDto extrinsicDto, CancellationToken cancellationToken);

        /// <summary>
        /// Subscribe for new events
        /// </summary>
        /// <param name="eventCallback"></param>
        /// <returns></returns>
        Task SubscribeEventAsync(Action<EventLightDto> eventCallback, CancellationToken cancellationToken);

        /// <summary>
        /// Find an event in the given list of events
        /// </summary>
        /// <param name="events">The list of events</param>
        /// <param name="palletName">The name of the pallet</param>
        /// <param name="eventName">The name of the event</param>
        /// <returns></returns>
        Task<IEnumerable<EventRecord>> FindEventAsync(BaseVec<EventRecord> events, MetaData metadata, RuntimeEvent palletName, Enum eventName, CancellationToken token);

        /// <summary>
        /// Subscribe to a specific event
        /// </summary>
        /// <param name="palletName">The name of the pallet</param>
        /// <param name="eventName">The name of the event</param>
        /// <param name="callback">The callback action</param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task SubscribeSpecificEventAsync(RuntimeEvent palletName, Enum eventName, MetaData metadata, Action<EventRecord> callback, CancellationToken token);
        #endregion

        #region Extrinsic
        /// <summary>
        /// Return extrinsics associated with the given block
        /// </summary>
        /// <param name="blockId">The ID of the block</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<ExtrinsicDto>> GetExtrinsicsAsync(uint blockId, CancellationToken cancellationToken);

        /// <summary>
        /// Return extrinsics associated with the given block
        /// </summary>
        /// <param name="blockHash">The hash of the block</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<ExtrinsicDto>> GetExtrinsicsAsync(string blockHash, CancellationToken cancellationToken);

        /// <summary>
        /// Return extrinsics associated with the given block
        /// </summary>
        /// <param name="blockHash">The hash of the block</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<ExtrinsicDto>> GetExtrinsicsAsync(Hash blockHash, CancellationToken cancellationToken);

        /// <summary>
        /// Return full extrinsic details
        /// </summary>
        /// <param name="blockId">The ID of the block</param>
        /// <param name="extrinsicIndex">The index of the extrinsic</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ExtrinsicDto> GetExtrinsicAsync(uint blockId, uint extrinsicIndex, CancellationToken cancellationToken);

        /// <summary>
        /// Return full extrinsic details
        /// </summary>
        /// <param name="blockHash">The hash of the block</param>
        /// <param name="extrinsicIndex">The index of the extrinsic</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ExtrinsicDto> GetExtrinsicAsync(Hash blockHash, uint extrinsicIndex, CancellationToken cancellationToken);

        /// <summary>
        /// Get logs associated with the given block
        /// </summary>
        /// <param name="blockId">The ID of the block</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<LogDto>> GetLogsAsync(uint blockId, CancellationToken cancellationToken);
        #endregion

        #region Time
        /// <summary>
        /// Extract block information from the header
        /// </summary>
        /// <param name="header">The header</param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<(BlockNumber blockNumber, Hash blockHash, IBlockData blockDetails)> ExtractInformationsFromHeaderAsync(Header header, CancellationToken token);

        /// <summary>
        /// Get the status of the extrinsics
        /// </summary>
        /// <param name="events">The list of events</param>
        /// <param name="extrinsicIndex">The index of the extrinsic</param>
        /// <returns></returns>
        Task<ExtrinsicStatusDto> GetExtrinsicsStatusAsync(EventRecord[] events, int extrinsicIndex, CancellationToken cancellationToken);

        /// <summary>
        /// Get the fees of the extrinsics
        /// </summary>
        /// <param name="events">The list of events</param>
        /// <param name="extrinsicIndex">The index of the extrinsic</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<double?> GetExtrinsicsFeesAsync(EventRecord[] events, int extrinsicIndex, CancellationToken cancellationToken);
        Task<LifetimeDto?> GetExtrinsicsLifetimeAsync(uint blockNumber, IExtrinsic extrinsic, CancellationToken cancellationToken);
        #endregion
    }
}
