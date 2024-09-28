using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums
{
    [DomainMapping("xcm/v1/multiasset")]
    public enum Fungibility
    {

        Fungible = 0,

        NonFungible = 1,
    }

    /// <summary>
    /// >> 137 - Variant[xcm.v1.multiasset.Fungibility]
    /// </summary>
    public sealed class EnumFungibility : BaseEnumExt<Fungibility, BaseCom<U128>, EnumAssetInstance>
    {
    }
}
