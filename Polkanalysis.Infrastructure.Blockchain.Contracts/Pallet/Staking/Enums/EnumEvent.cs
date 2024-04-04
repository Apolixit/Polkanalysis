using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking;
using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking.Enums
{
    [DomainMapping("pallet_staking/pallet/pallet")]
    public enum Event
    {

        EraPaid = 0,

        Rewarded = 1,

        Slashed = 2,

        OldSlashingReportDiscarded = 3,

        StakersElected = 4,

        Bonded = 5,

        Unbonded = 6,

        Withdrawn = 7,

        Kicked = 8,

        StakingElectionFailed = 9,

        Chilled = 10,

        PayoutStarted = 11,

        ValidatorPrefsSet = 12,
    }

    /// <summary>
    /// >> 39 - Variant[pallet_staking.pallet.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event,
        BaseTuple<U32, U128, U128>,
        BaseTuple<SubstrateAccount, U128>,
        BaseTuple<SubstrateAccount, U128>,
        U32,
        BaseVoid,
        BaseTuple<SubstrateAccount, U128>,
        BaseTuple<SubstrateAccount, U128>,
        BaseTuple<SubstrateAccount, U128>,
        BaseTuple<SubstrateAccount, SubstrateAccount>,
        BaseVoid,
        SubstrateAccount,
        BaseTuple<U32, SubstrateAccount>,
        BaseTuple<SubstrateAccount, ValidatorPrefs>>
    {
    }
}
