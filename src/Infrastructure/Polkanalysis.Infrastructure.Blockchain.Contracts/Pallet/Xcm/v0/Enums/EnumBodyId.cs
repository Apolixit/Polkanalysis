﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums
{
    [DomainMapping("xcm/v0/junction")]
    public enum BodyId
    {

        Unit = 0,

        Named = 1,

        Index = 2,

        Executive = 3,

        Technical = 4,

        Legislative = 5,

        Judicial = 6,
    }

    /// <summary>
    /// >> 128 - Variant[xcm.v0.junction.BodyId]
    /// </summary>
    public sealed class EnumBodyId : BaseEnumExt<BodyId, BaseVoid, BaseVec<U8>, BaseCom<U32>, BaseVoid, BaseVoid, BaseVoid, BaseVoid>
    {
    }
}
