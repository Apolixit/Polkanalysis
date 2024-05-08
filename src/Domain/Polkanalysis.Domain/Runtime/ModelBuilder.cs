using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Dto;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Dto.Common;
using Polkanalysis.Domain.Contracts.Dto.Event;
using Polkanalysis.Domain.Contracts.Dto.Extrinsic;
using Polkanalysis.Domain.Contracts.Runtime;
using Substrate.NetApi;

namespace Polkanalysis.Domain.Runtime
{
    public static class ModelBuilder
    {
        /// <summary>
        /// Build a date model from given date
        /// </summary>
        /// <param name="currentDate"></param>
        /// <returns></returns>
        public static DateDto BuildDateDto(DateTime currentDate)
        {
            return new DateDto()
            {
                Date = currentDate,
                When = TimeSpan.FromMilliseconds(DateTime.Now.Millisecond - currentDate.Millisecond),
                DisplayTime = DisplayElapsedTime(currentDate),
            };
        }

        /// <summary>
        /// Display in human readable time elapsed
        /// </summary>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        public static string DisplayElapsedTime(DateTime t1)
        {
            return DisplayElapsedTime(t1, DateTime.Now);
        }

        /// <summary>
        /// Display in human readable time elapsed between the first one and the second (t1 must be lower than t2)
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static string DisplayElapsedTime(DateTime t1, DateTime t2)
        {
            if (t1 > t2)
                throw new InvalidOperationException($"{nameof(t1)} must be a time before than {nameof(t2)}");

            return DisplayElapsedTime(t2.ToLocalTime() - t1.ToLocalTime());
        }

        /// <summary>
        /// Display in human readable time elapsed between the first one from now (t1 must be lower than now)
        /// </summary>
        /// <param name="t1"></param>
        /// <returns></returns>
        public static string DisplayElapsedTime(TimeSpan timeSpan)
        {
            var roundDown = (double val) => (int)Math.Floor(val);
            var spelling = (int val, string word) =>
            {
                return val switch
                {
                    > 1 => $"{word}s",
                    _ => word
                };
            };

            if (timeSpan.TotalDays > 1)
            {
                int days = roundDown(timeSpan.TotalDays);
                return $"{days} {spelling(days, "day")} ago";
            }
            else if (timeSpan.TotalHours > 1)
            {
                int hours = roundDown(timeSpan.TotalHours);
                return $"{hours} {spelling(hours, "hour")} ago";
            }
            else if (timeSpan.TotalMinutes > 1)
            {
                var minutes = roundDown(timeSpan.TotalMinutes);
                return $"{minutes} {spelling(minutes, "minute")} ago";
            }

            return "few seconds ago";
        }

        /// <summary>
        /// Create a tupple id
        /// For example, extrinsics and events are build with (BlockId - EventIndex)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static (uint mainId, uint subId) CreateTuppleIndex(string id)
        {
            if (id is null) throw new ArgumentNullException($"{nameof(id)}");

            var splitted = id.Split("-");
            if (splitted.Length != 2)
                throw new FormatException("Bad tupple identifier format");

            uint mainNumber = 0;
            uint secondaryIndex = 0;
            if (splitted is [string s1, string s2])
            {
                if (!uint.TryParse(s1, out mainNumber))
                    throw new InvalidOperationException("Bad first tupple value format");

                if (!uint.TryParse(s2, out secondaryIndex))
                    throw new InvalidOperationException("Bad second tupple value format");
            }

            return (mainNumber, secondaryIndex);
        }

        /// <summary>
        /// Create a block summary
        /// </summary>
        /// <param name="blockHash"></param>
        /// <param name="blockData"></param>
        /// <param name="blockDate"></param>
        /// <returns></returns>
        public static BlockLightDto BuildBlockLightDto(Hash blockHash, BlockData blockData, DateTime blockDate)
        {
            return new BlockLightDto()
            {
                Hash = blockHash,
                Number = blockData.Block.Header.Number.Value,
                Status = GlobalStatusDto.BlockStatusDto.Broadcasted,
                When = DisplayElapsedTime(blockDate)
            };
        }

        /// <summary>
        /// Create an full event details
        /// </summary>
        /// <param name="blockNumber"></param>
        /// <param name="eventNode"></param>
        /// <param name="eventIndex"></param>
        /// <param name="extrinsicIndex"></param>
        /// <returns></returns>
        public static EventDto BuildEventDto(uint blockNumber, IEventNode eventNode, uint eventIndex, uint? extrinsicIndex)
        {
            var treeDto = buildTreeDto(eventNode.EventData.Children);

            var eventDto = new EventDto(blockNumber,
                $"{blockNumber}-{eventIndex}",
                extrinsicIndex is not null ? $"{blockNumber}-{extrinsicIndex}" : string.Empty,
                eventNode.Method.ToString(),
                eventNode.Module.ToString(),
                    eventNode.Documentation,
                    treeDto);

            return eventDto;
        }

        private static List<TreeDto> buildTreeDto(IList<INode> nodes)
        {
            return nodes.Select(x => new TreeDto(x.Name, x.HumanData?.ToString() ?? "", buildTreeDto(x.Children))).ToList();
        }

        /// <summary>
        /// Create a full extrinsic details
        /// </summary>
        /// <param name="extrinsic"></param>
        /// <param name="blockNumber"></param>
        /// <param name="extrinsicNode"></param>
        /// <param name="extrinsicIndex"></param>
        /// <param name="moduleName"></param>
        /// <param name="callEvent"></param>
        /// <returns></returns>
        public static ExtrinsicDto BuildExtrinsicDto(Extrinsic extrinsic,
                                              uint blockNumber,
                                              INode extrinsicNode,
                                              uint extrinsicIndex,
                                              string moduleName,
                                              string callEvent)
        {
            var extrinsicDto = new ExtrinsicDto()
            {
                BlockNumber = blockNumber,
                Hash = Utils.Bytes2HexString(extrinsic.Encode()),
                ExtrinsicId = $"{blockNumber}-{extrinsicIndex}",
                Index = extrinsicIndex,
                PalletName = moduleName,
                CallEventName = callEvent,
            };

            return extrinsicDto;
        }

        /// <summary>
        /// Build a light dto object of an extrinsic
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static ExtrinsicLightDto BuildExtrinsicLightDto()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Build the documentation from a string array
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static string BuildDocumentation(string[] doc)
        {
            if (doc == null)
                return string.Empty;

            return string.Join("\n", doc);
        }
    }
}
