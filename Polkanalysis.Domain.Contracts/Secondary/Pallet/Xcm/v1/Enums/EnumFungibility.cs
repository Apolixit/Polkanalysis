using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Xcm.v1.Enums
{
    public enum Fungibility
    {

        Fungible = 0,

        NonFungible = 1,
    }

    /// <summary>
    /// >> 137 - Variant[xcm.v1.multiasset.Fungibility]
    /// </summary>
    public sealed class EnumFungibility : BaseEnumExt<Fungibility, BaseCom<U128>, EnumAssetInstance>
    {
    }
}
