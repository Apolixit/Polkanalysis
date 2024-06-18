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
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;

[assembly: InternalsVisibleTo("Polkanalysis.Infrastructure.Database.Tests")]

namespace Polkanalysis.Infrastructure.Database.Repository.Events.NominationPools
{
    public class SearchCriteriaNominationPoolsUnbonded : SearchCriteria
    {
        public string? Member { get; set; }
		public NumberCriteria<uint>? Pool_id { get; set; }
		public NumberCriteria<double>? Balance { get; set; }
		public NumberCriteria<double>? Points { get; set; }
		public NumberCriteria<uint>? Era { get; set; }
		
    }

    [BindEvents(RuntimeEvent.NominationPools, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.Event.Unbonded")]
    public class NominationPoolsUnbondedRepository : EventDatabaseRepository<NominationPoolsUnbondedModel, SearchCriteriaNominationPoolsUnbonded>
    {
        public NominationPoolsUnbondedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<NominationPoolsUnbondedRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "NominationPools.Unbonded";

        protected override DbSet<NominationPoolsUnbondedModel> dbTable => _context.EventNominationPoolsUnbonded;

        protected override Task<IQueryable<NominationPoolsUnbondedModel>> SearchInnerAsync(SearchCriteriaNominationPoolsUnbonded criteria, IQueryable<NominationPoolsUnbondedModel> model, CancellationToken token)
        {
            if (criteria.Member is not null) model = model.Where(x => x.Member == criteria.Member);
			if (criteria.Pool_id is not null) model = model.WhereCriteria(criteria.Pool_id, x => x.Pool_id);
			if (criteria.Balance is not null) model = model.WhereCriteria(criteria.Balance, x => x.Balance);
			if (criteria.Points is not null) model = model.WhereCriteria(criteria.Points, x => x.Points);
			if (criteria.Era is not null) model = model.WhereCriteria(criteria.Era, x => x.Era);
			
            return Task.FromResult(model);
        }

        internal async override Task<NominationPoolsUnbondedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.EnumEvent,
                BaseTuple<SubstrateAccount, U32, U128, U128, U32>>();

            
			var member = convertedData.Value[0].As<SubstrateAccount>().ToStringAddress();

			var pool_id = (uint)convertedData.Value[1].As<U32>();

			var balance = ((U128)convertedData.Value[2]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);;

			var points = ((U128)convertedData.Value[3]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);;

			var era = (uint)convertedData.Value[4].As<U32>();
            return new NominationPoolsUnbondedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent                ,
				member,
				pool_id,
				balance,
				points,
				era);
        }
    }
}
