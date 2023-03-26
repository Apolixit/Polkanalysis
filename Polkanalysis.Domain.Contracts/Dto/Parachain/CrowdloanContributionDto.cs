using Substats.Domain.Contracts.Dto.Extrinsic;
using Substats.Domain.Contracts.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Dto.Parachain
{
    public class CrowdloanContributionDto
    {
        public required IEnumerable<CrowdloanContributionItem> Contributions { get; set; }
        public required UserAddressDto Account { get; set; }
        public required double TotalAmount { get; set; }

    }
}
