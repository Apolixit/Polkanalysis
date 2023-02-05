using Ajuna.NetApi.Model.Types.Base;
using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Staking
{
    public enum RewardDestination
    {

        Staked = 0,

        Stash = 1,

        Controller = 2,

        Account = 3,

        None = 4,
    }

    public sealed class EnumRewardDestination : BaseEnumExt<RewardDestination, BaseVoid, BaseVoid, BaseVoid, SubstrateAccount, BaseVoid>
    {
    }
}
