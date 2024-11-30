using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Nfts
{
    public class NftsItemBoughtModel : EventModel
    {
        [SetsRequiredMembers]
        public NftsItemBoughtModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, double collection, string item, double price, string seller, string buyer) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.Collection = collection;
            this.Item = item;
            this.Price = price;
            this.Seller = seller;
            this.Buyer = buyer;
        }

        public double Collection { get; set; }
        public string Item { get; set; }
        public BigInteger ItemValue() => BigInteger.Parse(Item);
        public double Price { get; set; }
        public string Seller { get; set; }
        public string Buyer { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Collection} | {ItemValue} | {Price} | {Seller} | {Buyer}";
        }
    }
}