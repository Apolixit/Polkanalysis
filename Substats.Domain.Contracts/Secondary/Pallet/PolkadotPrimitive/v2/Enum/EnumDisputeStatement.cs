using Ajuna.NetApi.Model.Types.Base;


namespace Substats.Domain.Contracts.Secondary.Pallet.PolkadotPrimitive.v2.Enum
{
    
    
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
