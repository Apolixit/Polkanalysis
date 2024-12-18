using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Auctions;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Substrate.NetApi.Model.Types.Primitive;
using System.Runtime.CompilerServices;
using Polkanalysis.Hub;

[assembly: InternalsVisibleTo("Polkanalysis.Infrastructure.Database.Tests")]
namespace Polkanalysis.Infrastructure.Database.Repository.Events.Auctions
{
    public class SearchCriteriaAuctionsAuctionClosed : SearchCriteria
    {
        public NumberCriteria<uint>? AuctionIndex { get; set; }
    }

    [BindEvents(RuntimeEvent.Auctions, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Auctions.Enums.Event.AuctionClosed")]
    public class AuctionsAuctionClosedRepository : EventDatabaseRepository<AuctionsAuctionClosedModel, SearchCriteriaAuctionsAuctionClosed>
    {
        public AuctionsAuctionClosedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IHubConnection hubConnection,
            ILogger<AuctionsAuctionClosedRepository> logger) : base(context, substrateNodeRepository, hubConnection, logger)
        {
        }

        public override string SearchName => "Auctions.AuctionClosed";

        protected override DbSet<AuctionsAuctionClosedModel> dbTable => _context.EventAuctionsAuctionClosed;

        protected override Task<IQueryable<AuctionsAuctionClosedModel>> SearchInnerAsync(SearchCriteriaAuctionsAuctionClosed criteria, IQueryable<AuctionsAuctionClosedModel> model, CancellationToken token)
        {
            if (criteria.AuctionIndex is not null) model = model.WhereCriteria(criteria.AuctionIndex, x => x.AuctionIndex);
            return Task.FromResult(model);
        }

        internal async override Task<AuctionsAuctionClosedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Auctions.Enums.EnumEvent,
                U32>();

            var auctionIndex = (uint)convertedData.As<U32>();

            return new AuctionsAuctionClosedModel(
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
