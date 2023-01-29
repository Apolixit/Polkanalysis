using Substats.Domain.Contracts.Dto.Extrinsic;
using Substats.Domain.Contracts.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Dto.Parachain
{
    public class CrowdloanContributionItem
    {
        public required ExtrinsicDto Extrinsic { get; set; }
        public required double Amount { get; set; }
        public required DateTime Date { get; set; }
        public required TimeSpan When { get; set; }
    }
}
