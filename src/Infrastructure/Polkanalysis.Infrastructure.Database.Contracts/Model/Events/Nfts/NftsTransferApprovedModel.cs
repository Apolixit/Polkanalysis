using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Nfts
{
    public class NftsTransferApprovedModel : EventModel
    {
        [SetsRequiredMembers]
        public NftsTransferApprovedModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, double collection, double item, string owner, string @delegate, uint? deadline) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.Collection = collection;
            this.Item = item;
            this.Owner = owner;
            this.Delegate = @delegate;
            this.Deadline = deadline.GetValueOrDefault();
        }

        public double Collection { get; set; }
        public double Item { get; set; }
        public string Owner { get; set; }
        public string Delegate { get; set; }
        public uint Deadline { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Collection} | {Item} | {Owner} | {Delegate} | {Deadline}";
        }
    }
}