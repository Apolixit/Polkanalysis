using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Paras
{
    public class ReplacementTimes
    {
        public U32 ExpectedAt { get; set; }
        public U32 ActivatedAt { get; set; }

    }
}
