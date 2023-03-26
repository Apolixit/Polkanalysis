using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Core.Error
{
    public enum DispatchError
    {

        Other = 0,

        CannotLookup = 1,

        BadOrigin = 2,

        Module = 3,

        ConsumerRemaining = 4,

        NoProviders = 5,

        TooManyConsumers = 6,

        Token = 7,

        Arithmetic = 8,

        Transactional = 9,

        Exhausted = 10,

        Corruption = 11,

        Unavailable = 12,
    }

    /// <summary>
    /// >> 24 - Variant[sp_runtime.DispatchError]
    /// </summary>
    public sealed class EnumDispatchError : BaseEnumExt<DispatchError, 
        BaseVoid, 
        BaseVoid, 
        BaseVoid, 
        ModuleError, 
        BaseVoid, 
        BaseVoid, 
        BaseVoid, 
        EnumTokenError, 
        EnumArithmeticError, 
        EnumTransactionalError, 
        BaseVoid, 
        BaseVoid, 
        BaseVoid>
    {
    }
}
