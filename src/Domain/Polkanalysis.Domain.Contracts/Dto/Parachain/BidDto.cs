using Polkanalysis.Domain.Contracts.Dto.Extrinsic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Polkanalysis.Domain.Contracts.Dto.GlobalStatusDto;

namespace Polkanalysis.Domain.Contracts.Dto.Parachain
{
    public class BidDto
    {
        public uint AuctionId { get; set; }
        public required LeaseDto Lease { get; set; }
        public double BestBidAmount { get; set; }
        public ExtrinsicDto? BestBid { get; set; }
        public BidCampaignStatusDto Status { get; set; }
    }
}
