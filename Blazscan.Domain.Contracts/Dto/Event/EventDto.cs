using Blazscan.Domain.Contracts.Dto.Block;
using Blazscan.SubstrateDecode.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Domain.Contracts.Dto.Event
{
    /// <summary>
    /// Event front DTO
    /// </summary>
    public class EventDto
    {
        public required BlockLightDto Block { get; set; }
        public required string PalletName { get; set; }
        public required string EventName { get; set; }
        public required INode Decoded { get; set; }
    }
}
