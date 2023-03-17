using Ajuna.NetApi.Model.Types.Base;
using Substats.Domain.Contracts.Core.Signature;

namespace Substats.Domain.Contracts.Secondary.Pallet.PolkadotPrimitive.v2.Enum
{
    public enum ValidityAttestation
    {
        
        Implicit = 1,
        
        Explicit = 2,
    }
    
    /// <summary>
    /// >> 396 - Variant[polkadot_primitives.v2.ValidityAttestation]
    /// </summary>
    public sealed class EnumValidityAttestation : BaseEnumExt<ValidityAttestation, BaseVoid, SignatureSr25519, SignatureSr25519>
    {
    }
}
