using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Parachain.Crowdloan
{
    public class CrowdloanListDto
    {
        public required string CrowdloanId { get; set; }
        public required LeaseDto Lease { get; set; }
        public required double FundTarget { get; set; } = 0;
        public required double FundRaised { get; set; } = 0;
    }
}
