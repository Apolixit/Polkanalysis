using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.ElectionsPhragmen.Enums
{
    public enum Event
    {

        NewTerm = 0,

        EmptyTerm = 1,

        ElectionError = 2,

        MemberKicked = 3,

        Renounced = 4,

        CandidateSlashed = 5,

        SeatHolderSlashed = 6,
    }

    /// <summary>
    /// >> 67 - Variant[pallet_elections_phragmen.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, 
        BaseVec<BaseTuple<SubstrateAccount, U128>>, BaseVoid, BaseVoid, SubstrateAccount, SubstrateAccount, BaseTuple<SubstrateAccount, U128>, BaseTuple<SubstrateAccount, U128>>
    {
    }
}
