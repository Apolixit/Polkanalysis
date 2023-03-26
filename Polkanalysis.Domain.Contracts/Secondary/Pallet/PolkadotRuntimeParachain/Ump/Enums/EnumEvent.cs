using Ajuna.NetApi.Model.Types.Base;
using Substats.Domain.Contracts.Core.Display;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Core.DispatchInfo;
using Substats.Domain.Contracts.Secondary.Pallet.Xcm.v2.Enums;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Secondary.Pallet.SystemCore;

namespace Substats.Domain.Contracts.Secondary.Pallet.PolkadotRuntimeParachain.Ump.Enums
{
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
    public sealed class EnumEvent : BaseEnumExt<Event, Nameable, Nameable, BaseTuple<Nameable, EnumOutcome>, BaseTuple<Nameable, Weight, Weight>, BaseTuple<Id, U32, U32>, BaseTuple<Id, Nameable, U64, Weight>, BaseTuple<U64, Weight>>
    {
    }
}
