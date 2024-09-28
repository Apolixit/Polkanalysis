using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Core.Display;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Core.DispatchInfo;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v2.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Ump.Enums
{
    [DomainMapping("polkadot_runtime_parachains/ump/pallet")]
    public enum Event
    {

        InvalidFormat = 0,

        UnsupportedVersion = 1,

        ExecutedUpward = 2,

        WeightExhausted = 3,

        UpwardMessagesReceived = 4,

        OverweightEnqueued = 5,

        OverweightServiced = 6,
    }

    /// <summary>
    /// >> 108 - Variant[polkadot_runtime_parachains.ump.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, NameableSize32, NameableSize32, BaseTuple<NameableSize32, EnumOutcome>, BaseTuple<NameableSize32, Weight, Weight>, BaseTuple<Id, U32, U32>, BaseTuple<Id, NameableSize32, U64, Weight>, BaseTuple<U64, Weight>>
    {
    }
}
