using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Paras
{
    public class ParaGenesisArgs
    {
        public byte[] GenesisHead { get; set; } = new byte[0];
        public byte[] ValidationCode { get; set; } = new byte[0];
        public Bool ParaKind { get; set; }
    }
}
