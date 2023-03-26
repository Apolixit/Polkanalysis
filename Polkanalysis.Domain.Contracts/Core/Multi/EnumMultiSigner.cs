using Ajuna.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Core.Public;

namespace Polkanalysis.Domain.Contracts.Core.Multi
{
    public enum MultiSigner
    {
        
        Ed25519 = 0,
        
        Sr25519 = 1,
        
        Ecdsa = 2,
    }
    
    /// <summary>
    /// >> 417 - Variant[sp_runtime.MultiSigner]
    /// </summary>
    public sealed class EnumMultiSigner : BaseEnumExt<MultiSigner, PublicEd25519, PublicSr25519, PublicEcdsa>
    {
    }
}
