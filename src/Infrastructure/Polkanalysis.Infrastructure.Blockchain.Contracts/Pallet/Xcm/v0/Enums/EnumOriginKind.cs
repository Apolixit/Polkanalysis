using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums
{
    [DomainMapping("xcm/v0")]
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
