﻿using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.BagsList.Enums
{
    public enum Event
    {

        Rebagged = 0,

        ScoreUpdated = 1,
    }

    /// <summary>
    /// >> 89 - Variant[pallet_bags_list.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<SubstrateAccount, U64, U64>, BaseTuple<SubstrateAccount, U64>>
    {
    }
}