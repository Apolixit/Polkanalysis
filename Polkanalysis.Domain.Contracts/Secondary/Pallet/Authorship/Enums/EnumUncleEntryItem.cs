using Ajuna.NetApi.Model.Types.Base;
using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Authorship.Enums
{
    public enum UncleEntryItem
    {

        InclusionHeight = 0,

        Uncle = 1,
    }

    /// <summary>
    /// >> 481 - Variant[pallet_authorship.UncleEntryItem]
    /// </summary>
    public sealed class EnumUncleEntryItem : BaseEnumExt<UncleEntryItem, Ajuna.NetApi.Model.Types.Primitive.U32, BaseTuple<Hash, BaseOpt<SubstrateAccount>>>
    {
    }
}
