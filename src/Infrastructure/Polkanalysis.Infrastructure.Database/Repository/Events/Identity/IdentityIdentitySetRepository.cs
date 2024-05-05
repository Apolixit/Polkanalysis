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
    public class IdentityIdentitySetRepository : EventDatabaseRepository<IdentityIdentitySetModel>
    {
        public IdentityIdentitySetRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IBlockchainMapping mapping,
            ILogger<IdentityIdentitySetRepository> logger) : base(context, substrateNodeRepository, mapping, logger)
        {
        }

        protected override DbSet<IdentityIdentitySetModel> dbTable => _context.EventIdentityIdentitySet;

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
