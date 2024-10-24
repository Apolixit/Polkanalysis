using Polkanalysis.Domain.Contracts.Dto.Staking.Reward;
using Polkanalysis.Domain.Contracts.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Staking.Nominator
{
    public class NominatorDto
    {
        public required UserIdentityDto StashAccount { get; set; }
        public required UserIdentityDto ControllerAccount { get; set; }
        public required UserIdentityDto? RewardAccount { get; set; }
        public required double Bonded { get; set; }
        public GlobalStatusDto.AliveStatusDto Status { get; set; }
        public IEnumerable<RewardDto> Rewards { get; set; } = new List<RewardDto>();
    }
}
