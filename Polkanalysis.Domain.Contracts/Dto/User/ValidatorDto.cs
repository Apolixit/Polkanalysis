using Substats.Domain.Contracts.Dto.Era;
using Substats.Domain.Contracts.Dto.Staking;
using Substats.Domain.Contracts.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Dto.User
{
    public class ValidatorDto
    {
        public required UserAddressDto StashAddress { get; set; }
        public required UserAddressDto ControllerAddress { get; set; }
        public required UserAddressDto RewardAddress { get; set; }
        public GlobalStatusDto.AliveStatusDto Status { get; set; }
        public required double SelfBonded { get; set; }
        public required double TotalBonded { get; set; }
        public required double Commission { get; set; }
        public required INode SessionKey { get; set; }
        public required IEnumerable<NominatorDto> Nominators { get; set; } = new List<NominatorDto>();
        public required IEnumerable<EraLightDto> Eras { get; set; } = new List<EraLightDto>();
        public required IEnumerable<RewardDto> Rewards { get; set; } = new List<RewardDto>();
    }
}
