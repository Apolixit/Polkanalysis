using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.AwesomeAvatars
{
    public class GlobalConfig
    {
        public U32 MaxAvatarsPerPlayer { get; set; }
        public MintConfig Mint { get; set; }
        public ForgeConfig Forge { get; set; }
        public TradeConfig Trade { get; set; }
    }
}
