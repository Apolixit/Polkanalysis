using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Domain.Contracts
{
    public class BlockDto
    {
        public int BlockNumber { get; set; }
        public string BlockHash { get; set; } = string.Empty;
    }
}
