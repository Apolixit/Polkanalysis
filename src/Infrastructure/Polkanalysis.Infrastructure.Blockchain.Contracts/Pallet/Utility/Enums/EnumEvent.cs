﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Enum;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Error;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Utility.Enums
{
    [DomainMapping("pallet_utility/pallet")]
    public enum Event
    {

        BatchInterrupted = 0,

        BatchCompleted = 1,

        BatchCompletedWithErrors = 2,

        ItemCompleted = 3,

        ItemFailed = 4,

        DispatchedAs = 5,
    }

    /// <summary>
    /// >> 76 - Variant[pallet_utility.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<U32, EnumDispatchError>, BaseVoid, BaseVoid, BaseVoid, EnumDispatchError, EnumResult>
    {
    }
}
