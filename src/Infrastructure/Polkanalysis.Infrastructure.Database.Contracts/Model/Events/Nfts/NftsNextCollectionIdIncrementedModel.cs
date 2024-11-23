using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Nfts
{
    public class NftsNextCollectionIdIncrementedModel : EventModel
    {
        [SetsRequiredMembers]
        public NftsNextCollectionIdIncrementedModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, double next_id) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.Next_id = next_id;
        }

        public double Next_id { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Next_id}";
        }
    }
}