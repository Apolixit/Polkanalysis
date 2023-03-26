using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.ElectionProviderMultiPhase.Enums
{
    public enum Event
    {

        SolutionStored = 0,

        ElectionFinalized = 1,

        ElectionFailed = 2,

        Rewarded = 3,

        Slashed = 4,

        SignedPhaseStarted = 5,

        UnsignedPhaseStarted = 6,
    }

    /// <summary>
    /// >> 86 - Variant[pallet_election_provider_multi_phase.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<EnumElectionCompute, Bool>, BaseTuple<EnumElectionCompute, ElectionScore>, BaseVoid, BaseTuple<SubstrateAccount, U128>, BaseTuple<SubstrateAccount, U128>, U32, U32>
    {
    }
}
