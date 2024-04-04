using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Slots.Enums
{
    [DomainMapping("polkadot_runtime_common/slots/pallet")]
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
