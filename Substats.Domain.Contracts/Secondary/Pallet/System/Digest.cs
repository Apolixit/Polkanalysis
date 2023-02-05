using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.System
{
    public class Digest
    {
        public IEnumerable<EnumDigestItem> Logs { get; set; } = Enumerable.Empty<EnumDigestItem>();
    }
}
