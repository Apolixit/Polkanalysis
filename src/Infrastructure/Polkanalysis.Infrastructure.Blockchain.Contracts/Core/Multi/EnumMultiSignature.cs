using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Signature;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Multi
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
