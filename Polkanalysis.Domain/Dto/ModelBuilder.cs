using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Dto;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Dto.Common;
using Polkanalysis.Domain.Contracts.Dto.Event;
using Polkanalysis.Domain.Contracts.Dto.Extrinsic;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotRuntime;
using Polkanalysis.Domain.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Dto
{
    public class ModelBuilder : IModelBuilder
    {
        public DateDto BuildDateDto(DateTime currentDate)
        {
            return new DateDto()
            {
                Date = currentDate,
                When = TimeSpan.FromMilliseconds(DateTime.Now.Millisecond - currentDate.Millisecond),
                DisplayTime = DisplayElapsedTime(currentDate),
            };
        }

        public string DisplayElapsedTime(DateTime t1)
        {
            return DisplayElapsedTime(t1, DateTime.Now);
        }

        public string DisplayElapsedTime(DateTime t1, DateTime t2)
        {
            if (t1 > t2)
                throw new InvalidOperationException($"{nameof(t1)} must be a time before than {nameof(t2)}");

            return DisplayElapsedTime(t2 - t1);
        }

        public string DisplayElapsedTime(TimeSpan timeSpan)
        {
            var roundDown = (double val) => (int)Math.Floor(val);
            var spelling = (int val, string word) => {
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

        public (uint mainId, uint subId) CreateTuppleIndex(string id)
        {
            if (id == null) throw new ArgumentNullException($"{nameof(id)}");

            var splitted = id.Split("-");
            if (splitted == null || splitted.Length != 2) throw new FormatException("Bad tupple identifier format");

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

        public BlockLightDto BuildBlockLightDto(Hash blockHash, BlockData blockData, DateTime blockDate)
        {
            return new BlockLightDto()
            {
                Hash = blockHash,
                Number = blockData.Block.Header.Number.Value,
                Status = GlobalStatusDto.BlockStatusDto.Broadcasted,
                When = DisplayElapsedTime(blockDate)
            };
        }

        public EventDto BuildEventDto(BlockLightDto blockLightDto, INode eventNode)
        {
            var enumEvent = eventNode.Find(typeof(EnumRuntimeEvent));
            if (enumEvent == null || enumEvent.First().Children.Count == 0) throw new InvalidOperationException("Try to build event dto while node parameter is not a valid event.");

            var pallet = enumEvent.First().Children.First();
            var eventDto = new EventDto()
            {
                EventSummary = new EventLightDto()
                {
                    Block = blockLightDto,
                    EventName = pallet.Children.First().HumanData.ToString(),
                    PalletName = pallet.HumanData.ToString(),
                },                
                Decoded = eventNode,
            };

            return eventDto;
        }

        public EventLightDto BuildEventLightDto(INode eventNode)
        {
            var eventDto = new EventLightDto()
            {
                EventName = eventNode.HumanData.ToString(),
                PalletName = eventNode.Children.First().HumanData.ToString(),
                Description = string.Empty,
            };

            return eventDto;
        }

        public ExtrinsicDto BuildExtrinsicDto(
            Extrinsic extrinsic,
            BlockLightDto blockLight,
            INode extrinsicNode,
            uint extrinsicIndex)
        {
            // TODO: for extrinsic Hash, need extrinsic.Encode()
            var extrinsicDto = new ExtrinsicDto()
            {
                Block = blockLight,
                Hash = new Hash(),
                Decoded = extrinsicNode,
                ExtrinsicId = $"{blockLight.Number}-{extrinsicIndex}",
                Index = extrinsicIndex,
                PalletCall = extrinsicNode.HumanData.ToString(),
                PalletName = extrinsicNode.Children.First().HumanData.ToString(),
            };

            return extrinsicDto;
        }

        public ExtrinsicLightDto BuildExtrinsicLightDto()
        {
            throw new NotImplementedException();
        }

        public string BuildDocumentation(string[] doc)
        {
            if (doc == null)
                return string.Empty;
                //throw new ArgumentNullException($"{nameof(doc)}");

            return string.Join("\n", doc);
        }

        
    }
}
