using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.NominationPools
{
    public class SubPools
    {
        public UnbondPool NoEra { get; set; }
        public IEnumerable<(U32, UnbondPool)> WithEra { get; set; }

    }
}
