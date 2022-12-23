using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Domain.Contracts.Dto.Block
{
    public class BlockLightDto
    {
        public required ulong Number { get; set; }
        public required Hash Hash { get; set; }
        public required TimeSpan When { get; set; }
        public required StatusDto Status { get; set; }
    }
}
