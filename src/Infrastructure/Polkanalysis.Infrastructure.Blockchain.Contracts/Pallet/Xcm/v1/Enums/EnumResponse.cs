﻿using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums
{
    [DomainMapping("xcm/v1")]
    public enum Response
    {

        Assets = 0,

        Version = 1,
    }

    /// <summary>
    /// >> 434 - Variant[xcm.v1.Response]
    /// </summary>
    public sealed class EnumResponse : BaseEnumExt<Response, MultiAssets, U32>
    {
    }
}
