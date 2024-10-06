using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Support.Enum;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Referenda.Enums
{
    [DomainMapping("pallet_referenda/pallet")]
    public enum Event
    {
        Submitted = 0,
        DecisionDepositPlaced = 1,
        DecisionDepositRefunded = 2,
        DepositSlashed = 3,
        DecisionStarted = 4,
        ConfirmStarted = 5,
        ConfirmAborted = 6,
        Confirmed = 7,
        Approved = 8,
        Rejected = 9,
        TimedOut = 10,
        Cancelled = 11,
        Killed = 12,
        SubmissionDepositRefunded = 13,
        MetadataSet = 14,
        MetadataCleared = 15
    }

    /// <summary>
    /// >> 14793 - Variant[pallet_referenda.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, 
        BaseTuple<U32, U16, EnumBounded>, 
        BaseTuple<U32, SubstrateAccount, U128>, 
        BaseTuple<U32, SubstrateAccount, U128>, 
        BaseTuple<SubstrateAccount, U128>, 
        BaseTuple<U32, U16, EnumBounded, Tally>, 
        U32, U32, BaseTuple<U32, Tally>, 
        U32, BaseTuple<U32, Tally>, 
        BaseTuple<U32, Tally>, 
        BaseTuple<U32, Tally>, 
        BaseTuple<U32, Tally>, 
        BaseTuple<U32, SubstrateAccount, U128>, 
        BaseTuple<U32, Hash>, 
        BaseTuple<U32, Hash>>
    {
    }
}
