using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Enum;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.FastUnstake.Enums
{
    [DomainMapping("pallet_fast_unstake/pallet")]
    public enum Event
    {

        Unstaked = 0,

        Slashed = 1,

        InternalError = 2,

        BatchChecked = 3,

        BatchFinished = 4,
    }

    /// <summary>
    /// >> 93 - Variant[pallet_fast_unstake.pallet.Event]
    /// The events of this pallet.
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<SubstrateAccount, EnumResult>, BaseTuple<SubstrateAccount, U128>, BaseVoid, BaseVec<U32>, BaseVoid>
    {
    }
}
