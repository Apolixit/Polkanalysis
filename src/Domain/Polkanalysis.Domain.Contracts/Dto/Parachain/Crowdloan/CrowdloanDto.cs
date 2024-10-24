using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Dto.Event;
using Polkanalysis.Domain.Contracts.Dto.Parachain.Auction;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Multi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Polkanalysis.Domain.Contracts.Dto.GlobalStatusDto;

namespace Polkanalysis.Domain.Contracts.Dto.Parachain.Crowdloan
{
    public class CrowdloanDto
    {
        public required uint CrowdloanId { get; set; }

        /// <summary>
        /// Parachain linked
        /// </summary>
        public ParachainDto? Parachain { get; set; }

        /// <summary>
        /// Crownloan creator
        /// </summary>
        public required UserIdentityDto Depositor { get; set; }

        public required uint FundIndex { get; set; }
        public string HeadData { get; set; } = string.Empty;

        public EnumMultiSigner? Verifier { get; set; } = default;

        public required LeaseDto Lease { get; set; }
        /// <summary>
        /// Potentially winning auction if this crowdloan won
        /// </summary>
        public AuctionDto? WinningAuction { get; set; }

        /// <summary>
        /// Auction paraticipation
        /// </summary>
        public IEnumerable<AuctionDto> ParticipatedAuctions { get; set; } = Enumerable.Empty<AuctionDto>();

        public required double FundTarget { get; set; } = 0;
        public required double FundRaised { get; set; } = 0;

        /// <summary>
        /// Last block when someone contribute before ending
        /// </summary>
        public BlockLightDto? LastBlockContribution { get; set; }

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
