using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Identity;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System.Runtime.CompilerServices;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

[assembly: InternalsVisibleTo("Polkanalysis.Infrastructure.Database.Tests")]
namespace Polkanalysis.Infrastructure.Database.Repository.Events.Identity
{
    public class SearchCriteriaIdentityIdentityKilled : SearchCriteria
    {
        public string? AccountAddress { get; set; }
        public NumberCriteria<double>? Amount { get; set; }
    }

    [BindEvents(RuntimeEvent.Identity, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums.Event.IdentityKilled")]
    public class IdentityIdentityKilledRepository : EventDatabaseRepository<IdentityIdentityKilledModel, SearchCriteriaIdentityIdentityKilled>
    {
        public IdentityIdentityKilledRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<IdentityIdentityKilledRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "Identity.IdentityKilled";

        protected override DbSet<IdentityIdentityKilledModel> dbTable => _context.EventIdentityIdentityKilled;

        protected override Task<IQueryable<IdentityIdentityKilledModel>> SearchInnerAsync(SearchCriteriaIdentityIdentityKilled criteria, IQueryable<IdentityIdentityKilledModel> model, CancellationToken token)
        {
            if (criteria.AccountAddress is not null) model = model.Where(x => x.AccountAddress == criteria.AccountAddress);
            if (criteria.Amount is not null) model = model.WhereCriteria(criteria.Amount, x => x.Amount);
            return Task.FromResult(model);
        }

        internal async override Task<IdentityIdentityKilledModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums.EnumEvent,
                BaseTuple<SubstrateAccount, U128>>();

            var accountAddress = convertedData.Value[0].As<SubstrateAccount>().ToStringAddress();

            var amount = ((U128)convertedData.Value[1]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals); ;

            return new IdentityIdentityKilledModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
accountAddress,
amount);
        }
    }
}
