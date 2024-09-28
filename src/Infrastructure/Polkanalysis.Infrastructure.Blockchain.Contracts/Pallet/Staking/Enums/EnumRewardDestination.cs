using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking.Enums
{
    [DomainMapping("pallet_staking")]
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
