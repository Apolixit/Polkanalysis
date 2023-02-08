using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Paras
{
    public class ParaPastCodeMeta
    {
        public IEnumerable<ReplacementTimes> UpgradeTimes { get; set; } = Enumerable.Empty<ReplacementTimes>();
        public uint? LastPruned { get; set; }
    }
}
