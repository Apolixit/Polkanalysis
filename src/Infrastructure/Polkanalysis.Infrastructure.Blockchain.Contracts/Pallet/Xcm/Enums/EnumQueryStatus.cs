﻿using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums
{
    [DomainMapping("pallet_xcm/pallet")]
    public enum QueryStatus
    {

        Pending = 0,

        VersionNotifier = 1,

        Ready = 2,
    }

    /// <summary>
    /// >> 715 - Variant[pallet_xcm.pallet.QueryStatus]
    /// </summary>
    public sealed class EnumQueryStatus : BaseEnumExt<QueryStatus, BaseTuple<EnumVersionedMultiLocation, BaseOpt<BaseTuple<U8, U8>>, U32>, BaseTuple<EnumVersionedMultiLocation, Bool>, BaseTuple<EnumVersionedResponse, U32>>
    {
    }
}
