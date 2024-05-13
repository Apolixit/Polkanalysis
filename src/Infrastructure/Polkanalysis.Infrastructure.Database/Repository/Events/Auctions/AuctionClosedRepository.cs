using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Auctions;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Common.Search;

namespace Polkanalysis.Infrastructure.Database.Repository.Events.Auctions
{
    public class SearchCriteriaAuctionClosed : SearchCriteria
    {
        public NumberCriteria<int>? AuctionId { get; set; }
    }

    public class AuctionClosedRepository : EventDatabaseRepository<AuctionClosedModel, SearchCriteriaAuctionClosed>
    {
        public AuctionClosedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<AuctionClosedRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "Auction.Closed";

        protected override DbSet<AuctionClosedModel> dbTable => _context.EventAuctionClosed;

        protected override Task<IQueryable<AuctionClosedModel>> SearchInnerAsync(SearchCriteriaAuctionClosed criteria, IQueryable<AuctionClosedModel> model, CancellationToken token)
        {
            if (criteria.AuctionId is not null)
            {
                model = model.WhereCriteria(criteria.AuctionId, x => x.AuctionIndex);
            }

            return Task.FromResult(model);
        }

        internal async override Task<AuctionClosedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Auctions.Enums.EnumEvent,
                Id>();

            var auctionIndex = (int)convertedData.Value.Value;

            return new AuctionClosedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
                auctionIndex);
        }
    }
}
