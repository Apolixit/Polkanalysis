﻿using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Xcm.v1.Enums
{
    public enum MultiAssetFilter
    {

        Definite = 0,

        Wild = 1,
    }

    /// <summary>
    /// >> 145 - Variant[xcm.v1.multiasset.MultiAssetFilter]
    /// </summary>
    public sealed class EnumMultiAssetFilter : BaseEnumExt<MultiAssetFilter, MultiAssets, EnumWildMultiAsset>
    {
    }
}
