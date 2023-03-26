using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.FastUnstake.Enums
{
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
