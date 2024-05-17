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
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Polkanalysis.Infrastructure.Database.Tests")]
namespace Polkanalysis.Infrastructure.Database.Repository.Events.Crowdloan
{
    public class SearchCriteriaCrowdloanContributed : SearchCriteria
    {
        public string? AccountAddess { get; set; }
        public NumberCriteria<int>? CrowdloanId { get; set; }
        public NumberCriteria<double>? Amount { get; set; }
    }

    [BindEvents(RuntimeEvent.Crowdloan, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Crowdloan.Enums.Event.Contributed")]
    public class CrowdloanContributedRepository : EventDatabaseRepository<CrowdloanContributedModel, SearchCriteriaCrowdloanContributed>
    {
        public CrowdloanContributedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<CrowdloanContributedRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "Crowdloan.Contributed";

        protected override DbSet<CrowdloanContributedModel> dbTable => _context.EventCrowdloanContributed;

        protected override Task<IQueryable<CrowdloanContributedModel>> SearchInnerAsync(SearchCriteriaCrowdloanContributed criteria, IQueryable<CrowdloanContributedModel> model, CancellationToken token)
        {
            if (criteria.AccountAddess is not null) model = model.Where(x => x.AccountAddess == criteria.AccountAddess);
            if (criteria.CrowdloanId is not null) model = model.WhereCriteria(criteria.CrowdloanId, x => x.CrowdloanId);
            if (criteria.Amount is not null) model = model.WhereCriteria(criteria.Amount, x => x.Amount);
            return Task.FromResult(model);
        }

        internal async override Task<CrowdloanContributedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Crowdloan.Enums.EnumEvent,
                BaseTuple<SubstrateAccount, Id, U128>>();

            var accountAddess = convertedData.Value[0].As<SubstrateAccount>().ToStringAddress();
            var crowdloanId = (int)convertedData.Value[1].As<Id>().Value.Value;
            var amount = ((U128)convertedData.Value[2]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);

            return new CrowdloanContributedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
accountAddess,
crowdloanId,
amount);
        }
    }
}
