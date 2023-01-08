using Blazscan.Domain.Contracts.Dto.Block;

namespace Blazscan.Domain.Contracts.Dto.Event
{
    public class EventLightDto
    {
        public required string PalletName { get; set; }
        public required string EventName { get; set; }
        public string Description { get; set; } = string.Empty;

    }
}
