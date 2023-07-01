using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Stats
{
    public class GlobalStatsDto
    {
        public double TransfersVolume { get; set; }
        public double ActiveAccounts { get; set; }
        public double StakingPools { get; set; }
        public double RuntimeUpgrades { get; set; }
    }
}
