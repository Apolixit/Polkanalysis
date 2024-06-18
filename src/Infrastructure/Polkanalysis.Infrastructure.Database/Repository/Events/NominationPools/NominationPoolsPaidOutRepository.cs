using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Substrate.NetApi.Model.Types;
using System.Runtime.CompilerServices;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.NominationPools;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;[assembly: InternalsVisibleTo("Polkanalysis.Infrastructure.Database.Tests")]

namespace Polkanalysis.Infrastructure.Database.Repository.Events.NominationPools
{
    public class SearchCriteriaNominationPoolsPaidOut : SearchCriteria
    {
        public string? Member { get; set; }
		public NumberCriteria<uint>? Pool_id { get; set; }
		public NumberCriteria<double>? Payout { get; set; }
		    }

    [BindEvents(RuntimeEvent.NominationPools, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.Event.PaidOut")]
    public class NominationPoolsPaidOutRepository : EventDatabaseRepository<NominationPoolsPaidOutModel, SearchCriteriaNominationPoolsPaidOut>
    {
        public NominationPoolsPaidOutRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<NominationPoolsPaidOutRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "NominationPools.PaidOut";

        protected override DbSet<NominationPoolsPaidOutModel> dbTable => _context.EventNominationPoolsPaidOut;

        protected override Task<IQueryable<NominationPoolsPaidOutModel>> SearchInnerAsync(SearchCriteriaNominationPoolsPaidOut criteria, IQueryable<NominationPoolsPaidOutModel> model, CancellationToken token)
        {
            if (criteria.Member is not null) model = model.Where(x => x.Member == criteria.Member);
			if (criteria.Pool_id is not null) model = model.WhereCriteria(criteria.Pool_id, x => x.Pool_id);
			if (criteria.Payout is not null) model = model.WhereCriteria(criteria.Payout, x => x.Payout);
			
            return Task.FromResult(model);
        }

        internal async override Task<NominationPoolsPaidOutModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.EnumEvent,
                BaseTuple<SubstrateAccount, U32, U128>>();

            
			var member = convertedData.Value[0].As<SubstrateAccount>().ToStringAddress();

			var pool_id = (uint)convertedData.Value[1].As<U32>();

			var payout = ((U128)convertedData.Value[2]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);;
            return new NominationPoolsPaidOutModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent                ,
				member,
				pool_id,
				payout);
        }
    }
}
