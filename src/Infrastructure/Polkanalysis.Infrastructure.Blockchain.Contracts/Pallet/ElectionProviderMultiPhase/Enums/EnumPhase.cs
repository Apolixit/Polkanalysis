using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ElectionProviderMultiPhase.Enums
{
    [DomainMapping("pallet_election_provider_multi_phase")]
    public enum Phase
    {

        Off = 0,

        Signed = 1,

        Unsigned = 2,

        Emergency = 3,
    }

    /// <summary>
    /// >> 600 - Variant[pallet_election_provider_multi_phase.Phase]
    /// </summary>
    public sealed class EnumPhase : BaseEnumExt<Phase, BaseVoid, BaseVoid, Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.Bool, Substrate.NetApi.Model.Types.Primitive.U32>, BaseVoid>
    {
    }
}
