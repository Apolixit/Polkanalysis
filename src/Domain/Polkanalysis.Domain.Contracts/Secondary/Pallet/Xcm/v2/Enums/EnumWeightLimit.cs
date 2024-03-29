﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Xcm.v2.Enums
{
    public enum WeightLimit
    {

        Unlimited = 0,

        Limited = 1,
    }

    /// <summary>
    /// >> 148 - Variant[xcm.v2.WeightLimit]
    /// </summary>
    public sealed class EnumWeightLimit : BaseEnumExt<WeightLimit, BaseVoid, BaseCom<U64>>
    {
    }
}
