using Ajuna.NetApi.Model.Types.Base;
using Substats.Domain.Contracts.Secondary.Pallet.Xcm.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Xcm.Enums
{
    public enum Origin
    {

        Xcm = 0,

        Response = 1,
    }

    /// <summary>
    /// >> 261 - Variant[pallet_xcm.pallet.Origin]
    /// </summary>
    public sealed class EnumOrigin : BaseEnumExt<Origin, MultiLocation, MultiLocation>
    {
    }
}
