using Ajuna.NetApi.Model.Types.Base;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Core.DispatchInfo;
using Substats.Domain.Contracts.Core.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.SystemCore.Enums
{
    public enum Event
    {

        ExtrinsicSuccess = 0,

        ExtrinsicFailed = 1,

        CodeUpdated = 2,

        NewAccount = 3,

        KilledAccount = 4,

        Remarked = 5,
    }

    /// <summary>
    /// >> 20 - Variant[frame_system.pallet.Event]
    /// Event for the System pallet.
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, 
        DispatchInfo, 
        BaseTuple<EnumDispatchError, DispatchInfo>, 
        BaseVoid, 
        SubstrateAccount, 
        SubstrateAccount, 
        BaseTuple<SubstrateAccount, Hash>>
    {
    }
}
