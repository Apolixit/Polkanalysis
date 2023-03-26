using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.GrandPa.Enums
{
    public enum Equivocation
    {

        Prevote = 0,

        Precommit = 1,
    }

    /// <summary>
    /// >> 218 - Variant[sp_finality_grandpa.Equivocation]
    /// </summary>
    public sealed class EnumEquivocation : BaseEnumExt<Equivocation, EquivocationT1, EquivocationT2>
    {
    }
}
