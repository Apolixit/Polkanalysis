using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Auctions;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Polkanalysis.Infrastructure.Database.Tests")]
namespace Polkanalysis.Infrastructure.Database.Repository.Events.Auctions
{
    public class SearchCriteriaAuctionsAuctionStarted : SearchCriteria
    {
        public NumberCriteria<uint>? AuctionIndex { get; set; }
        public NumberCriteria<uint>? LeasePeriod { get; set; }
        public NumberCriteria<uint>? Ending { get; set; }
    }

    [BindEvents(RuntimeEvent.Auctions, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Auctions.Enums.Event.AuctionStarted")]
    public class AuctionsAuctionStartedRepository : EventDatabaseRepository<AuctionsAuctionStartedModel, SearchCriteriaAuctionsAuctionStarted>
    {
        public AuctionsAuctionStartedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<AuctionsAuctionStartedRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "Auctions.AuctionStarted";

        protected override DbSet<AuctionsAuctionStartedModel> dbTable => _context.EventAuctionsAuctionStarted;

        protected override Task<IQueryable<AuctionsAuctionStartedModel>> SearchInnerAsync(SearchCriteriaAuctionsAuctionStarted criteria, IQueryable<AuctionsAuctionStartedModel> model, CancellationToken token)
        {
            if (criteria.AuctionIndex is not null) model = model.WhereCriteria(criteria.AuctionIndex, x => x.AuctionIndex);
            if (criteria.LeasePeriod is not null) model = model.WhereCriteria(criteria.LeasePeriod, x => x.LeasePeriod);
            if (criteria.Ending is not null) model = model.WhereCriteria(criteria.Ending, x => x.Ending);
            return Task.FromResult(model);
        }

        internal async override Task<AuctionsAuctionStartedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Auctions.Enums.EnumEvent,
                BaseTuple<U32, U32, U32>>();

            var auctionIndex = (uint)convertedData.Value[0].As<U32>();

            var leasePeriod = (uint)convertedData.Value[1].As<U32>();

            var ending = (uint)convertedData.Value[2].As<U32>();

            return new AuctionsAuctionStartedModel(
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
