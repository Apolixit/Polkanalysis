using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Vesting.Enums
{
    [DomainMapping("pallet_vesting/pallet")]
    public enum Event
    {

        VestingUpdated = 0,

        VestingCompleted = 1,
    }

    /// <summary>
    /// >> 75 - Variant[pallet_vesting.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<SubstrateAccount, U128>, SubstrateAccount>
    {
    }
}
