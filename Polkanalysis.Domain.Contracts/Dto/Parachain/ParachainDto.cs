using Polkanalysis.Domain.Contracts.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Parachain
{
    public class ParachainDto
    {
        public int ParachainId { get; set; }
        public UserAddressDto OwnerAccount { get; set; }
        public UserAddressDto FundAccount { get; set; }
        public int ValidatorCount { get; set; }
        public object SlotType { get; set; }
        public string RegisterStatus { get; set; }
        public LeaseDto Lease { get; set; }

        public IEnumerable<ParachainTimelineDto> Timeline { get; set; } = Enumerable.Empty<ParachainTimelineDto>();
    }
}
