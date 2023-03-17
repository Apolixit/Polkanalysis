using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Xcm.v1.Enums
{
    public enum Response
    {

        Assets = 0,

        Version = 1,
    }

    /// <summary>
    /// >> 434 - Variant[xcm.v1.Response]
    /// </summary>
    public sealed class EnumResponse : BaseEnumExt<Response, MultiAssets, U32>
    {
    }
}
