using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.AwesomeAvatars
{
    public class MintConfig
    {
        public bool Open { get; set; }
        public MintFees Fees { get; set; }
        public uint Cooldown { get; set; }
        public ushort FreeMintTransferFee { get; set; }


    }
}
