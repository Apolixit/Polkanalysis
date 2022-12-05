using Blazscan.Domain.Contracts.Dto.Block;

namespace Blazscan.Domain.Contracts
{
    public class EventDto
    {
        public BlockDto Block { get; set; } = new BlockDto();
        public string PalletName { get; set; } = string.Empty;
        public string EventName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
