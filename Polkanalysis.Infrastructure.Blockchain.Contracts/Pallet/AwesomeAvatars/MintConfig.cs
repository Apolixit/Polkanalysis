using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.AwesomeAvatars
{
    public class MintConfig
    {
        public Bool Open { get; set; }
        public MintFees Fees { get; set; }
        public U32 Cooldown { get; set; }
        public ushort FreeMintTransferFee { get; set; }


    }
}
