using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Nfts
{
    public class NftsItemPriceSetModel : EventModel
    {
        [SetsRequiredMembers]
        public NftsItemPriceSetModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, double collection, string item, double price, string? whitelisted_buyer) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.Collection = collection;
            this.Item = item;
            this.Price = price;
            this.Whitelisted_buyer = whitelisted_buyer ?? string.Empty;
        }

        public double Collection { get; set; }
        public string Item { get; set; }
        public BigInteger ItemValue() => BigInteger.Parse(Item);
        public double Price { get; set; }
        public string? Whitelisted_buyer { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Collection} | {ItemValue} | {Price} | {Whitelisted_buyer}";
        }
    }
}