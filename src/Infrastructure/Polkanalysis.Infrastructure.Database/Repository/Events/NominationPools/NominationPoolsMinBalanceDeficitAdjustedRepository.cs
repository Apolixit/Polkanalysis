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
    public class SearchCriteriaNominationPoolsMinBalanceDeficitAdjusted : SearchCriteria
    {
        public NumberCriteria<uint>? Pool_id { get; set; }
		public NumberCriteria<double>? Amount { get; set; }
		
    }

    [BindEvents(RuntimeEvent.NominationPools, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.Event.MinBalanceDeficitAdjusted")]
    public class NominationPoolsMinBalanceDeficitAdjustedRepository : EventDatabaseRepository<NominationPoolsMinBalanceDeficitAdjustedModel, SearchCriteriaNominationPoolsMinBalanceDeficitAdjusted>
    {
        public NominationPoolsMinBalanceDeficitAdjustedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<NominationPoolsMinBalanceDeficitAdjustedRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "NominationPools.MinBalanceDeficitAdjusted";

        protected override DbSet<NominationPoolsMinBalanceDeficitAdjustedModel> dbTable => _context.EventNominationPoolsMinBalanceDeficitAdjusted;

        protected override Task<IQueryable<NominationPoolsMinBalanceDeficitAdjustedModel>> SearchInnerAsync(SearchCriteriaNominationPoolsMinBalanceDeficitAdjusted criteria, IQueryable<NominationPoolsMinBalanceDeficitAdjustedModel> model, CancellationToken token)
        {
            if (criteria.Pool_id is not null) model = model.WhereCriteria(criteria.Pool_id, x => x.Pool_id);
			if (criteria.Amount is not null) model = model.WhereCriteria(criteria.Amount, x => x.Amount);
			
            return Task.FromResult(model);
        }

        internal async override Task<NominationPoolsMinBalanceDeficitAdjustedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.EnumEvent,
                BaseTuple<U32, U128>>();

            
			var pool_id = (uint)convertedData.Value[0].As<U32>();

			var amount = ((U128)convertedData.Value[1]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);;
            return new NominationPoolsMinBalanceDeficitAdjustedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent                ,
				pool_id,
				amount);
        }
    }
}
