using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Xcm.Enums
{
    public enum VersionedXcm
    {

        V0 = 0,

        V1 = 1,

        V2 = 2,
    }

    /// <summary>
    /// >> 435 - Variant[xcm.VersionedXcm]
    /// </summary>
    public sealed class EnumVersionedXcm : BaseEnumExt<VersionedXcm, v0.Enums.EnumXcm, v1.Enums.EnumXcm, v2.XcmT2>
    {
    }
}
