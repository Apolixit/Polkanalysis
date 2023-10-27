using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Support.Enum
{
    public enum ProcessMessageError
    {
        BadFormat = 0,
        Corrupt = 1,
        Unsupported = 2,
        Overweight = 3,
        Yield = 4
    }

    /// <summary>
    /// >> 15195 - Variant[frame_support.traits.messages.ProcessMessageError]
    /// </summary>
    public sealed class EnumProcessMessageError : BaseEnumExt<ProcessMessageError, BaseVoid, BaseVoid, BaseVoid, Weight, BaseVoid>
    {
    }
}
