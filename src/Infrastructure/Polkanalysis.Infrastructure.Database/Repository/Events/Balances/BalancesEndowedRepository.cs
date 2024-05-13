using Microsoft.Extensions.Logging;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Domain.Contracts.Core;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NET.Utils;
using Microsoft.EntityFrameworkCore;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Database.Contracts.Model;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Polkanalysis.Domain.Contracts.Common.Search;

namespace Polkanalysis.Infrastructure.Database.Repository.Events.Balances
{
    public class SearchCriteriaBalancesEndowed : SearchCriteria
    {
        public string? AccountAddress { get; set; }
        public NumberCriteria<double>? Amount { get; set; }
    }

    [BindEvents(RuntimeEvent.Balances, "Blockchain.Contracts.Pallet.Balances.Enums.Event.Endowed")]
    public class BalancesEndowedRepository : EventDatabaseRepository<BalancesEndowedModel>
    {
        public BalancesEndowedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<BalancesEndowedRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "Balances.Endowed";

        protected override DbSet<BalancesEndowedModel> dbTable => _context.EventBalancesEndowed;

        public override Type GetSearchCriterias() => typeof(BalancesEndowedModel);

        protected override Task<IQueryable<BalancesEndowedModel>> SearchInnerAsync(SearchCriteria criteria, IQueryable<BalancesEndowedModel> model, CancellationToken token)
        {
            var c = (SearchCriteriaBalancesEndowed)criteria;

            if (c is null)
                throw new InvalidOperationException($"Try to search {SearchName} event, but search criteria is not type of {GetSearchCriterias()} but type {criteria.GetType().Name}");

            if (c.AccountAddress is not null)
                model = model.Where(x => x.Account.ToLower() == c.AccountAddress.ToLower());

            if (c.Amount is not null)
                model = model.WhereCriteria(c.Amount, x => x.Amount);

            return Task.FromResult(model);
        }

        internal override async Task<BalancesEndowedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Blockchain.Contracts.Pallet.Balances.Enums.EnumEvent,
                BaseTuple<SubstrateAccount, U128>>();

            var account = ((SubstrateAccount)convertedData.Value[0]).ToStringAddress();
            var transferAmount = ((U128)convertedData.Value[1]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);

            return new BalancesEndowedModel(
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
