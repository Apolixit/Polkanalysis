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
        public uint Total { get; set; }
        public IDictionary<SubstrateAccount, uint> Individual { get; set; } = new Dictionary<SubstrateAccount, uint>();
    }
}
