using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substrate.NET.Utils
{
    public static class BaseOptExtension
    {
        public static T? AsNullable<T>(this BaseOpt<T> baseOpt) where T : IType, new()
        {
            if (baseOpt == null) return default(T);
            if (!baseOpt.OptionFlag) return default(T);

            return baseOpt.Value;
        }
    }
}
