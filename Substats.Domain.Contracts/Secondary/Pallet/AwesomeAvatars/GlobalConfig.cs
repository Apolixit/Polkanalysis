﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.AwesomeAvatars
{
    public class GlobalConfig
    {
        public uint MaxAvatarsPerPlayer { get; set; }
        public MintConfig Mint { get; set; }
        public ForgeConfig Forge { get; set; }
        public TradeConfig Trade { get; set; }
    }
}
