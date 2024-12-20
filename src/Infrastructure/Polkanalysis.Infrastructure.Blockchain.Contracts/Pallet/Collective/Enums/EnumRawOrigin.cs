﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Collective.Enums
{
    [DomainMapping("pallet_collective")]
    public enum RawOrigin
    {

        Members = 0,

        Member = 1,

        _Phantom = 2,
    }

    /// <summary>
    /// >> 259 - Variant[pallet_collective.RawOrigin]
    /// </summary>
    public sealed class EnumRawOrigin : BaseEnumExt<RawOrigin, BaseTuple<U32, U32>, SubstrateAccount, BaseVoid>
    {
    }
}
