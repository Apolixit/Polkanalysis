using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.AwesomeAvatars
{
    public class ForgeConfig
    {
        public Bool Open { get; set; }
        public U8 MinSacrifices { get; set; }
        public U8 MaxSacrifices { get; set; }

    }
}
