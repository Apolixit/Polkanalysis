using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.GrandPa.Enums
{
    [DomainMapping("sp_finality_grandpa", "sp_consensus_grandpa")]
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
