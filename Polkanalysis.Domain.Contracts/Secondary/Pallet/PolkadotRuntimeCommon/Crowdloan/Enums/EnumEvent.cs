using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.PolkadotRuntimeCommon.Crowdloan.Enums
{
    public enum Event
    {

        Created = 0,

        Contributed = 1,

        Withdrew = 2,

        PartiallyRefunded = 3,

        AllRefunded = 4,

        Dissolved = 5,

        HandleBidResult = 6,

        Edited = 7,

        MemoUpdated = 8,

        AddedToNewRaise = 9,
    }

    /// <summary>
    /// >> 120 - Variant[polkadot_runtime_common.crowdloan.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Id, BaseTuple<SubstrateAccount, Id, U128>, BaseTuple<SubstrateAccount, Id, U128>, Id, Id, Id, BaseTuple<Id, EnumResult>, Id, BaseTuple<SubstrateAccount, Id, BaseVec<U8>>, Id>
    {
    }
}
