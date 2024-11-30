using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Substrate.NetApi.Model.Types;
using System.Runtime.CompilerServices;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Nfts;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Types;
using System.Numerics;

[assembly: InternalsVisibleTo("Polkanalysis.Infrastructure.Database.Tests")]

namespace Polkanalysis.Infrastructure.Database.Repository.Events.Nfts
{
    public class SearchCriteriaNftsNextCollectionIdIncremented : SearchCriteria
    {
        public NumberCriteria<double>? Next_id { get; set; }
		
    }

    [BindEvents(RuntimeEvent.Nfts, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.NextCollectionIdIncremented")]
    public class NftsNextCollectionIdIncrementedRepository : EventDatabaseRepository<NftsNextCollectionIdIncrementedModel, SearchCriteriaNftsNextCollectionIdIncremented>
    {
        public NftsNextCollectionIdIncrementedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<NftsNextCollectionIdIncrementedRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "Nfts.NextCollectionIdIncremented";

        protected override DbSet<NftsNextCollectionIdIncrementedModel> dbTable => _context.EventNftsNextCollectionIdIncremented;

        protected override Task<IQueryable<NftsNextCollectionIdIncrementedModel>> SearchInnerAsync(SearchCriteriaNftsNextCollectionIdIncremented criteria, IQueryable<NftsNextCollectionIdIncrementedModel> model, CancellationToken token)
        {
            if (criteria.Next_id is not null) model = model.WhereCriteria(criteria.Next_id, x => x.Next_id);
			
            return Task.FromResult(model);
        }

        internal async override Task<NftsNextCollectionIdIncrementedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent, BaseOpt<IncrementableU256>>();

            
			var next_id = (double)(BigInteger)convertedData.Value.Value;
            return new NftsNextCollectionIdIncrementedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent                ,
				next_id);
        }
    }
}
