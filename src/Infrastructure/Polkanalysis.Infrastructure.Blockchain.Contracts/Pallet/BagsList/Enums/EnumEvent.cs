using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.BagsList.Enums
{
    [DomainMapping("pallet_bags_list/pallet")]
    public enum Event
    {

        Rebagged = 0,

        ScoreUpdated = 1,
    }

    /// <summary>
    /// >> 89 - Variant[pallet_bags_list.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<SubstrateAccount, U64, U64>, BaseTuple<SubstrateAccount, U64>>
    {
    }
}
