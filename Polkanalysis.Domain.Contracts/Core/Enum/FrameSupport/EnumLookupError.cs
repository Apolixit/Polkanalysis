using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Core.Enum.FrameSupport
{
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
