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

namespace Polkanalysis.Infrastructure.Database.Repository.Events.Balances
{
    [BindEvents(RuntimeEvent.Balances, "Blockchain.Contracts.Pallet.Balances.Enums.Event.Reserved")]
    public class BalancesReservedRepository : EventDatabaseRepository<BalancesReservedModel>
    {
        public BalancesReservedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IBlockchainMapping mapping,
            ILogger<BalancesReservedRepository> logger) : base(context, substrateNodeRepository, mapping, logger)
        {
        }

        protected override DbSet<BalancesReservedModel> dbTable => _context.EventBalancesReserved;

        internal override async Task<BalancesReservedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Blockchain.Contracts.Pallet.Balances.Enums.EnumEvent,
                BaseTuple<SubstrateAccount, U128>>();

            var account = ((SubstrateAccount)convertedData.Value[0]).ToStringAddress();
            var reservedAmount = ((U128)convertedData.Value[1]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);

            return new BalancesReservedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
                account,
                reservedAmount);
        }
    }
}
