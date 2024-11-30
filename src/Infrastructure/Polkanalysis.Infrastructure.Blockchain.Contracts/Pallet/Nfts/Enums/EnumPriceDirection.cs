using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums
{
    [DomainMapping("pallet_nfts/types")]
    public enum PriceDirection
    {
        Send = 0,
        Receive = 1
    }

    /// <summary>
    /// >> 4019 - Variant[pallet_nfts.types.PriceDirection]
    /// </summary>
    public sealed class EnumPriceDirection : BaseEnum<PriceDirection>
    {
    }
}
