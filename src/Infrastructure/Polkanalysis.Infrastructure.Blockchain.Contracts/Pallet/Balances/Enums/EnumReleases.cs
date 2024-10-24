using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums
{
    [DomainMapping("pallet_balances")]
    public enum Releases
    {

        V1_0_0 = 0,

        V2_0_0 = 1,
    }

    /// <summary>
    /// >> 476 - Variant[pallet_balances.Releases]
    /// </summary>
    public sealed class EnumReleases : BaseEnum<Releases>
    {
    }
}
