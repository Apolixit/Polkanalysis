using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Core;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Database.Contracts.Model;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;

namespace Polkanalysis.Infrastructure.Database.Repository.Events.Balances
{
    public class BalancesDustLostRepository : EventDatabaseRepository<BalancesDustLostModel>
    {
        public BalancesDustLostRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IBlockchainMapping mapping,
            ILogger<BalancesDustLostRepository> logger) :
            base(context, substrateNodeRepository, mapping, logger)
        {
        }

        protected override DbSet<BalancesDustLostModel> dbTable => _context.EventBalancesDustLost;

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
