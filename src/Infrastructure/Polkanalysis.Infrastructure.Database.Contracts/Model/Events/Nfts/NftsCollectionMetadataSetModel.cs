using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Nfts
{
    public class NftsCollectionMetadataSetModel : EventModel
    {
        [SetsRequiredMembers]
        public NftsCollectionMetadataSetModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, double collection, string data) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.Collection = collection;
            this.Data = data;
        }

        public double Collection { get; set; }
        public string Data { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Collection} | {Data}";
        }
    }
}