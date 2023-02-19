using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.GrandPa.Enums
{
    public enum Event
    {

        NewAuthorities = 0,

        Paused = 1,

        Resumed = 2,
    }

    /// <summary>
    /// >> 47 - Variant[pallet_grandpa.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, 
        BaseVec<BaseTuple<PublicEd25519, U64>>, 
        BaseVoid, 
        BaseVoid>
    {
    }
}
