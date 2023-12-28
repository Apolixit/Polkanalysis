using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Membership.Enums
{
    [DomainMapping("pallet_membership/pallet")]
    public enum Event
    {

        MemberAdded = 0,

        MemberRemoved = 1,

        MembersSwapped = 2,

        MembersReset = 3,

        KeyChanged = 4,

        Dummy = 5,
    }

    /// <summary>
    /// >> 70 - Variant[pallet_membership.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnum<Event>
    {
    }
}
