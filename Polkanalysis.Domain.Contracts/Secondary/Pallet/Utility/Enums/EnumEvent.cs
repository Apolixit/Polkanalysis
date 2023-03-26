using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core.Enum;
using Polkanalysis.Domain.Contracts.Core.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Utility.Enums
{
    public enum Event
    {

        BatchInterrupted = 0,

        BatchCompleted = 1,

        BatchCompletedWithErrors = 2,

        ItemCompleted = 3,

        ItemFailed = 4,

        DispatchedAs = 5,
    }

    /// <summary>
    /// >> 76 - Variant[pallet_utility.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<U32, EnumDispatchError>, BaseVoid, BaseVoid, BaseVoid, EnumDispatchError, EnumResult>
    {
    }
}
