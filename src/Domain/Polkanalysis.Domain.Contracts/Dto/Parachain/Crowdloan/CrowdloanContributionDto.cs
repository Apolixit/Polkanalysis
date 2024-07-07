using Polkanalysis.Domain.Contracts.Dto.Extrinsic;
using Polkanalysis.Domain.Contracts.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Parachain.Crowdloan
{
    public class CrowdloanContributionDto
    {
        public required IEnumerable<CrowdloanContributionItem> Contributions { get; set; }
        public required UserIdentityDto Account { get; set; }
        public required double TotalAmount { get; set; }

    }
}
