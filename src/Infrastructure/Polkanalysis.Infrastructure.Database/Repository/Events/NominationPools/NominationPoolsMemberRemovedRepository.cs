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
    public class SearchCriteriaNominationPoolsMemberRemoved : SearchCriteria
    {
        public NumberCriteria<uint>? Pool_id { get; set; }
		public string? Member { get; set; }
		
    }

    [BindEvents(RuntimeEvent.NominationPools, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.Event.MemberRemoved")]
    public class NominationPoolsMemberRemovedRepository : EventDatabaseRepository<NominationPoolsMemberRemovedModel, SearchCriteriaNominationPoolsMemberRemoved>
    {
        public NominationPoolsMemberRemovedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<NominationPoolsMemberRemovedRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "NominationPools.MemberRemoved";

        protected override DbSet<NominationPoolsMemberRemovedModel> dbTable => _context.EventNominationPoolsMemberRemoved;

        protected override Task<IQueryable<NominationPoolsMemberRemovedModel>> SearchInnerAsync(SearchCriteriaNominationPoolsMemberRemoved criteria, IQueryable<NominationPoolsMemberRemovedModel> model, CancellationToken token)
        {
            if (criteria.Pool_id is not null) model = model.WhereCriteria(criteria.Pool_id, x => x.Pool_id);
			if (criteria.Member is not null) model = model.Where(x => x.Member == criteria.Member);
			
            return Task.FromResult(model);
        }

        internal async override Task<NominationPoolsMemberRemovedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.EnumEvent,
                BaseTuple<U32, SubstrateAccount>>();

            
			var pool_id = (uint)convertedData.Value[0].As<U32>();

			var member = convertedData.Value[1].As<SubstrateAccount>().ToStringAddress();
            return new NominationPoolsMemberRemovedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent                ,
				pool_id,
				member);
        }
    }
}
