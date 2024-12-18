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
    public class SearchCriteriaBalancesReserved : SearchCriteria
    {
        public string? AccountAddress { get; set; }
        public NumberCriteria<double>? ReservedAmount { get; set; }
    }

    [BindEvents(RuntimeEvent.Balances, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums.Event.Reserved")]
    public class BalancesReservedRepository : EventDatabaseRepository<BalancesReservedModel, SearchCriteriaBalancesReserved>
    {
        public BalancesReservedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IHubConnection hubConnection,
            ILogger<BalancesReservedRepository> logger) : base(context, substrateNodeRepository, hubConnection, logger)
        {
        }

        public override string SearchName => "Balances.Reserved";

        protected override DbSet<BalancesReservedModel> dbTable => _context.EventBalancesReserved;

        protected override Task<IQueryable<BalancesReservedModel>> SearchInnerAsync(SearchCriteriaBalancesReserved criteria, IQueryable<BalancesReservedModel> model, CancellationToken token)
        {
            if (criteria.AccountAddress is not null) model = model.Where(x => x.AccountAddress == criteria.AccountAddress);
            if (criteria.ReservedAmount is not null) model = model.WhereCriteria(criteria.ReservedAmount, x => x.ReservedAmount);
            return Task.FromResult(model);
        }

        internal async override Task<BalancesReservedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums.EnumEvent,
                BaseTuple<SubstrateAccount, U128>>();

            var accountAddress = convertedData.Value[0].As<SubstrateAccount>().ToStringAddress();

            var reservedAmount = ((U128)convertedData.Value[1]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals); ;

            return new BalancesReservedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
accountAddress,
reservedAmount);
        }
    }
}
