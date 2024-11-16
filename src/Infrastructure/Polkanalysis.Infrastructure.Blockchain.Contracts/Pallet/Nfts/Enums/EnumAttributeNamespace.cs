using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
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
    public enum AttributeNamespace
    {
        Pallet = 0,
        CollectionOwner = 1,
        ItemOwner = 2,
        Account = 3
    }

    /// <summary>
    /// >> 4015 - Variant[pallet_nfts.types.AttributeNamespace]
    /// </summary>
    public sealed class EnumAttributeNamespace : BaseEnumExt<AttributeNamespace, BaseVoid, BaseVoid, BaseVoid, SubstrateAccount>
    {
    }
}
