using Polkanalysis.Domain.Contracts.Dto.Event;
using Polkanalysis.Domain.Contracts.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Staking.Reward
{
    public class RewardDto
    {
        public required EventLightDto Event { get; set; }
        public required uint EraId { get; set; }
        public required UserIdentityDto StashAccount { get; set; }
        public required UserIdentityDto RewardAccount { get; set; }
        public double RewardAmount { get; set; } = 0;
        public required DateTime Date { get; set; }
        public required TimeSpan When { get; set; }

    }
}
