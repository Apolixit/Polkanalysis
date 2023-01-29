﻿using Substats.Domain.Contracts.Dto.Block;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Dto.Era
{
    public class EraLightDto
    {
        public uint Id { get; set; }
        public uint StartBlock { get; set; }
        public uint EndBlock { get; set; }
        public uint RewardPoint { get; set; }
        public uint NbBlockValidated { get; set; }
        public IEnumerable<BlockLightDto>? BlocksProduced { get; set; }
    }
}
