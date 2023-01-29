using Microsoft;
using Substats.Domain.Contracts.Dto.Event;
using Substats.Domain.Contracts.Dto.User;
using Substats.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Substats.Domain.Contracts.Dto.GlobalStatusDto;

namespace Substats.Domain.Contracts.Dto.Staking
{
    public class PoolDto
    {
        public required string Name { get; set; }
        public required PoolGlobalSettingsDto PoolGlobalSettings { get; set; }
        public required UserAddressDto StashAccount { get; set; }
        public required UserAddressDto RewardAccount { get; set; }
        public required UserAddressDto CreatorAccount { get; set; }
        public required UserAddressDto RootAccount { get; set; }
        public required UserAddressDto TogglerAccount { get; set; }
        public required UserAddressDto NominatorAccount { get; set; }
        public required BigInteger RewardPool { get; set; }
        public required BigInteger TotalBonded { get; set; }
        public uint MemberCount { get; set; }
        public string Metadata { get; set; }
        public NominationPoolStatusDto Status { get; set; }
        public IEnumerable<PoolMemberDto> Members { get; set; } = Enumerable.Empty<PoolMemberDto>();
        public IEnumerable<ValidatorDto> ValidatorsSelected { get; set; } = Enumerable.Empty<ValidatorDto>();

        /// <summary>
        /// All events link to this pool
        /// </summary>
        public required IEnumerable<EventDto> Events { get; set; }

        /// <summary>
        /// All Events minus Reward events minus Payout events
        /// </summary>
        public required IEnumerable<EventDto> ContextEvents { get; set; }

        /// <summary>
        /// Staking > Rewarded
        /// </summary>
        public IEnumerable<PoolRewardDto> RewardEvents { get; set; } = Enumerable.Empty<PoolRewardDto>();

        /// <summary>
        /// Nomination pool > Payout
        /// </summary>
        public required IEnumerable<PoolPayoutDto> PayoutEvents { get; set; } = Enumerable.Empty<PoolPayoutDto>();

    }
}
