using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Auctions
{
    public class AuctionClosedModel : EventModel
    {
        [SetsRequiredMembers]
        public AuctionClosedModel(string blockchainName, int blockId, DateTime blockDate, int eventId, string moduleName, string moduleEvent, int auctionIndex) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            AuctionIndex = auctionIndex;
        }

        public required int AuctionIndex { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {AuctionIndex}";
        }
    }
}
