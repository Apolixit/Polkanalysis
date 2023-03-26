using Substats.Domain.Contracts.Dto.Block;
using Substats.Domain.Contracts.Dto.Event;
using Substats.Domain.Contracts.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Substats.Domain.Contracts.Dto.GlobalStatusDto;

namespace Substats.Domain.Contracts.Dto.Parachain
{
    public class CrowdloanDto
    {
        public required ParachainDto Parachain { get; set; }

        /// <summary>
        /// Shortcut to Parachain owner account
        /// </summary>
        public UserAddressDto OwnerAccount => Parachain.OwnerAccount;

        public required UserAddressDto FundAccount { get; set; }
        public string HeadData { get; set; } = string.Empty;

        public string Verifier { get; set; } = string.Empty;

        public required LeaseDto Lease { get; set; }
        /// <summary>
        /// Potentially winning auction if this crowdloan won
        /// </summary>
        public AuctionDto? WinningAuction { get; set; }

        /// <summary>
        /// Auction paraticipation
        /// </summary>
        public IEnumerable<AuctionDto> ParticipatedAuctions { get; set; } = Enumerable.Empty<AuctionDto>();

        public required BigInteger FundTarget { get; set; } = 0;
        public required BigInteger FundRaised { get; set; } = 0;

        

        public CrowdloanStatusDto CrowdloanStatus { get; set; }

        /// <summary>
        /// All events related to this crowdloan
        /// </summary>
        public IEnumerable<EventDto> Events { get; set; } = Enumerable.Empty<EventDto>();

        /// <summary>
        /// Contribution to this crowdloan
        /// </summary>
        public IEnumerable<CrowdloanContributionDto> Contributors { get; set; } = Enumerable.Empty<CrowdloanContributionDto>();
    }
}
