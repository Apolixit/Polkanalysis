using Substats.Domain.Contracts.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Dto.Parachain
{
    public class ParachainDto
    {
        public int ParachainId { get; set; }
        public required UserAddressDto OwnerAccount { get; set; }
        public required UserAddressDto FundAccount { get; set; }
        public int ValidatorCount { get; set; }
        public object SlotType { get; set; }
        public object RegisterStatus { get; set; }
        public required LeaseDto Lease { get; set; }

        public IEnumerable<ParachainTimelineDto> Timeline { get; set; } = Enumerable.Empty<ParachainTimelineDto>();
    }
}
