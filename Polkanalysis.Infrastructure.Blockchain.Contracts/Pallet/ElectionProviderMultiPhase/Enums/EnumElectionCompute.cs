using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ElectionProviderMultiPhase.Enums
{
    [DomainMapping("pallet_election_provider_multi_phase")]
    public enum ElectionCompute
    {

        OnChain = 0,

        Signed = 1,

        Unsigned = 2,

        Fallback = 3,

        Emergency = 4,
    }

    /// <summary>
    /// >> 87 - Variant[pallet_election_provider_multi_phase.ElectionCompute]
    /// </summary>
    public sealed class EnumElectionCompute : BaseEnum<ElectionCompute>
    {
    }
}
