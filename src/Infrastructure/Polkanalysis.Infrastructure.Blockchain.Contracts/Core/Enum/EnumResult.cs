using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Error;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Enum
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
