using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Nfts
{
    public class NftsForceCreatedModel : EventModel
    {
        [SetsRequiredMembers]
        public NftsForceCreatedModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, double collection, string owner) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.Collection = collection;
            this.Owner = owner;
        }

        public double Collection { get; set; }
        public string Owner { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Collection} | {Owner}";
        }
    }
}