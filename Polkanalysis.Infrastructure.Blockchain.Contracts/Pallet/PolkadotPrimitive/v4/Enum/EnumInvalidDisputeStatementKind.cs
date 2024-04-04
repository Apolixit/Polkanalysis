using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotPrimitive.v4.Enum
{
    [DomainMapping("polkadot_primitives/v4")]
    public enum InvalidDisputeStatementKind
    {
        Explicit = 0
    }

    /// <summary>
    /// >> 15067 - Variant[polkadot_primitives.v4.InvalidDisputeStatementKind]
    /// </summary>
    public sealed class EnumInvalidDisputeStatementKind : BaseEnum<InvalidDisputeStatementKind>
    {
    }
}
