﻿using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Democracy.Enums
{
    public enum Conviction
    {

        None = 0,

        Locked1x = 1,

        Locked2x = 2,

        Locked3x = 3,

        Locked4x = 4,

        Locked5x = 5,

        Locked6x = 6,
    }

    /// <summary>
    /// >> 235 - Variant[pallet_democracy.conviction.Conviction]
    /// </summary>
    public sealed class EnumConviction : BaseEnum<Conviction>
    {
    }
}
