using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Nfts
{
    public class NftsItemTransferUnlockedModel : EventModel
    {
        [SetsRequiredMembers]
        public NftsItemTransferUnlockedModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, double collection, string item) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.Collection = collection;
            this.Item = item;
        }

        public double Collection { get; set; }
        public string Item { get; set; }
        public BigInteger ItemValue() => BigInteger.Parse(Item);

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Collection} | {ItemValue}";
        }
    }
}