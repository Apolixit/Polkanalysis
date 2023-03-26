using Substats.Domain.Contracts.Dto.Block;

namespace Substats.Domain.Contracts.Dto.Event
{
    public class EventLightDto
    {
        public BlockLightDto? Block { get; set; }
        public ulong? EventIndex { get; set; } = null;
        public required string PalletName { get; set; }
        public required string EventName { get; set; }
        public string Description { get; set; } = string.Empty;

    }
}
