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
    [BindEvents(RuntimeEvent.Balances, "Blockchain.Contracts.Pallet.Balances.Enums.Event.Slashed")]
    public class BalancesSlashedRepository : EventDatabaseRepository<BalancesSlashedModel>
    {
        public BalancesSlashedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IBlockchainMapping mapping,
            ILogger<BalancesSlashedRepository> logger) : base(context, substrateNodeRepository, mapping, logger)
        {
        }

        protected override DbSet<BalancesSlashedModel> dbTable => _context.EventBalancesSlashed;


        internal override async Task<BalancesSlashedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Blockchain.Contracts.Pallet.Balances.Enums.EnumEvent,
                BaseTuple<SubstrateAccount, U128>>();

            var account = ((SubstrateAccount)convertedData.Value[0]).ToStringAddress();
            var amount = ((U128)convertedData.Value[1]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);

            return new BalancesSlashedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
                account,
                amount);
        }
    }
}
