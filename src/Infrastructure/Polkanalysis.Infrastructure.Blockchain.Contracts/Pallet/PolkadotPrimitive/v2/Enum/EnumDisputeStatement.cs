using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;


namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotPrimitive.v2.Enum
{
    [DomainMapping("polkadot_primitives/v2")]
    public enum DisputeStatement
    {

        Valid = 0,

        Invalid = 1,
    }

    /// <summary>
    /// >> 401 - Variant[polkadot_primitives.v2.DisputeStatement]
    /// </summary>
    public sealed class EnumDisputeStatement : BaseEnumExt<DisputeStatement, EnumValidDisputeStatementKind, EnumInvalidDisputeStatementKind>
    {
    }
}
