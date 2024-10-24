using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Display;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.MessageQueue.Enums
{
    [DomainMapping("pallet_message_queue/pallet")]
    public enum Event
    {
        ProcessingFailed = 0,
        Processed = 1,
        OverweightEnqueued = 2,
        PageReaped = 3
    }

    /// <summary>
    /// >> 15194 - Variant[pallet_message_queue.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event,
        BaseTuple<FlexibleNameable, PolkadotRuntimeParachain.Inclusion.Enums.EnumAggregateMessageOrigin, Support.Enum.EnumProcessMessageError>, 
        BaseTuple<FlexibleNameable, PolkadotRuntimeParachain.Inclusion.Enums.EnumAggregateMessageOrigin, System.Weight, Bool>, 
        BaseTuple<FlexibleNameable, PolkadotRuntimeParachain.Inclusion.Enums.EnumAggregateMessageOrigin, U32, U32>, 
        BaseTuple<PolkadotRuntimeParachain.Inclusion.Enums.EnumAggregateMessageOrigin, U32>>
    {
    }

    //public sealed class EnumEvent : BaseEnumExt<Event, 
    //    BaseTuple<Arr32U8, EnumAggregateMessageOrigin, EnumProcessMessageError>, 
    //    BaseTuple<Arr32U8, EnumAggregateMessageOrigin, Weight, Bool>, 
    //    BaseTuple<Arr32U8, EnumAggregateMessageOrigin, U32, U32>, 
    //    BaseTuple<EnumAggregateMessageOrigin, U32>>
    //{
    //}
}
