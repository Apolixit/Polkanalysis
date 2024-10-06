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

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Crowdloan.Enums
{
    [DomainMapping("polkadot_runtime_common/crowdloan/pallet")]
    public enum Event
    {

        Created = 0,

        Contributed = 1,

        Withdrew = 2,

        PartiallyRefunded = 3,

        AllRefunded = 4,

        Dissolved = 5,

        HandleBidResult = 6,

        Edited = 7,

        MemoUpdated = 8,

        AddedToNewRaise = 9,
    }

    /// <summary>
    /// >> 120 - Variant[polkadot_runtime_common.crowdloan.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Id, BaseTuple<SubstrateAccount, Id, U128>, BaseTuple<SubstrateAccount, Id, U128>, Id, Id, Id, BaseTuple<Id, EnumResult>, Id, BaseTuple<SubstrateAccount, Id, BaseVec<U8>>, Id>
    {
    }
}
