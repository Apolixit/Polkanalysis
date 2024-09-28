using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Disputes.Enums
{
    [DomainMapping("polkadot_runtime_parachains/disputes/pallet")]
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
