using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Core.Public;
using Polkanalysis.Domain.Contracts.Core.Signature;
using System.Collections.Generic;
using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;

namespace Polkanalysis.Domain.Contracts.Core.Multi
{
    [DomainMapping("sp_runtime")]
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
