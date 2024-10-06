using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Enum;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Display;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Scheduler.Enums
{
    [DomainMapping("pallet_scheduler/pallet")]
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
        BaseTuple<BaseTuple<U32>, BaseOpt<NameableSize32>, EnumResult>,
        BaseTuple<BaseTuple<U32>, BaseOpt<NameableSize32>>,
        BaseTuple<BaseTuple<U32>, BaseOpt<NameableSize32>>,
        BaseTuple<BaseTuple<U32>, BaseOpt<NameableSize32>>>
    {
    }
}
