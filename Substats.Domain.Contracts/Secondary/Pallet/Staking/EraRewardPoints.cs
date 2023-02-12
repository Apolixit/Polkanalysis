using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Staking
{
    public class EraRewardPoints
    {
        public U32 Total { get; set; }
        public IDictionary<SubstrateAccount, U32> Individual { get; set; } = new Dictionary<SubstrateAccount, U32>();
    }
}
