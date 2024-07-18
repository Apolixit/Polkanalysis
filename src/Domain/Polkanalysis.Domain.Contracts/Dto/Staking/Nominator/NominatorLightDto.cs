using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Dto.User;

namespace Polkanalysis.Domain.Contracts.Dto.Staking.Nominator
{
    public class NominatorLightDto
    {
        public UserIdentityDto StashAccount { get; set; }
        public UserIdentityDto? ControllerAccount { get; set; }
        public UserIdentityDto? RewardAccount { get; set; }
        public double Bonded { get; set; }
        public int NbMembers { get; set; }
        public GlobalStatusDto.AliveStatusDto Status { get; set; }
    }
}
