﻿using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.ChildBounties.Enums
{
    public enum Error
    {

        ParentBountyNotActive = 0,

        InsufficientBountyBalance = 1,

        TooManyChildBounties = 2,
    }

    /// <summary>
    /// >> 597 - Variant[pallet_child_bounties.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
