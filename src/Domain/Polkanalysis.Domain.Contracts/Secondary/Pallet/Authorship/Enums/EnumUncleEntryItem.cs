﻿using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Authorship.Enums
{
    public enum UncleEntryItem
    {

        InclusionHeight = 0,

        Uncle = 1,
    }

    /// <summary>
    /// >> 481 - Variant[pallet_authorship.UncleEntryItem]
    /// </summary>
    public sealed class EnumUncleEntryItem : BaseEnumExt<UncleEntryItem, Substrate.NetApi.Model.Types.Primitive.U32, BaseTuple<Hash, BaseOpt<SubstrateAccount>>>
    {
    }
}
