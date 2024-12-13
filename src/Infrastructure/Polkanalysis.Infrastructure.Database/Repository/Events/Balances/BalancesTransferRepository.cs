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
using Microsoft.AspNetCore.SignalR;
using Polkanalysis.Hub;
using Polkanalysis.Hub;

[assembly: InternalsVisibleTo("Polkanalysis.Infrastructure.Database.Tests")]
namespace Polkanalysis.Infrastructure.Database.Repository.Events.Balances
{
    public class SearchCriteriaBalancesTransfer : SearchCriteria
    {
        public string? From { get; set; }
        public string? To { get; set; }
        public NumberCriteria<double>? Amount { get; set; }
    }

    [BindEvents(RuntimeEvent.Balances, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums.Event.Transfer")]
    public class BalancesTransferRepository : EventDatabaseRepository<BalancesTransferModel, SearchCriteriaBalancesTransfer>
    {
        public BalancesTransferRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IHubConnection hubConnection,
            ILogger<BalancesTransferRepository> logger) : base(context, substrateNodeRepository, hubConnection, logger)
        {
        }

        public override string SearchName => "Balances.Transfer";

        protected override DbSet<BalancesTransferModel> dbTable => _context.EventBalancesTransfer;

        protected override Task<IQueryable<BalancesTransferModel>> SearchInnerAsync(SearchCriteriaBalancesTransfer criteria, IQueryable<BalancesTransferModel> model, CancellationToken token)
        {
            if (criteria.From is not null) model = model.Where(x => x.From == criteria.From);
            if (criteria.To is not null) model = model.Where(x => x.To == criteria.To);
            if (criteria.Amount is not null) model = model.WhereCriteria(criteria.Amount, x => x.Amount);
            return Task.FromResult(model);
        }

        internal async override Task<BalancesTransferModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Blockchain.Contracts.Pallet.Balances.Enums.EnumEvent,
                BaseTuple<SubstrateAccount, SubstrateAccount, U128>>();

            var from = convertedData.Value[0].As<SubstrateAccount>().ToStringAddress();

            var to = convertedData.Value[1].As<SubstrateAccount>().ToStringAddress();

            var amount = ((U128)convertedData.Value[2]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals); ;

            return new BalancesTransferModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
                from,
                to,
                amount);
        }

        public async override Task PublishEventToHubAsync(BalancesTransferModel model, CancellationToken token)
        {
            _logger.LogInformation("Publishing {eventName} to {hubName} with data: {blockchainName}, {blockId}, {from}, {to}, {amount}", SearchName, nameof(PolkanalysisHub), model.BlockchainName, model.BlockId, model.From, model.To, model.Amount);

            await _hubConnection.InvokeAsync("BalancesTransfer", model.BlockchainName, model.BlockId, model.From, model.To, model.Amount, token);
        }
    }
}
