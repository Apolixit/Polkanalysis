﻿using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums
{
    [DomainMapping("pallet_democracy/types")]
    public enum ReferendumInfo
    {

        Ongoing = 0,

        Finished = 1,
    }

    /// <summary>
    /// >> 532 - Variant[pallet_democracy.types.ReferendumInfo]
    /// </summary>
    public sealed class EnumReferendumInfo : BaseEnumExt<ReferendumInfo, ReferendumStatus, BaseTuple<Bool, U32>>
    {
    }
}
