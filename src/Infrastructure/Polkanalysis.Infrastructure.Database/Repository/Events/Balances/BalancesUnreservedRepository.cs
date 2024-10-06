using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System.Runtime.CompilerServices;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

[assembly: InternalsVisibleTo("Polkanalysis.Infrastructure.Database.Tests")]
namespace Polkanalysis.Infrastructure.Database.Repository.Events.Balances
{
    public class SearchCriteriaBalancesUnreserved : SearchCriteria
    {
        public string? AccountAddess { get; set; }
        public NumberCriteria<double>? UnreservedAmount { get; set; }
    }

    [BindEvents(RuntimeEvent.Balances, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums.Event.Unreserved")]
    public class BalancesUnreservedRepository : EventDatabaseRepository<BalancesUnreservedModel, SearchCriteriaBalancesUnreserved>
    {
        public BalancesUnreservedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<BalancesUnreservedRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "Balances.Unreserved";

        protected override DbSet<BalancesUnreservedModel> dbTable => _context.EventBalancesUnreserved;

        protected override Task<IQueryable<BalancesUnreservedModel>> SearchInnerAsync(SearchCriteriaBalancesUnreserved criteria, IQueryable<BalancesUnreservedModel> model, CancellationToken token)
        {
            if (criteria.AccountAddess is not null) model = model.Where(x => x.AccountAddess == criteria.AccountAddess);
            if (criteria.UnreservedAmount is not null) model = model.WhereCriteria(criteria.UnreservedAmount, x => x.UnreservedAmount);
            return Task.FromResult(model);
        }

        internal async override Task<BalancesUnreservedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums.EnumEvent,
                BaseTuple<SubstrateAccount, U128>>();

            var accountAddess = convertedData.Value[0].As<SubstrateAccount>().ToStringAddress();

            var unreservedAmount = ((U128)convertedData.Value[1]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);

            return new BalancesUnreservedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
accountAddess,
unreservedAmount);
        }
    }
}
