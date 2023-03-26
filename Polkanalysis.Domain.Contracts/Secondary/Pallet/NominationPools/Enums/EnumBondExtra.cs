using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.NominationPools.Enums
{
    public enum BondExtra
    {

        FreeBalance = 0,

        Rewards = 1,
    }

    /// <summary>
    /// >> 370 - Variant[pallet_nomination_pools.BondExtra]
    /// </summary>
    public sealed class EnumBondExtra : BaseEnumExt<BondExtra, Ajuna.NetApi.Model.Types.Primitive.U128, BaseVoid>
    {
    }
}
