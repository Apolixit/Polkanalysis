using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Signature;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotPrimitive.v2.Enum
{
    [DomainMapping("polkadot_primitives/v2")]
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
