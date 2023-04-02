using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core.Display;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Xcm.v0.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Xcm.v1.Enums
{
    public enum Junction
    {

        Parachain = 0,

        AccountId32 = 1,

        AccountIndex64 = 2,

        AccountKey20 = 3,

        PalletInstance = 4,

        GeneralIndex = 5,

        GeneralKey = 6,

        OnlyChild = 7,

        Plurality = 8,
    }

    /// <summary>
    /// >> 124 - Variant[xcm.v1.junction.Junction]
    /// </summary>
    public sealed class EnumJunction : BaseEnumExt<Junction, BaseCom<U32>, BaseTuple<EnumNetworkId, Nameable>, BaseTuple<EnumNetworkId, BaseCom<U64>>, BaseTuple<EnumNetworkId, Nameable>, U8, BaseCom<U128>, Nameable, BaseVoid, BaseTuple<EnumBodyId, EnumBodyPart>>
    {
    }
}
