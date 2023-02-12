using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Staking
{
    public class ActiveEraInfo
    {
        public U32 Index { get; set; }
        public U64 Start { get; set; }
    }
}
