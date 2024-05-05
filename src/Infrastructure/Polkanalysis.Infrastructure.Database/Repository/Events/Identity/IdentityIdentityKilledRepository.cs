using Microsoft.Extensions.Logging;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Domain.Contracts.Core;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NET.Utils;
using Microsoft.EntityFrameworkCore;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Identity;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Database.Contracts.Model;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;

namespace Polkanalysis.Infrastructure.Database.Repository.Events.Identity
{
    [BindEvents(RuntimeEvent.Identity, "Blockchain.Contracts.Pallet.Identity.Enums.Event.IdentityKilled")]
    public class IdentityIdentityKilledRepository : EventDatabaseRepository<IdentityIdentityKilledModel>
    {
        public IdentityIdentityKilledRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IBlockchainMapping mapping,
            ILogger<IdentityIdentityKilledRepository> logger) : base(context, substrateNodeRepository, mapping, logger)
        {
        }

        protected override DbSet<IdentityIdentityKilledModel> dbTable => _context.EventIdentityIdentityKilled;

        internal override async Task<IdentityIdentityKilledModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Blockchain.Contracts.Pallet.Identity.Enums.EnumEvent,
                BaseTuple<SubstrateAccount, U128>>();

            var account = ((SubstrateAccount)convertedData.Value[0]).ToStringAddress();
            var amount = ((U128)convertedData.Value[1]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);

            return new IdentityIdentityKilledModel(
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
