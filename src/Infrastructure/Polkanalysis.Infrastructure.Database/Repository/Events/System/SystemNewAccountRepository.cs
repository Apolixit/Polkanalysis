using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.System;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using System.Runtime.CompilerServices;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

[assembly: InternalsVisibleTo("Polkanalysis.Infrastructure.Database.Tests")]
namespace Polkanalysis.Infrastructure.Database.Repository.Events.System
{
    public class SearchCriteriaSystemNewAccount : SearchCriteria
    {
        public string? AccountAddress { get; set; }
    }

    [BindEvents(RuntimeEvent.System, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums.Event.NewAccount")]
    public class SystemNewAccountRepository : EventDatabaseRepository<SystemNewAccountModel, SearchCriteriaSystemNewAccount>
    {
        public SystemNewAccountRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<SystemNewAccountRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "System.NewAccount";

        protected override DbSet<SystemNewAccountModel> dbTable => _context.EventSystemNewAccount;

        protected override Task<IQueryable<SystemNewAccountModel>> SearchInnerAsync(SearchCriteriaSystemNewAccount criteria, IQueryable<SystemNewAccountModel> model, CancellationToken token)
        {
            if (criteria.AccountAddress is not null) model = model.Where(x => x.AccountAddress == criteria.AccountAddress);
            return Task.FromResult(model);
        }

        internal async override Task<SystemNewAccountModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums.EnumEvent,
                SubstrateAccount>();

            var accountAddress = convertedData.As<SubstrateAccount>().ToStringAddress();

            return new SystemNewAccountModel(
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
