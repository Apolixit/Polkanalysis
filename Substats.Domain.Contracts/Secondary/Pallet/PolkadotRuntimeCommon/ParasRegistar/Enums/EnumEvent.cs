using Ajuna.NetApi.Model.Types.Base;
using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.PolkadotRuntimeCommon.ParasRegistar.Enums
{
    public enum Event
    {

        Registered = 0,

        Deregistered = 1,

        Reserved = 2,
    }

    /// <summary>
    /// >> 117 - Variant[polkadot_runtime_common.paras_registrar.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Id, SubstrateAccount>, Id, BaseTuple<Id, SubstrateAccount>>
    {
    }
}
