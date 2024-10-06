using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Hrmp.Enums
{
    [DomainMapping("polkadot_runtime_parachains/hrmp/pallet")]
    public enum Event
    {

        OpenChannelRequested = 0,

        OpenChannelCanceled = 1,

        OpenChannelAccepted = 2,

        ChannelClosed = 3,

        HrmpChannelForceOpened = 4,
    }

    /// <summary>
    /// >> 111 - Variant[polkadot_runtime_parachains.hrmp.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Id, Id, U32, U32>, BaseTuple<Id, HrmpChannelId>, BaseTuple<Id, Id>, BaseTuple<Id, HrmpChannelId>, BaseTuple<Id, Id, U32, U32>>
    {
    }
}
