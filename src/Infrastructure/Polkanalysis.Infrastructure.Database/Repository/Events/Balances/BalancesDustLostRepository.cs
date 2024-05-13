using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Core;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Infrastructure.Database.Repository.Events.Auctions;

namespace Polkanalysis.Infrastructure.Database.Repository.Events.Balances
{
    public class SearchCriteriaBalancesDustLost : SearchCriteria
    {
        public string? AccountAddress { get; set; }
        public NumberCriteria<double>? Amount { get; set; }
    }

    [BindEvents(RuntimeEvent.Balances, "Blockchain.Contracts.Pallet.Balances.Enums.Event.DustLost")]
    public class BalancesDustLostRepository : EventDatabaseRepository<BalancesDustLostModel>, ISearchEvent
    {
        public BalancesDustLostRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<BalancesDustLostRepository> logger) :
            base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "Balances.DustLost";

        protected override DbSet<BalancesDustLostModel> dbTable => _context.EventBalancesDustLost;

        public override Type GetSearchCriterias() => typeof(SearchCriteriaBalancesDustLost);

        protected override Task<IQueryable<BalancesDustLostModel>> SearchInnerAsync(SearchCriteria criteria, IQueryable<BalancesDustLostModel> model, CancellationToken token)
        {
                var c = (SearchCriteriaBalancesDustLost)criteria;

                if (c is null)
                    throw new InvalidOperationException($"Try to search {SearchName} event, but search criteria is not type of {GetSearchCriterias()} but type {criteria.GetType().Name}");

                if (c.AccountAddress is not null)
                    model = model.Where(x => x.Account.ToLower() == c.AccountAddress.ToLower());

                if (c.Amount is not null)
                    model = model.WhereCriteria(c.Amount, x => x.Amount);

                return Task.FromResult(model);
        }

        internal override async Task<BalancesDustLostModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Blockchain.Contracts.Pallet.Balances.Enums.EnumEvent,
                BaseTuple<SubstrateAccount, U128>>();

            var account = ((SubstrateAccount)convertedData.Value[0]).ToStringAddress();
            var transferAmount = ((U128)convertedData.Value[1]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);

            return new BalancesDustLostModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
                account,
                transferAmount);
        }
    }
}
