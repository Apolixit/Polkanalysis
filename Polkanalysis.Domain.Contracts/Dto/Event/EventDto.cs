using Substats.Domain.Contracts.Dto.Block;
using Substats.Domain.Contracts.Runtime;

namespace Substats.Domain.Contracts.Dto.Event
{
    /// <summary>
    /// Event front DTO
    /// </summary>
    public class EventDto
    {
        public required EventLightDto EventSummary { get; set; }
        public required INode Decoded { get; set; }
    }
}
