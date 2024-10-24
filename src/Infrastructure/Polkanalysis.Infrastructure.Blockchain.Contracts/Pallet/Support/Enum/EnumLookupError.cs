using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Support.Enum
{
    [DomainMapping("frame_support/traits/schedule")]
    public enum LookupError
    {

        Unknown = 0,

        BadFormat = 1,
    }

    /// <summary>
    /// >> 33 - Variant[frame_support.traits.schedule.LookupError]
    /// </summary>
    public sealed class EnumLookupError : BaseEnum<LookupError>
    {
    }
}
