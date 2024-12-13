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
using Polkanalysis.Hub;

[assembly: InternalsVisibleTo("Polkanalysis.Infrastructure.Database.Tests")]
namespace Polkanalysis.Infrastructure.Database.Repository.Events.Balances
{
    public class SearchCriteriaBalancesEndowed : SearchCriteria
    {
        public string? AccountAddress { get; set; }
        public NumberCriteria<double>? Amount { get; set; }
    }

    [BindEvents(RuntimeEvent.Balances, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums.Event.Endowed")]
    public class BalancesEndowedRepository : EventDatabaseRepository<BalancesEndowedModel, SearchCriteriaBalancesEndowed>
    {
        public BalancesEndowedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IHubConnection hubConnection,
            ILogger<BalancesEndowedRepository> logger) : base(context, substrateNodeRepository, hubConnection, logger)
        {
        }

        public override string SearchName => "Balances.Endowed";

        protected override DbSet<BalancesEndowedModel> dbTable => _context.EventBalancesEndowed;

        protected override Task<IQueryable<BalancesEndowedModel>> SearchInnerAsync(SearchCriteriaBalancesEndowed criteria, IQueryable<BalancesEndowedModel> model, CancellationToken token)
        {
            if (criteria.AccountAddress is not null) model = model.Where(x => x.AccountAddress == criteria.AccountAddress);
            if (criteria.Amount is not null) model = model.WhereCriteria(criteria.Amount, x => x.Amount);
            return Task.FromResult(model);
        }

        internal async override Task<BalancesEndowedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums.EnumEvent,
                BaseTuple<SubstrateAccount, U128>>();

            var accountAddress = convertedData.Value[0].As<SubstrateAccount>().ToStringAddress();

            var amount = ((U128)convertedData.Value[1]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals); ;

            return new BalancesEndowedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
accountAddress,
amount);
        }
    }
}
