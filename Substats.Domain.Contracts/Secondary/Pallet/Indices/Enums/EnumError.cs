﻿using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Indices.Enums
{
    public enum Error
    {

        NotAssigned = 0,

        NotOwner = 1,

        InUse = 2,

        NotTransfer = 3,

        Permanent = 4,
    }

    /// <summary>
    /// >> 469 - Variant[pallet_indices.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
