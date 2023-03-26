using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Xcm.v1.Enums
{
    public enum WildMultiAsset
    {

        All = 0,

        AllOf = 1,
    }

    /// <summary>
    /// >> 146 - Variant[xcm.v1.multiasset.WildMultiAsset]
    /// </summary>
    public sealed class EnumWildMultiAsset : BaseEnumExt<WildMultiAsset, BaseVoid, BaseTuple<EnumAssetId, EnumWildFungibility>>
    {
    }
}
