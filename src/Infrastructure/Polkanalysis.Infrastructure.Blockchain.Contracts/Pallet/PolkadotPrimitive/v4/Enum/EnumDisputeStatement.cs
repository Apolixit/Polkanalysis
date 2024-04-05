using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotPrimitive.v4.Enum
{
    [DomainMapping("polkadot_primitives/v4")]
    public enum DisputeStatement
    {
        Valid = 0,
        Invalid = 1
    }

    /// <summary>
    /// >> 15065 - Variant[polkadot_primitives.v4.DisputeStatement]
    /// </summary>
    public sealed class EnumDisputeStatement : BaseEnumExt<DisputeStatement, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.polkadot_primitives.v4.EnumValidDisputeStatementKind, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.polkadot_primitives.v4.EnumInvalidDisputeStatementKind>
    {
    }
}
