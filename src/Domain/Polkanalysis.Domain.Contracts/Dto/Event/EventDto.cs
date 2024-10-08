using Polkanalysis.Domain.Contracts.Dto.Common;

namespace Polkanalysis.Domain.Contracts.Dto.Event
{
    /// <summary>
    /// Event front DTO
    /// </summary>
    public class EventDto
    {
        public EventDto(uint blockNumber, string eventIndex, string extrinsicIndex, string palletName, string eventName, string description, List<TreeDto> tree)
        {
            BlockNumber = blockNumber;
            EventIndex = eventIndex;
            ExtrinsicIndex = extrinsicIndex;
            PalletName = palletName;
            EventName = eventName;
            Description = description;
            Tree = tree;
        }

        public uint BlockNumber { get; set; }
        public string EventIndex { get; set; }
        public string ExtrinsicIndex { get; set; }
        public string PalletName { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<TreeDto> Tree { get; set; }
    }
}
