using Ajuna.NetApi.Model.Types.Base;
using Substats.Domain.Contracts.Core.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Core.Enum
{
    public enum Result
    {
        Ok = 0,

        Err = 1,
    }

    /// <summary>
    /// >> 32 - Variant[Result]
    /// </summary>
    public sealed class EnumResult : BaseEnumExt<Result, 
        BaseTuple, 
        EnumDispatchError>
    {
    }
}
