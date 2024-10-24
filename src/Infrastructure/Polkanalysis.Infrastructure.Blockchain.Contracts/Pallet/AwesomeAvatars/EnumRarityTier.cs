using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.AwesomeAvatars
{
    [DomainMapping("todo")]
    public enum RarityTier
    {

        Common = 0,

        Uncommon = 1,

        Rare = 2,

        Epic = 3,

        Legendary = 4,

        Mythical = 5,
    }

    public sealed class EnumRarityTier : BaseEnum<RarityTier>
    {
    }
}
