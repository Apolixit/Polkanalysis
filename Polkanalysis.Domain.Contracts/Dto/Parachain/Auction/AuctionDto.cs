using Polkanalysis.Domain.Contracts.Dto.Block;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Polkanalysis.Domain.Contracts.Dto.GlobalStatusDto;

namespace Polkanalysis.Domain.Contracts.Dto.Parachain.Auction
{
    public class AuctionDto
    {
        public uint AuctionId { get; set; }
        public required AuctionStatusDto Status { get; set; }
        public required LeaseDto Lease { get; set; }
        public BlockLightDto? EndingPeriodStart { get; set; }
        public BlockLightDto? RetroactiveEndingBlock { get; set; }
        public ParachainDto? Winner { get; set; }
    }
}
