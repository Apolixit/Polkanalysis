using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Polkanalysis.Domain.Contracts.Dto.GlobalStatusDto;

namespace Polkanalysis.Domain.Contracts.Dto.Staking
{
    public class PoolLightDto
    {
        public uint PoolId { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Commission { get; set; }
        public uint NbPoolMembers { get; set; }
        public NominationPoolStatusDto Status { get; set; }
        public double TotalBonded { get; set; }
        public double RewardPool { get; set; }
    }
}
