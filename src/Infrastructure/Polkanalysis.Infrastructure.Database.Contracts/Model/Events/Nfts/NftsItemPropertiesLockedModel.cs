using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Nfts
{
    public class NftsItemPropertiesLockedModel : EventModel
    {
        [SetsRequiredMembers]
        public NftsItemPropertiesLockedModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, double collection, string item, bool lock_metadata, bool lock_attributes) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.Collection = collection;
            this.Item = item;
            this.Lock_metadata = lock_metadata;
            this.Lock_attributes = lock_attributes;
        }

        public double Collection { get; set; }
        public string Item { get; set; }
        public BigInteger ItemValue() => BigInteger.Parse(Item);
        public bool Lock_metadata { get; set; }
        public bool Lock_attributes { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Collection} | {ItemValue} | {Lock_metadata} | {Lock_attributes}";
        }
    }
}