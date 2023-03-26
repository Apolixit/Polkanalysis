using Ajuna.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Core.Display;
using Polkanalysis.Domain.Contracts.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Multisig.Enums
{
    public enum Event
    {

        NewMultisig = 0,

        MultisigApproval = 1,

        MultisigExecuted = 2,

        MultisigCancelled = 3,
    }

    /// <summary>
    /// >> 81 - Variant[pallet_multisig.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<SubstrateAccount, SubstrateAccount, Nameable>, BaseTuple<SubstrateAccount, Timepoint, SubstrateAccount, Nameable>, BaseTuple<SubstrateAccount, Timepoint, SubstrateAccount, Nameable, EnumResult>, BaseTuple<SubstrateAccount, Timepoint, SubstrateAccount, Nameable>>
    {
    }
}
