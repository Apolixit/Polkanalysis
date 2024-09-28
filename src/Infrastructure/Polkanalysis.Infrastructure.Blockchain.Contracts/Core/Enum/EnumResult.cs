using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Core.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;

namespace Polkanalysis.Domain.Contracts.Core.Enum
{
    [DomainMapping("")]
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
