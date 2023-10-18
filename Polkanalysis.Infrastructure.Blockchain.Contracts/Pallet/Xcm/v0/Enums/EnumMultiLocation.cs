using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums
{
    public enum MultiLocation
    {

        Null = 0,

        X1 = 1,

        X2 = 2,

        X3 = 3,

        X4 = 4,

        X5 = 5,

        X6 = 6,

        X7 = 7,

        X8 = 8,
    }

    /// <summary>
    /// >> 153 - Variant[xcm.v0.multi_location.MultiLocation]
    /// </summary>
    public sealed class EnumMultiLocation : BaseEnumExt<MultiLocation, BaseVoid, EnumJunction, BaseTuple<EnumJunction, EnumJunction>, BaseTuple<EnumJunction, EnumJunction, EnumJunction>, BaseTuple<EnumJunction, EnumJunction, EnumJunction, EnumJunction>, BaseTuple<EnumJunction, EnumJunction, EnumJunction, EnumJunction, EnumJunction>, BaseTuple<EnumJunction, EnumJunction, EnumJunction, EnumJunction, EnumJunction, EnumJunction>, BaseTuple<EnumJunction, EnumJunction, EnumJunction, EnumJunction, EnumJunction, EnumJunction, EnumJunction>, BaseTuple<EnumJunction, EnumJunction, EnumJunction, EnumJunction, EnumJunction, EnumJunction, EnumJunction, EnumJunction>>
    {
    }
}
