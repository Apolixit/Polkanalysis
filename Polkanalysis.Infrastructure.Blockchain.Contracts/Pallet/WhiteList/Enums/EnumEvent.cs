using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.WhiteList.Enums
{
    [DomainMapping("pallet_whitelist/pallet")]
    public enum Event
    {
        CallWhitelisted = 0,
        WhitelistedCallRemoved = 1,
        WhitelistedCallDispatched = 2
    }

    /// <summary>
    /// >> 15158 - Variant[pallet_whitelist.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, 
        Hash, Hash, BaseTuple<Hash, Domain.Contracts.Core.Enum.EnumResult>>
    {
    }
}
