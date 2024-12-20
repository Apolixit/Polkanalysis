﻿using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Tips.Enums
{
    [DomainMapping("pallet_tips/pallet")]
    public enum Error
    {

        ReasonTooBig = 0,

        AlreadyKnown = 1,

        UnknownTip = 2,

        NotFinder = 3,

        StillOpen = 4,

        Premature = 5,
    }

    /// <summary>
    /// >> 599 - Variant[pallet_tips.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
