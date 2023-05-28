using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.User
{
    public class NominatorLightDto
    {
        public UserAddressDto StashAccount { get; set; }
        public UserAddressDto? ControllerAccount { get; set; }
        public UserAddressDto? RewardAccount { get; set; }
        public double Bonded { get; set; }
        public GlobalStatusDto.AliveStatusDto Status { get; set; }
    }
}
