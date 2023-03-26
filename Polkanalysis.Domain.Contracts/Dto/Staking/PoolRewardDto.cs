using Substats.Domain.Contracts.Dto.Event;
using Substats.Domain.Contracts.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Dto.Staking
{
    public class PoolRewardDto
    {
        public required IEnumerable<EventDto> RewardEvents { get; set; }
        public required UserAddressDto ValidatorStashAccount { get; set; }
        public required UserAddressDto RewardAccount { get; set; }
        public required uint EraId { get; set; }
        public double RewardAmount { get; set; }

    }
}
