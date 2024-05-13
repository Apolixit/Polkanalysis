using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Core;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;

namespace Polkanalysis.Infrastructure.Database.Repository.Events.Balances
{
    public record SearchCriteriaBalancesTransfert(DateTime? From, DateTime? To, string? FromAddress, string? ToAddress, double? minAmount) : SearchCriteria(From, To);

    [BindEvents(RuntimeEvent.Balances, "Blockchain.Contracts.Pallet.Balances.Enums.Event.Transfer")]
    public class BalancesTransferRepository : EventDatabaseRepository<BalancesTransferModel>, ISearchEvent
    {
        public BalancesTransferRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<BalancesTransferRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        protected override DbSet<BalancesTransferModel> dbTable => _context.EventBalancesTransfer;

        public string SearchName { get => "Balances.Transfer"; }

        /// <summary>
        /// Insert a new transfer in the database
        /// </summary>
        /// <param name="eventModel"></param>
        /// <param name="data"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        internal override async Task<BalancesTransferModel> BuildModelAsync(
            EventModel eventModel,
            IType data,
            CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Blockchain.Contracts.Pallet.Balances.Enums.EnumEvent, 
                BaseTuple<SubstrateAccount, SubstrateAccount, U128>>();

            var transferAmount = ((U128)convertedData.Value[2]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);

            return new BalancesTransferModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
                ((SubstrateAccount)convertedData.Value[0]).ToStringAddress(),
                ((SubstrateAccount)convertedData.Value[1]).ToStringAddress(),
                transferAmount);
        }

        public override async Task<IEnumerable<EventModel>> SearchAsync(SearchCriteria criteria, CancellationToken token)
        {
            var c = (SearchCriteriaBalancesTransfert)criteria;

            if (c is null)
                throw new InvalidOperationException($"Try to search {SearchName} event, but search criteria is not type of {nameof(SearchCriteriaBalancesTransfert)} but type {criteria.GetType().Name}");


            var accountBalancesTransfer = _context.EventBalancesTransfer.AsQueryable();

            if(!string.IsNullOrEmpty(c.FromAddress))
                accountBalancesTransfer = accountBalancesTransfer.Where(x => x.From.ToLower() == c.FromAddress.ToLower());

            if (!string.IsNullOrEmpty(c.ToAddress))
                accountBalancesTransfer = accountBalancesTransfer.Where(x => x.To.ToLower() == c.ToAddress.ToLower());

            if (c.From is not null)
                accountBalancesTransfer = accountBalancesTransfer.Where(x => x.BlockDate >= c.From.Value);

            if (c.To is not null)
                accountBalancesTransfer = accountBalancesTransfer.Where(x => x.BlockDate <= c.To.Value);

            if (c.minAmount is not null)
                accountBalancesTransfer = accountBalancesTransfer.Where(x => x.Amount >= c.minAmount);

            var dbResult = await accountBalancesTransfer.ToListAsync();

            if (!dbResult.Any())
                _logger.LogWarning("[{repositoryName}] No transactions found in the database with query {searchQuery}", nameof(BalancesTransferRepository), c);

            return dbResult;
        }
    }
}
