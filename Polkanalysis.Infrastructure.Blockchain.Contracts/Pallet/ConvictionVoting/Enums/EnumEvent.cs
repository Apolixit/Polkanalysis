using Polkanalysis.Domain.Contracts.Core;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ConvictionVoting.Enums
{
    public enum Event
    {
        Delegated = 0,
        Undelegated = 1
    }

    /// <summary>
    /// >> 13971 - Variant[pallet_conviction_voting.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, 
        BaseTuple<SubstrateAccount, SubstrateAccount>, SubstrateAccount>
    {
    }
}
