using Ajuna.NetApi.Model.Types.Base;
using Substats.Domain.Contracts.Core.Public;
using Substats.Domain.Contracts.Core.Signature;
using System.Collections.Generic;

namespace Substats.Domain.Contracts.Core.Multi
{
    public enum MultiSignature
    {
        
        Ed25519 = 0,
        
        Sr25519 = 1,
        
        Ecdsa = 2,
    }
    
    /// <summary>
    /// >> 421 - Variant[sp_runtime.MultiSignature]
    /// </summary>
    public sealed class EnumMultiSignature : BaseEnumExt<MultiSignature, SignatureEd25519, SignatureSr25519, SignatureEcdsa>
    {
    }
}
