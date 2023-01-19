using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Dto.User
{
    public class ValidatorDto
    {
        public required int Number { get; set; }
        public required string StashAddress { get; set; }
        public required string ControllerAddress { get; set; }
        public required string RewardAddress { get; set; }
        public GlobalStatusDto.AliveStatusDto Status { get; set; }
        public required double SelfBonded { get; set; }
        public required double TotalBonded { get; set; }
        public required double Commission { get; set; }
        public IEnumerable<NominatorDto> Nominators { get; set; } = new List<NominatorDto>();
    }
}
