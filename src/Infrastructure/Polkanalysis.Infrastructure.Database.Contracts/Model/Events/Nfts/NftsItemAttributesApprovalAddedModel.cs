using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Nfts
{
    public class NftsItemAttributesApprovalAddedModel : EventModel
    {
        [SetsRequiredMembers]
        public NftsItemAttributesApprovalAddedModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, double collection, double item, string @delegate) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.Collection = collection;
            this.Item = item;
            this.Delegate = @delegate;
        }

        public double Collection { get; set; }
        public double Item { get; set; }
        public string Delegate { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Collection} | {Item} | {Delegate}";
        }
    }
}