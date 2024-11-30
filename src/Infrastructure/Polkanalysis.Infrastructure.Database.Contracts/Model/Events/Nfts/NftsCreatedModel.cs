using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Nfts
{
    public class NftsCreatedModel : EventModel
    {
        [SetsRequiredMembers]
        public NftsCreatedModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, double collection, string creator, string owner) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.Collection = collection;
            this.Creator = creator;
            this.Owner = owner;
        }

        public double Collection { get; set; }
        public string Creator { get; set; }
        public string Owner { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Collection} | {Creator} | {Owner}";
        }
    }
}