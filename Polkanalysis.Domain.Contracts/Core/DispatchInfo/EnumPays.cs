using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Core.DispatchInfo
{
    public enum Pays
    {

        Yes = 0,

        No = 1,
    }

    public sealed class EnumPays : BaseEnum<Pays>
    {
    }
}
