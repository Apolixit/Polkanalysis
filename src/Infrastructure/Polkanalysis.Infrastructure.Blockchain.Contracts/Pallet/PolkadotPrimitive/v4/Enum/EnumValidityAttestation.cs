using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotPrimitive.v4.Enum
{
    [DomainMapping("polkadot_primitives/v4")]
    public enum ValidityAttestation
    {
        Implicit = 1,
        Explicit = 2
    }

    /// <summary>
    /// >> 15059 - Variant[polkadot_primitives.v4.ValidityAttestation]
    /// </summary>
    public sealed class EnumValidityAttestation : BaseEnumExt<ValidityAttestation, BaseVoid, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.polkadot_primitives.v4.validator_app.Signature, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.polkadot_primitives.v4.validator_app.Signature>
    {
    }
}
