namespace Polkanalysis.Domain.Contracts.Primary
{
    public class EventCommand
    {
        public required uint BlockNumber { get; set; }
        public required uint EventIndex { get; set; }
    }
}
