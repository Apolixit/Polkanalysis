using Microsoft.Extensions.Logging;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Domain.Contracts.Core;
using Microsoft.EntityFrameworkCore;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.System;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Database.Contracts.Model;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Substrate.NET.Utils;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;

namespace Polkanalysis.Infrastructure.Database.Repository.Events.System
{
    [BindEvents(RuntimeEvent.System, "Blockchain.Contracts.Pallet.System.Enums.Event.NewAccount")]
    public class SystemNewAccountRepository : EventDatabaseRepository<SystemNewAccountModel>, ISearchEvent
    {
        public SystemNewAccountRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<SystemNewAccountRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public string SearchName { get => "System.NewAccount"; }

        protected override DbSet<SystemNewAccountModel> dbTable => _context.EventSystemNewAccount;

        public override Task<IEnumerable<EventModel>> SearchAsync(SearchCriteria criteria, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        internal override async Task<SystemNewAccountModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Blockchain.Contracts.Pallet.System.Enums.EnumEvent,
                SubstrateAccount>();

            var account = convertedData.ToStringAddress();

            return new SystemNewAccountModel(
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
