using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Inclusion.Enums
{
    public enum Event
    {

        CandidateBacked = 0,

        CandidateIncluded = 1,

        CandidateTimedOut = 2,
    }

    /// <summary>
    /// >> 95 - Variant[polkadot_runtime_parachains.inclusion.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<CandidateReceipt, HeadData, CoreIndex, GroupIndex>, BaseTuple<CandidateReceipt, HeadData, CoreIndex, GroupIndex>, BaseTuple<CandidateReceipt, HeadData, CoreIndex>>
    {
    }
}
