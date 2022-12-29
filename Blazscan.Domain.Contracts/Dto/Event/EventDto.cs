using Blazscan.Domain.Contracts.Dto.Block;
using Blazscan.Domain.Contracts.Runtime;

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
