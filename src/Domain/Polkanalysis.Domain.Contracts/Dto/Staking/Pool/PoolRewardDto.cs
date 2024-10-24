using Polkanalysis.Domain.Contracts.Dto.Event;
using Polkanalysis.Domain.Contracts.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Staking.Pool
{
    public class PoolRewardDto
    {
        public required IEnumerable<EventDto> RewardEvents { get; set; }
        public required UserIdentityDto ValidatorStashAccount { get; set; }
        public required UserIdentityDto RewardAccount { get; set; }
        public required uint EraId { get; set; }
        public double RewardAmount { get; set; }

    }
}
