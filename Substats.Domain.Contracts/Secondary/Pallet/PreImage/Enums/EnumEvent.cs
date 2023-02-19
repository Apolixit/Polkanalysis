using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.PreImage.Enums
{
    public enum Event
    {

        Noted = 0,

        Requested = 1,

        Cleared = 2,
    }

    /// <summary>
    /// >> 34 - Variant[pallet_preimage.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, 
        Hash, 
        Hash, 
        Hash>
    {
    }
}
