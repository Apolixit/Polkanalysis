using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Core.DispatchInfo;
using Polkanalysis.Domain.Contracts.Core.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums
{
    [DomainMapping("frame_system/pallet")]
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
