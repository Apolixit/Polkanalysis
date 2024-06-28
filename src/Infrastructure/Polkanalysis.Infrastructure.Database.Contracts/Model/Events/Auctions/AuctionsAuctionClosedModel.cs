using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Auctions
{
    public class AuctionsAuctionClosedModel : EventModel
    {
        [SetsRequiredMembers]
        public AuctionsAuctionClosedModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, uint auctionIndex) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.AuctionIndex = auctionIndex;
        }

        public uint AuctionIndex { get; set; }

        public override string ToString()
        {
            return "{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {AuctionIndex}";
        }
    }
}