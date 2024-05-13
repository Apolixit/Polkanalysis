using Microsoft.Extensions.Logging;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Domain.Contracts.Core;
using Microsoft.EntityFrameworkCore;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Identity;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Database.Contracts.Model;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Substrate.NET.Utils;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;

namespace Polkanalysis.Infrastructure.Database.Repository.Events.Identity
{
    [BindEvents(RuntimeEvent.Identity, "Blockchain.Contracts.Pallet.Identity.Enums.Event.IdentitySet")]
    public class IdentityIdentitySetRepository : EventDatabaseRepository<IdentityIdentitySetModel>, ISearchEvent
    {
        public IdentityIdentitySetRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<IdentityIdentitySetRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public string SearchName { get => "Identity.IdentitySet"; }
        protected override DbSet<IdentityIdentitySetModel> dbTable => _context.EventIdentityIdentitySet;

        public override Task<IEnumerable<EventModel>> SearchAsync(SearchCriteria criteria, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        internal override async Task<IdentityIdentitySetModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Blockchain.Contracts.Pallet.Identity.Enums.EnumEvent,
                SubstrateAccount>();

            var account = convertedData.ToStringAddress();

            return new IdentityIdentitySetModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
                account);
        }
    }
}
