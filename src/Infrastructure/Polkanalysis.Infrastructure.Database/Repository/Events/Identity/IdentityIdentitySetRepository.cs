using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Identity;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Polkanalysis.Infrastructure.Database.Tests")]
namespace Polkanalysis.Infrastructure.Database.Repository.Events.Identity
{
    public class SearchCriteriaIdentityIdentitySet : SearchCriteria
    {
        public string? AccountAddress { get; set; }
    }

    [BindEvents(RuntimeEvent.Identity, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums.Event.IdentitySet")]
    public class IdentityIdentitySetRepository : EventDatabaseRepository<IdentityIdentitySetModel, SearchCriteriaIdentityIdentitySet>
    {
        public IdentityIdentitySetRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<IdentityIdentitySetRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "Identity.IdentitySet";

        protected override DbSet<IdentityIdentitySetModel> dbTable => _context.EventIdentityIdentitySet;

        protected override Task<IQueryable<IdentityIdentitySetModel>> SearchInnerAsync(SearchCriteriaIdentityIdentitySet criteria, IQueryable<IdentityIdentitySetModel> model, CancellationToken token)
        {
            if (criteria.AccountAddress is not null) model = model.Where(x => x.AccountAddress == criteria.AccountAddress);
            return Task.FromResult(model);
        }

        internal async override Task<IdentityIdentitySetModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums.EnumEvent,
                SubstrateAccount>();

            var accountAddress = convertedData.As<SubstrateAccount>().ToStringAddress();

            return new IdentityIdentitySetModel(
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
