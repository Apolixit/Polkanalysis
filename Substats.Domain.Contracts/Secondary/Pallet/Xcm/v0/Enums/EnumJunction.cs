using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Xcm.v0.Enums
{
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
    public sealed class EnumJunction : BaseEnumExt<Junction, BaseVoid, BaseCom<U32>, BaseTuple<EnumNetworkId, Nameable>, BaseTuple<EnumNetworkId, BaseCom<U64>>, BaseTuple<EnumNetworkId, Nameable>, U8, BaseCom<U128>, Nameable, BaseVoid, BaseTuple<EnumBodyId, EnumBodyPart>>
    {
    }
}
