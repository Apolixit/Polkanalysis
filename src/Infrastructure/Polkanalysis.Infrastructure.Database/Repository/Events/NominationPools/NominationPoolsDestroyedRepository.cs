using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
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

[assembly: InternalsVisibleTo("Polkanalysis.Infrastructure.Database.Tests")]

namespace Polkanalysis.Infrastructure.Database.Repository.Events.NominationPools
{
    public class SearchCriteriaNominationPoolsDestroyed : SearchCriteria
    {
        public NumberCriteria<uint>? Pool_id { get; set; }
		
    }

    [BindEvents(RuntimeEvent.NominationPools, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.Event.Destroyed")]
    public class NominationPoolsDestroyedRepository : EventDatabaseRepository<NominationPoolsDestroyedModel, SearchCriteriaNominationPoolsDestroyed>
    {
        public NominationPoolsDestroyedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<NominationPoolsDestroyedRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "NominationPools.Destroyed";

        protected override DbSet<NominationPoolsDestroyedModel> dbTable => _context.EventNominationPoolsDestroyed;

        protected override Task<IQueryable<NominationPoolsDestroyedModel>> SearchInnerAsync(SearchCriteriaNominationPoolsDestroyed criteria, IQueryable<NominationPoolsDestroyedModel> model, CancellationToken token)
        {
            if (criteria.Pool_id is not null) model = model.WhereCriteria(criteria.Pool_id, x => x.Pool_id);
			
            return Task.FromResult(model);
        }

        internal async override Task<NominationPoolsDestroyedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.EnumEvent,
                U32>();

            
			var pool_id = (uint)convertedData.As<U32>();
            return new NominationPoolsDestroyedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent                ,
				pool_id);
        }
    }
}
