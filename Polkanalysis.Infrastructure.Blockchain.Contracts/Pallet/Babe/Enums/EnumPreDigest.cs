using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Babe.Enums
{
    [DomainMapping("sp_consensus_babe/digests")]
    public enum PreDigest
    {

        Primary = 1,

        SecondaryPlain = 2,

        SecondaryVRF = 3,
    }

    public sealed class EnumPreDigest : BaseEnumExt<PreDigest, BaseVoid, PrimaryPreDigest, SecondaryPlainPreDigest, SecondaryVRFPreDigest>
    {
    }
}
