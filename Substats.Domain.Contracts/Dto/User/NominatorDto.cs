using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Dto.User
{
    public class NominatorDto
    {
        public required string StashAddress { get; set; }
        public required string ControllerAddress { get; set; }
        public required string RewardAddress { get; set; }
        public required double Bonded { get; set; }
        public GlobalStatusDto.AliveStatusDto Status { get; set; }
    }
}
