﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums
{
    [DomainMapping("xcm/v0/junction")]
    public enum NetworkId
    {

        Any = 0,

        Named = 1,

        Polkadot = 2,

        Kusama = 3,
    }

    /// <summary>
    /// >> 126 - Variant[xcm.v0.junction.NetworkId]
    /// </summary>
    public sealed class EnumNetworkId : BaseEnumExt<NetworkId, BaseVoid, BaseVec<U8>, BaseVoid, BaseVoid>
    {
    }
}
