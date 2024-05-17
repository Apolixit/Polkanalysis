using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
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

[assembly: InternalsVisibleTo("Polkanalysis.Infrastructure.Database.Tests")]
namespace Polkanalysis.Infrastructure.Database.Repository.Events.Balances
{
    public class SearchCriteriaBalancesBalanceSet : SearchCriteria
    {
        public string? RootAccount { get; set; }
        public NumberCriteria<double>? Amount1 { get; set; }
        public NumberCriteria<double>? Amount2 { get; set; }
    }

    [BindEvents(RuntimeEvent.Balances, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums.Event.BalanceSet")]
    public class BalancesBalanceSetRepository : EventDatabaseRepository<BalancesBalanceSetModel, SearchCriteriaBalancesBalanceSet>
    {
        public BalancesBalanceSetRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<BalancesBalanceSetRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "Balances.BalanceSet";

        protected override DbSet<BalancesBalanceSetModel> dbTable => _context.EventBalancesBalanceSet;

        protected override Task<IQueryable<BalancesBalanceSetModel>> SearchInnerAsync(SearchCriteriaBalancesBalanceSet criteria, IQueryable<BalancesBalanceSetModel> model, CancellationToken token)
        {
            if (criteria.RootAccount is not null) model = model.Where(x => x.RootAccount == criteria.RootAccount);
            if (criteria.Amount1 is not null) model = model.WhereCriteria(criteria.Amount1, x => x.Amount1);
            if (criteria.Amount2 is not null) model = model.WhereCriteria(criteria.Amount2, x => x.Amount2);
            return Task.FromResult(model);
        }

        internal async override Task<BalancesBalanceSetModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums.EnumEvent,
                BaseTuple<SubstrateAccount, U128, U128>>();

            var rootAccount = convertedData.Value[0].As<SubstrateAccount>().ToStringAddress();

            var amount1 = ((U128)convertedData.Value[1]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals); ;

            var amount2 = ((U128)convertedData.Value[2]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals); ;

            return new BalancesBalanceSetModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
rootAccount,
amount1,
amount2);
        }
    }
}
