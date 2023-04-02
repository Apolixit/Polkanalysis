using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotPrimitive.v2.Enum
{
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
