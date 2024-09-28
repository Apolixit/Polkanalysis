using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotPrimitive.v2.Enum
{
    [DomainMapping("polkadot_primitives/v2")]
    public enum InvalidDisputeStatementKind
    {

        Explicit = 0,
    }

    /// <summary>
    /// >> 403 - Variant[polkadot_primitives.v2.InvalidDisputeStatementKind]
    /// </summary>
    public sealed class EnumInvalidDisputeStatementKind : BaseEnum<InvalidDisputeStatementKind>
    {
    }
}
