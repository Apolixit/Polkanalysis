﻿using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;
using Substats.Domain.Contracts.Dto.Block;
using Substats.Domain.Contracts.Dto.Common;
using Substats.Domain.Contracts.Dto.Event;
using Substats.Domain.Contracts.Dto.Extrinsic;
using Substats.Domain.Contracts.Runtime;

namespace Substats.Domain.Contracts.Dto
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

        public string BuildDocumentation(string[] doc);
    }
}