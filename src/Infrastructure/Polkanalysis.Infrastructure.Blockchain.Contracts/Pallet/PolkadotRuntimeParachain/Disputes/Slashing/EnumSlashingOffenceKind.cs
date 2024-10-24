using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Disputes.Slashing
{
    [DomainMapping("polkadot_runtime_parachains/disputes/slashing", "polkadot_primitives/v5/slashing")]
    public enum SlashingOffenceKind
    {
        ForInvalid = 0,
        AgainstValid = 1
    }

    /// <summary>
    /// >> 15077 - Variant[polkadot_runtime_parachains.disputes.slashing.SlashingOffenceKind]
    /// </summary>
    public sealed class EnumSlashingOffenceKind : BaseEnum<SlashingOffenceKind>
    {
    }
}
