using Polkanalysis.Domain.Contracts.Dto.Extrinsic;
using Polkanalysis.Domain.Contracts.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Parachain.Crowdloan
{
    public class CrowdloanContributionItem
    {
        public required ExtrinsicDto Extrinsic { get; set; }
        public required double Amount { get; set; }
        public required DateTime Date { get; set; }
        public required TimeSpan When { get; set; }
    }
}
