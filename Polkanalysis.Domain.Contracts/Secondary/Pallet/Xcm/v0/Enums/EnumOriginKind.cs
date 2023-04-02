using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Xcm.v0.Enums
{
    public enum OriginKind
    {

        Native = 0,

        SovereignAccount = 1,

        Superuser = 2,

        Xcm = 3,
    }

    /// <summary>
    /// >> 143 - Variant[xcm.v0.OriginKind]
    /// </summary>
    public sealed class EnumOriginKind : BaseEnum<OriginKind>
    {
    }
}
