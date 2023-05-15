using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core.Display;
using Polkanalysis.Domain.Contracts.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Scheduler.Enums
{
    public enum Event
    {

        Scheduled = 0,

        Canceled = 1,

        Dispatched = 2,

        CallUnavailable = 3,

        PeriodicFailed = 4,

        PermanentlyOverweight = 5,
    }

    /// <summary>
    /// >> 29 - Variant[pallet_scheduler.pallet.Event]
    /// Events type.
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, 
        BaseTuple<U32>, 
        BaseTuple<U32>, 
        BaseTuple<BaseTuple<U32>, BaseOpt<FlexibleNameable>, EnumResult>, 
        BaseTuple<BaseTuple<U32>, BaseOpt<FlexibleNameable>>, 
        BaseTuple<BaseTuple<U32>, BaseOpt<FlexibleNameable>>, 
        BaseTuple<BaseTuple<U32>, BaseOpt<FlexibleNameable>>>
    {
    }
}
