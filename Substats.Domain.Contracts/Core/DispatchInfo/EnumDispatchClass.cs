using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Core.DispatchInfo
{
    public enum DispatchClass
    {

        Normal = 0,

        Operational = 1,

        Mandatory = 2,
    }

    public sealed class EnumDispatchClass : BaseEnum<DispatchClass>
    {
    }
}
