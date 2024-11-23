using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Nfts
{
    public class NftsItemPropertiesLockedModel : EventModel
    {
        [SetsRequiredMembers]
        public NftsItemPropertiesLockedModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, double collection, double item, bool lock_metadata, bool lock_attributes) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.Collection = collection;
            this.Item = item;
            this.Lock_metadata = lock_metadata;
            this.Lock_attributes = lock_attributes;
        }

        public double Collection { get; set; }
        public double Item { get; set; }
        public bool Lock_metadata { get; set; }
        public bool Lock_attributes { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Collection} | {Item} | {Lock_metadata} | {Lock_attributes}";
        }
    }
}