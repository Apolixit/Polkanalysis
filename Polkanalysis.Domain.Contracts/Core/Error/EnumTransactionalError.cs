﻿using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Core.Error
{
    public enum TransactionalError
    {

        LimitReached = 0,

        NoLayer = 1,
    }

    /// <summary>
    /// >> 28 - Variant[sp_runtime.TransactionalError]
    /// </summary>
    public sealed class EnumTransactionalError : BaseEnum<TransactionalError>
    {
    }
}
