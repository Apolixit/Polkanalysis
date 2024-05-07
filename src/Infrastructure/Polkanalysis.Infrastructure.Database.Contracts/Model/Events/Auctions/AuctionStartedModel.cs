using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Auctions
{
    public class AuctionStartedModel : EventModel
    {
        [SetsRequiredMembers]
        public AuctionStartedModel(string blockchainName, int blockId, DateTime blockDate, int eventId, string moduleName, string moduleEvent, uint auctionIndex, uint leasePeriod, uint ending) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            AuctionIndex = auctionIndex;
            LeasePeriod = leasePeriod;
            Ending = ending;
        }

        public required uint AuctionIndex { get; set; }
        public required uint LeasePeriod { get; set; }
        public required uint Ending { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {AuctionIndex} | {LeasePeriod} | {Ending}";
        }
    }
}
