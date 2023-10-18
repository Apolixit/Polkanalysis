using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.GrandPa.Enums
{
    public enum Event
    {

        NewAuthorities = 0,

        Paused = 1,

        Resumed = 2,
    }

    /// <summary>
    /// >> 47 - Variant[pallet_grandpa.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event,
        BaseVec<BaseTuple<PublicEd25519, U64>>,
        BaseVoid,
        BaseVoid>
    {
    }
}
