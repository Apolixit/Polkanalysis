using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Nfts
{
    public class NftsCollectionMaxSupplySetModel : EventModel
    {
        [SetsRequiredMembers]
        public NftsCollectionMaxSupplySetModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, double collection, double max_supply) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.Collection = collection;
            this.Max_supply = max_supply;
        }

        public double Collection { get; set; }
        public double Max_supply { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Collection} | {Max_supply}";
        }
    }
}