using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Auctions
{
    public class AuctionsAuctionStartedModel : EventModel
    {
        [SetsRequiredMembers]
        public AuctionsAuctionStartedModel(string blockchainName, int blockId, DateTime blockDate, int eventId, string moduleName, string moduleEvent, uint auctionIndex, uint leasePeriod, uint ending) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.AuctionIndex = auctionIndex;
            this.LeasePeriod = leasePeriod;
            this.Ending = ending;
        }

        public uint AuctionIndex { get; set; }
        public uint LeasePeriod { get; set; }
        public uint Ending { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {AuctionIndex} | {LeasePeriod} | {Ending}";
        }
    }
}