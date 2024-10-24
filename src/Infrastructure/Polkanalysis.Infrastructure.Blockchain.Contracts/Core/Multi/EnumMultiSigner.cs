using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Public;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Multi
{
    [DomainMapping("sp_runtime")]
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
