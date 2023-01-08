using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;
using Blazscan.Domain.Contracts.Dto;
using Blazscan.Domain.Contracts.Dto.Block;
using Blazscan.Domain.Contracts.Dto.Event;
using Blazscan.Domain.Contracts.Dto.Extrinsic;
using Blazscan.Domain.Contracts.Runtime;
using Blazscan.Domain.Runtime;
using Blazscan.Polkadot.NetApiExt.Generated.Model.frame_system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Domain.Dto
{
    public class ModelBuilder : IModelBuilder
    {
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
            if (timeSpan.TotalMinutes > 1)
            {
                return $"{timeSpan.TotalMinutes} ago";
            }
            else if (timeSpan.TotalHours > 1)
            {
                return $"{timeSpan.TotalHours} ago";
            }
            else if (timeSpan.TotalDays > 1)
            {
                return $"{timeSpan.TotalDays} ago";
            }

            return "few seconds ago";
        }

        public BlockLightDto BuildBlockLightDto(Hash blockHash, BlockData blockData, DateTime blockDate)
        {
            return new BlockLightDto()
            {
                Hash = blockHash,
                Number = blockData.Block.Header.Number.Value,
                Status = StatusDto.Broadcasted,
                When = DisplayElapsedTime(blockDate)
            };
        }

        public EventDto BuildEventDto(BlockLightDto blockLightDto, INode eventNode)
        {
            var eventDto = new EventDto()
            {
                Block = blockLightDto,
                EventName = eventNode.HumanData.ToString(),
                PalletName = eventNode.Children.First().HumanData.ToString(),
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
            int extrinsicIndex)
        {
            // TODO: for extrinsic Hash, need extrinsic.Encode()
            var extrinsicDto = new ExtrinsicDto()
            {
                Block = blockLight,
                Hash = new Hash(),
                Decoded = extrinsicNode,
                Number = $"{blockLight.Number}-{extrinsicIndex}",
                PalletCall = extrinsicNode.HumanData.ToString(),
                PalletName = extrinsicNode.Children.First().HumanData.ToString(),
            };

            return extrinsicDto;
        }

        public ExtrinsicLightDto BuildExtrinsicLightDto()
        {
            throw new NotImplementedException();
        }

        
    }
}
