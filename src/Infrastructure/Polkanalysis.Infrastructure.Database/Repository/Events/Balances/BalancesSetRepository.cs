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
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;

namespace Polkanalysis.Infrastructure.Database.Repository.Events.Balances
{
    [BindEvents(RuntimeEvent.Balances, "Blockchain.Contracts.Pallet.Balances.Enums.Event.BalanceSet")]
    public class BalancesSetRepository : EventDatabaseRepository<BalancesBalanceSetModel>, ISearchEvent
    {
        public BalancesSetRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<BalancesSetRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public string SearchName { get => "Balances.BalanceSet"; }

        protected override DbSet<BalancesBalanceSetModel> dbTable => _context.EventBalancesBalanceSet;

        public override Task<IEnumerable<EventModel>> SearchAsync(SearchCriteria criteria, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        internal override async Task<BalancesBalanceSetModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Blockchain.Contracts.Pallet.Balances.Enums.EnumEvent,
                BaseTuple<SubstrateAccount, U128, U128>>();

            var rootAccount = ((SubstrateAccount)convertedData.Value[0]).ToStringAddress();
            var amount1 = ((U128)convertedData.Value[1]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);
            var amount2 = ((U128)convertedData.Value[2]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);

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
