﻿using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Indices.Enums
{
    public enum Event
    {

        IndexAssigned = 0,

        IndexFreed = 1,

        IndexFrozen = 2,
    }

    /// <summary>
    /// >> 35 - Variant[pallet_indices.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, 
        BaseTuple<SubstrateAccount, U32>, 
        U32, 
        BaseTuple<U32, SubstrateAccount>>
    {
    }
}
