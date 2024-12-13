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
using Polkanalysis.Hub;

[assembly: InternalsVisibleTo("Polkanalysis.Infrastructure.Database.Tests")]

namespace Polkanalysis.Infrastructure.Database.Repository.Events.NominationPools
{
    public class SearchCriteriaNominationPoolsWithdrawn : SearchCriteria
    {
        public string? Member { get; set; }
		public NumberCriteria<uint>? Pool_id { get; set; }
		public NumberCriteria<double>? Balance { get; set; }
		public NumberCriteria<double>? Points { get; set; }
		
    }

    [BindEvents(RuntimeEvent.NominationPools, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.Event.Withdrawn")]
    public class NominationPoolsWithdrawnRepository : EventDatabaseRepository<NominationPoolsWithdrawnModel, SearchCriteriaNominationPoolsWithdrawn>
    {
        public NominationPoolsWithdrawnRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IHubConnection hubConnection,
            ILogger<NominationPoolsWithdrawnRepository> logger) : base(context, substrateNodeRepository, hubConnection, logger)
        {
        }

        public override string SearchName => "NominationPools.Withdrawn";

        protected override DbSet<NominationPoolsWithdrawnModel> dbTable => _context.EventNominationPoolsWithdrawn;

        protected override Task<IQueryable<NominationPoolsWithdrawnModel>> SearchInnerAsync(SearchCriteriaNominationPoolsWithdrawn criteria, IQueryable<NominationPoolsWithdrawnModel> model, CancellationToken token)
        {
            if (criteria.Member is not null) model = model.Where(x => x.Member == criteria.Member);
			if (criteria.Pool_id is not null) model = model.WhereCriteria(criteria.Pool_id, x => x.Pool_id);
			if (criteria.Balance is not null) model = model.WhereCriteria(criteria.Balance, x => x.Balance);
			if (criteria.Points is not null) model = model.WhereCriteria(criteria.Points, x => x.Points);
			
            return Task.FromResult(model);
        }

        internal async override Task<NominationPoolsWithdrawnModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.EnumEvent,
                BaseTuple<SubstrateAccount, U32, U128, U128>>();

            
			var member = convertedData.Value[0].As<SubstrateAccount>().ToStringAddress();

			var pool_id = (uint)convertedData.Value[1].As<U32>();

			var balance = ((U128)convertedData.Value[2]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);;

			var points = ((U128)convertedData.Value[3]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);;
            return new NominationPoolsWithdrawnModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent                ,
				member,
				pool_id,
				balance,
				points);
        }
    }
}
