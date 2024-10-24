using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Error
{
    [DomainMapping("sp_runtime")]
    public enum TokenError
    {

        FundsUnavailable = 0,
        OnlyProvider = 1,
        BelowMinimum = 2,
        CannotCreate = 3,
        UnknownAsset = 4,
        Frozen = 5,
        Unsupported = 6,
        CannotCreateHold = 7,
        NotExpendable = 8,
        Blocked = 9
    }

    /// <summary>
    /// >> 26 - Variant[sp_runtime.TokenError]
    /// </summary>
    public sealed class EnumTokenError : BaseEnum<TokenError>
    {
    }
}
