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
    public class IdentityIdentityKilledRepository : EventDatabaseRepository<IdentityIdentityKilledModel>, ISearchEvent
    {
        public IdentityIdentityKilledRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<IdentityIdentityKilledRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public string SearchName { get => "Identity.IdentityKilled"; }
        protected override DbSet<IdentityIdentityKilledModel> dbTable => _context.EventIdentityIdentityKilled;

        public override Task<IEnumerable<EventModel>> SearchAsync(SearchCriteria criteria, CancellationToken token)
        {
            throw new NotImplementedException();
        }

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
