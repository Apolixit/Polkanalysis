using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Core.DispatchInfo
{
    public enum RawOrigin
    {

        Root = 0,

        Signed = 1,

        None = 2,
    }

    /// <summary>
    /// >> 257 - Variant[frame_support.dispatch.RawOrigin]
    /// </summary>
    public sealed class EnumRawOrigin : BaseEnumExt<RawOrigin, BaseVoid, SubstrateAccount, BaseVoid>
    {
    }
}
