using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Auctions;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Common.Search;

namespace Polkanalysis.Infrastructure.Database.Repository.Events.Auctions
{
    public class SearchCriteriaAuctionStarted : SearchCriteria
    {
        public NumberCriteria<uint>? AuctionIndex { get; set; }
        public NumberCriteria<uint>? LeasePeriod { get; set; }
        public NumberCriteria<uint>? Ending { get; set; }
    }

    public class AuctionStartedRepository : EventDatabaseRepository<AuctionStartedModel>, ISearchEvent
    {
        public AuctionStartedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<AuctionStartedRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "Auction.Started";

        protected override DbSet<AuctionStartedModel> dbTable => _context.EventAuctionStarted;

        public override Type GetSearchCriterias() => typeof(SearchCriteriaAuctionStarted);

        protected override Task<IQueryable<AuctionStartedModel>> SearchInnerAsync(SearchCriteria criteria, IQueryable<AuctionStartedModel> model, CancellationToken token)
        {
            var c = (SearchCriteriaAuctionStarted)criteria;

            if (c is null)
                throw new InvalidOperationException($"Try to search {SearchName} event, but search criteria is not type of {GetSearchCriterias()} but type {criteria.GetType().Name}");

            if (c.AuctionIndex is not null)
                model = model.WhereCriteria(c.AuctionIndex, x => x.AuctionIndex);

            if (c.LeasePeriod is not null)
                model = model.WhereCriteria(c.LeasePeriod, x => x.LeasePeriod);

            if (c.Ending is not null)
                model = model.WhereCriteria(c.Ending, x => x.Ending);

            return Task.FromResult(model);
        }

        internal async override Task<AuctionStartedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Auctions.Enums.EnumEvent,
                BaseTuple<U32, U32, U32>>();

            var auctionIndex = convertedData.Value[0].As<U32>();
            var leasePeriod = convertedData.Value[1].As<U32>();
            var ending = convertedData.Value[2].As<U32>();

            return new AuctionStartedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
                auctionIndex,
                leasePeriod,
                ending);
        }
    }
}
