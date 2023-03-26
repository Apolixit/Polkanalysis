using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Core.Error
{
    public enum TokenError
    {

        NoFunds = 0,

        WouldDie = 1,

        BelowMinimum = 2,

        CannotCreate = 3,

        UnknownAsset = 4,

        Frozen = 5,

        Unsupported = 6,
    }

    /// <summary>
    /// >> 26 - Variant[sp_runtime.TokenError]
    /// </summary>
    public sealed class EnumTokenError : BaseEnum<TokenError>
    {
    }
}
