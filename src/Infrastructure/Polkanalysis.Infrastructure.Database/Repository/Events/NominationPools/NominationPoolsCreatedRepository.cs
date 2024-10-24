using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Substrate.NetApi.Model.Types;
using System.Runtime.CompilerServices;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.NominationPools;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
[assembly: InternalsVisibleTo("Polkanalysis.Infrastructure.Database.Tests")]

namespace Polkanalysis.Infrastructure.Database.Repository.Events.NominationPools
{
    public class SearchCriteriaNominationPoolsCreated : SearchCriteria
    {
        public string? Depositor { get; set; }
        public NumberCriteria<uint>? Pool_id { get; set; }
    }

    [BindEvents(RuntimeEvent.NominationPools, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.Event.Created")]
    public class NominationPoolsCreatedRepository : EventDatabaseRepository<NominationPoolsCreatedModel, SearchCriteriaNominationPoolsCreated>
    {
        public NominationPoolsCreatedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<NominationPoolsCreatedRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "NominationPools.Created";

        protected override DbSet<NominationPoolsCreatedModel> dbTable => _context.EventNominationPoolsCreated;

        protected override Task<IQueryable<NominationPoolsCreatedModel>> SearchInnerAsync(SearchCriteriaNominationPoolsCreated criteria, IQueryable<NominationPoolsCreatedModel> model, CancellationToken token)
        {
            if (criteria.Depositor is not null) model = model.Where(x => x.Depositor == criteria.Depositor);
if (criteria.Pool_id is not null) model = model.WhereCriteria(criteria.Pool_id, x => x.Pool_id);
            return Task.FromResult(model);
        }

        internal async override Task<NominationPoolsCreatedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.EnumEvent,
                BaseTuple<SubstrateAccount, U32>>();

            
				var depositor = convertedData.Value[0].As<SubstrateAccount>().ToStringAddress();

				var pool_id = (uint)convertedData.Value[1].As<U32>();
            return new NominationPoolsCreatedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent                ,
				depositor,
				pool_id);
        }
    }
}
