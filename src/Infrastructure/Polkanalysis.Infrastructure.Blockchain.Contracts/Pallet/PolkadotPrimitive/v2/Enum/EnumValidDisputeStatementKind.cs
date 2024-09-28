using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotPrimitive.v2.Enum
{
    [DomainMapping("polkadot_primitives/v2")]
    public enum ValidDisputeStatementKind
    {

        Explicit = 0,

        BackingSeconded = 1,

        BackingValid = 2,

        ApprovalChecking = 3,
    }

    /// <summary>
    /// >> 402 - Variant[polkadot_primitives.v2.ValidDisputeStatementKind]
    /// </summary>
    public sealed class EnumValidDisputeStatementKind : BaseEnumExt<ValidDisputeStatementKind, BaseVoid, Hash, Hash, BaseVoid>
    {
    }
}
