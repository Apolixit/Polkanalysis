using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Claims.Enum
{
    [DomainMapping("polkadot_runtime_common/claims")]
    public enum StatementKind
    {
        Regular = 0,
        Saft = 1
    }

    /// <summary>
    /// >> 11192 - Variant[polkadot_runtime_common.claims.StatementKind]
    /// </summary>
    public sealed class EnumStatementKind : BaseEnum<StatementKind>
    {
    }
}
