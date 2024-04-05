using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Core.Error
{
    [DomainMapping("sp_runtime", "sp_arithmetic")]
    public enum ArithmeticError
    {

        Underflow = 0,

        Overflow = 1,

        DivisionByZero = 2,
    }

    /// <summary>
    /// >> 27 - Variant[sp_runtime.ArithmeticError]
    /// </summary>
    public sealed class EnumArithmeticError : BaseEnum<ArithmeticError>
    {
    }
}
