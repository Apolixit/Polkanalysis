using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Nfts
{
    public class NftsTransferredModel : EventModel
    {
        [SetsRequiredMembers]
        public NftsTransferredModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, double collection, double item, string from, string to) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.Collection = collection;
            this.Item = item;
            this.From = from;
            this.To = to;
        }

        public double Collection { get; set; }
        public double Item { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Collection} | {Item} | {From} | {To}";
        }
    }
}