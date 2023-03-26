using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Runtime;

namespace Polkanalysis.Domain.Contracts.Dto.Event
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
