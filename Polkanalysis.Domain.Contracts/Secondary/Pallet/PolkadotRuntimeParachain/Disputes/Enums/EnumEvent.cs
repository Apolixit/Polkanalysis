using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotRuntimeParachain.Disputes.Enums
{
    public enum Event
    {

        DisputeInitiated = 0,

        DisputeConcluded = 1,

        DisputeTimedOut = 2,

        Revert = 3,
    }

    /// <summary>
    /// >> 113 - Variant[polkadot_runtime_parachains.disputes.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<CandidateHash, EnumDisputeLocation>, BaseTuple<CandidateHash, EnumDisputeResult>, CandidateHash, U32>
    {
    }
}
