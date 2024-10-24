using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Treasury.Enums
{
    [DomainMapping("pallet_treasury/pallet")]
    public enum Event
    {

        Proposed = 0,

        Spending = 1,

        Awarded = 2,

        Rejected = 3,

        Burnt = 4,

        Rollover = 5,

        Deposit = 6,

        SpendApproved = 7,

        UpdatedInactive = 8
    }

    /// <summary>
    /// >> 71 - Variant[pallet_treasury.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, U32, U128, BaseTuple<U32, U128, SubstrateAccount>, BaseTuple<U32, U128>, U128, U128, U128, BaseTuple<U32, U128, SubstrateAccount>,
        BaseTuple<U128, U128>>
    {
    }
}
