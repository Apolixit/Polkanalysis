using Microsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Substats.Domain.Contracts.Dto.GlobalStatusDto;

namespace Substats.Domain.Contracts.Dto.User
{
    public class PoolDto
    {
        public required string Name { get; set; }
        public required string StashAddress { get; set; }
        public required string RewardAddress { get; set; }
        public required string CreatorAddress { get; set; }
        public required string RootAddress { get; set; }
        public required string TogglerAddress { get; set; }
        public required string NominatorAddress { get; set; }
        public required BigInteger RewardAmount { get; set; }
        public required BigInteger TotalBounded { get; set; }
        public uint MemberCount { get; set; }
        public NominationPoolStatusDto Status { get; set; }
    }
}
