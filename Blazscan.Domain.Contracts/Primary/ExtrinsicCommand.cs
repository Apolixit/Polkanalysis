using Blazscan.Domain.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Domain.Contracts.Primary
{
    public class ExtrinsicCommand
    {
        public required uint BlockNumber { get; set; }
        public required uint ExtrinsicIndex { get; set; }
    }
}
