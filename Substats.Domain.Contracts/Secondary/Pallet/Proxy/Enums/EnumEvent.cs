﻿using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Proxy.Enums
{
    public enum Event
    {

        ProxyExecuted = 0,

        PureCreated = 1,

        Announced = 2,

        ProxyAdded = 3,

        ProxyRemoved = 4,
    }

    /// <summary>
    /// >> 78 - Variant[pallet_proxy.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, EnumResult, BaseTuple<SubstrateAccount, SubstrateAccount, EnumProxyType, U16>, BaseTuple<SubstrateAccount, SubstrateAccount, Hash>, BaseTuple<SubstrateAccount, SubstrateAccount, EnumProxyType, U32>, BaseTuple<SubstrateAccount, SubstrateAccount, EnumProxyType, U32>>
    {
    }
}