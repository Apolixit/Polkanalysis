using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.PolkadotRuntimeCommon.Slots.Enums
{
    public enum Event
    {

        NewLeasePeriod = 0,

        Leased = 1,
    }

    /// <summary>
    /// >> 118 - Variant[polkadot_runtime_common.slots.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, U32, BaseTuple<Id, SubstrateAccount, U32, U32, U128, U128>>
    {
    }
}
