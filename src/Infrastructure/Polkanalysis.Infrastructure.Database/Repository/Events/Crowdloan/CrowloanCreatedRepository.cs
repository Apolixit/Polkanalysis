using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Crowdloan;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Polkanalysis.Infrastructure.Database.Tests")]
namespace Polkanalysis.Infrastructure.Database.Repository.Events.Crowdloan
{
    public class SearchCriteriaCrowdloanCreated : SearchCriteria
    {
        public NumberCriteria<int>? CrowdloanId { get; set; }
    }

    [BindEvents(RuntimeEvent.Crowdloan, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Crowdloan.Enums.Event.Created")]
    public class CrowdloanCreatedRepository : EventDatabaseRepository<CrowdloanCreatedModel, SearchCriteriaCrowdloanCreated>
    {
        public CrowdloanCreatedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<CrowdloanCreatedRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "Crowdloan.Created";

        protected override DbSet<CrowdloanCreatedModel> dbTable => _context.EventCrowdloanCreated;

        protected override Task<IQueryable<CrowdloanCreatedModel>> SearchInnerAsync(SearchCriteriaCrowdloanCreated criteria, IQueryable<CrowdloanCreatedModel> model, CancellationToken token)
        {
            if (criteria.CrowdloanId is not null) model = model.WhereCriteria(criteria.CrowdloanId, x => x.CrowdloanId);
            return Task.FromResult(model);
        }

        internal async override Task<CrowdloanCreatedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Crowdloan.Enums.EnumEvent,
                Id>();

            var crowdloanId = (int)convertedData.Value.Value;

            return new CrowdloanCreatedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
crowdloanId);
        }
    }
}
