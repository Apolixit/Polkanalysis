using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Display;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Offences.Enums
{
    [DomainMapping("pallet_offences/pallet")]
    public enum Event
    {

        Offence = 0,
    }

    /// <summary>
    /// >> 44 - Variant[pallet_offences.pallet.Event]
    /// Events type.
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event,
        BaseTuple<NameableSize16, BaseVec<U8>>>
    {
    }
}
