using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;
using Blazscan.Domain.Contracts.Dto.Block;
using Blazscan.Domain.Contracts.Dto.Event;
using Blazscan.Domain.Contracts.Dto.Extrinsic;
using Blazscan.Domain.Contracts.Runtime;

namespace Blazscan.Domain.Contracts.Dto
{
    public interface IModelBuilder
    {
        /// <summary>
        /// Display in human readable time elapsed
        /// </summary>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        string DisplayElapsedTime(TimeSpan timeSpan);

        /// <summary>
        /// Display in human readable time elapsed between the first one and the second (t1 must be lower than t2)
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        string DisplayElapsedTime(DateTime t1, DateTime t2);

        /// <summary>
        /// Display in human readable time elapsed between the first one from now (t1 must be lower than now)
        /// </summary>
        /// <param name="t1"></param>
        /// <returns></returns>
        string DisplayElapsedTime(DateTime t1);

        /// <summary>
        /// Create a block summary
        /// </summary>
        /// <param name="blockHash"></param>
        /// <param name="blockData"></param>
        /// <param name="blockDate"></param>
        /// <returns></returns>
        public BlockLightDto BuildBlockLightDto(Hash blockHash, BlockData blockData, DateTime blockDate);


        /// <summary>
        /// Create an full event details
        /// </summary>
        /// <param name="blockLightDto"></param>
        /// <param name="eventRecord"></param>
        /// <returns></returns>
        public EventDto BuildEventDto(BlockLightDto blockLightDto, INode eventNode);

        /// <summary>
        /// Create a light event details
        /// </summary>
        /// <param name="blockLightDto"></param>
        /// <param name="eventNode"></param>
        /// <returns></returns>
        public EventLightDto BuildEventLightDto(INode eventNode);

        /// <summary>
        /// Create a full extrinsic details
        /// </summary>
        /// <param name="extrinsic"></param>
        /// <param name="blockLight"></param>
        /// <param name="extrinsicNode"></param>
        /// <param name="extrinsicIndex"></param>
        /// <returns></returns>
        public ExtrinsicDto BuildExtrinsicDto(Ajuna.NetApi.Model.Extrinsics.Extrinsic extrinsic, BlockLightDto blockLight, INode extrinsicNode, int extrinsicIndex);
        public ExtrinsicLightDto BuildExtrinsicLightDto();
    }
}
