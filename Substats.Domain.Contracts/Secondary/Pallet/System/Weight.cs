using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.System
{
    public class Weight
    {
        public U32 RefTime { get; set; }
        public U32 ProofSize { get; set; }
    }
}
