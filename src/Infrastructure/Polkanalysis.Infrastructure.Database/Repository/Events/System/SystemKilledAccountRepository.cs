using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.System;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Polkanalysis.Infrastructure.Database.Tests")]
namespace Polkanalysis.Infrastructure.Database.Repository.Events.System
{
    public class SearchCriteriaSystemKilledAccount : SearchCriteria
    {
        public string? AccountAddress { get; set; }
    }

    [BindEvents(RuntimeEvent.System, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums.Event.KilledAccount")]
    public class SystemKilledAccountRepository : EventDatabaseRepository<SystemKilledAccountModel, SearchCriteriaSystemKilledAccount>
    {
        public SystemKilledAccountRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<SystemKilledAccountRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "System.KilledAccount";

        protected override DbSet<SystemKilledAccountModel> dbTable => _context.EventSystemKilledAccount;

        protected override Task<IQueryable<SystemKilledAccountModel>> SearchInnerAsync(SearchCriteriaSystemKilledAccount criteria, IQueryable<SystemKilledAccountModel> model, CancellationToken token)
        {
            if (criteria.AccountAddress is not null) model = model.Where(x => x.AccountAddress == criteria.AccountAddress);
            return Task.FromResult(model);
        }

        internal async override Task<SystemKilledAccountModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums.EnumEvent,
                SubstrateAccount>();

            var accountAddress = convertedData.As<SubstrateAccount>().ToStringAddress();

            return new SystemKilledAccountModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
accountAddress);
        }
    }
}
