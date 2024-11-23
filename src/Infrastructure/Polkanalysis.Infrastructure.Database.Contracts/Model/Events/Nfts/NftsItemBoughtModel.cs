using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Nfts
{
    public class NftsItemBoughtModel : EventModel
    {
        [SetsRequiredMembers]
        public NftsItemBoughtModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, double collection, double item, double price, string seller, string buyer) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.Collection = collection;
            this.Item = item;
            this.Price = price;
            this.Seller = seller;
            this.Buyer = buyer;
        }

        public double Collection { get; set; }
        public double Item { get; set; }
        public double Price { get; set; }
        public string Seller { get; set; }
        public string Buyer { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Collection} | {Item} | {Price} | {Seller} | {Buyer}";
        }
    }
}