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
using Polkanalysis.Hub;

[assembly: InternalsVisibleTo("Polkanalysis.Infrastructure.Database.Tests")]

namespace Polkanalysis.Infrastructure.Database.Repository.Events.NominationPools
{
    public class SearchCriteriaNominationPoolsPoolCommissionClaimed : SearchCriteria
    {
        public NumberCriteria<uint>? Pool_id { get; set; }
		public NumberCriteria<double>? Commission { get; set; }
		
    }

    [BindEvents(RuntimeEvent.NominationPools, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.Event.PoolCommissionClaimed")]
    public class NominationPoolsPoolCommissionClaimedRepository : EventDatabaseRepository<NominationPoolsPoolCommissionClaimedModel, SearchCriteriaNominationPoolsPoolCommissionClaimed>
    {
        public NominationPoolsPoolCommissionClaimedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IHubConnection hubConnection,
            ILogger<NominationPoolsPoolCommissionClaimedRepository> logger) : base(context, substrateNodeRepository, hubConnection, logger)
        {
        }

        public override string SearchName => "NominationPools.PoolCommissionClaimed";

        protected override DbSet<NominationPoolsPoolCommissionClaimedModel> dbTable => _context.EventNominationPoolsPoolCommissionClaimed;

        protected override Task<IQueryable<NominationPoolsPoolCommissionClaimedModel>> SearchInnerAsync(SearchCriteriaNominationPoolsPoolCommissionClaimed criteria, IQueryable<NominationPoolsPoolCommissionClaimedModel> model, CancellationToken token)
        {
            if (criteria.Pool_id is not null) model = model.WhereCriteria(criteria.Pool_id, x => x.Pool_id);
			if (criteria.Commission is not null) model = model.WhereCriteria(criteria.Commission, x => x.Commission);
			
            return Task.FromResult(model);
        }

        internal async override Task<NominationPoolsPoolCommissionClaimedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.EnumEvent,
                BaseTuple<U32, U128>>();

            
			var pool_id = (uint)convertedData.Value[0].As<U32>();

			var commission = ((U128)convertedData.Value[1]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);;
            return new NominationPoolsPoolCommissionClaimedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent                ,
				pool_id,
				commission);
        }
    }
}
