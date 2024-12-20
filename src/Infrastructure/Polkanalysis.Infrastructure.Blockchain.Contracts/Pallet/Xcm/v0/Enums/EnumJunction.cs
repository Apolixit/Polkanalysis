﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Display;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums
{
    [DomainMapping("xcm/v0/junction")]
    public enum Junction
    {

        Parent = 0,

        Parachain = 1,

        AccountId32 = 2,

        AccountIndex64 = 3,

        AccountKey20 = 4,

        PalletInstance = 5,

        GeneralIndex = 6,

        GeneralKey = 7,

        OnlyChild = 8,

        Plurality = 9,
    }

    /// <summary>
    /// >> 154 - Variant[xcm.v0.junction.Junction]
    /// </summary>
    public sealed class EnumJunction : BaseEnumExt<Junction, BaseVoid, BaseCom<U32>, BaseTuple<EnumNetworkId, NameableSize32>, BaseTuple<EnumNetworkId, BaseCom<U64>>, BaseTuple<EnumNetworkId, NameableSize20>, U8, BaseCom<U128>, BaseVec<U8>, BaseVoid, BaseTuple<EnumBodyId, EnumBodyPart>>
    {
    }
}
