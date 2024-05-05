using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Dto.Common;
using Polkanalysis.Domain.Contracts.Dto.Event;
using Polkanalysis.Domain.Contracts.Dto.Extrinsic;
using Polkanalysis.Domain.Contracts.Runtime;

namespace Polkanalysis.Domain.Contracts.Dto
{
    public interface IModelBuilder
    {
        /// <summary>
        /// Build a date model from given date
        /// </summary>
        /// <param name="currentDate"></param>
        /// <returns></returns>
        DateDto BuildDateDto(DateTime currentDate);

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
        /// Create a tupple id
        /// For example, extrinsics and events are build with (BlockId - EventIndex)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        (uint mainId, uint subId) CreateTuppleIndex(string id);

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
        public EventDto BuildEventDto(BlockLightDto blockLightDto, IEventNode eventNode, uint eventIndex, uint? extrinsicIndex);

        /// <summary>
        /// Create a full extrinsic details
        /// </summary>
        /// <param name="extrinsic"></param>
        /// <param name="blockLight"></param>
        /// <param name="extrinsicNode"></param>
        /// <param name="extrinsicIndex"></param>
        /// <returns></returns>
        public ExtrinsicDto BuildExtrinsicDto(Substrate.NetApi.Model.Extrinsics.Extrinsic extrinsic, BlockLightDto blockLight, INode extrinsicNode, uint extrinsicIndex, string moduleName, string callEvent);
        public ExtrinsicLightDto BuildExtrinsicLightDto();

        public string BuildDocumentation(string[] doc);
    }
}
