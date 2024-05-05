using Polkanalysis.Domain.Contracts.Dto.Block;

namespace Polkanalysis.Domain.Contracts.Dto.Event
{
    public class EventLightDto
    {
        public EventLightDto(BlockLightDto block, string eventIndex, string extrinsicIndex, string palletName, string eventName, string description)
        {
            Block = block;
            EventIndex = eventIndex;
            ExtrinsicIndex = extrinsicIndex;
            PalletName = palletName;
            EventName = eventName;
            Description = description;
        }

        public BlockLightDto Block { get; set; }
        public string EventIndex { get; set; }
        public string ExtrinsicIndex { get; set; }
        public string PalletName { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; } = string.Empty;

    }
}
