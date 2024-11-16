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
    public class SearchCriteriaNftsCreated : SearchCriteria
    {
        public NumberCriteria<double>? Collection { get; set; }
		public string? Creator { get; set; }
		public string? Owner { get; set; }
		
    }

    [BindEvents(RuntimeEvent.Nfts, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.Created")]
    public class NftsCreatedRepository : EventDatabaseRepository<NftsCreatedModel, SearchCriteriaNftsCreated>
    {
        public NftsCreatedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<NftsCreatedRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "Nfts.Created";

        protected override DbSet<NftsCreatedModel> dbTable => _context.EventNftsCreated;

        protected override Task<IQueryable<NftsCreatedModel>> SearchInnerAsync(SearchCriteriaNftsCreated criteria, IQueryable<NftsCreatedModel> model, CancellationToken token)
        {
            if (criteria.Collection is not null) model = model.WhereCriteria(criteria.Collection, x => x.Collection);
			if (criteria.Creator is not null) model = model.Where(x => x.Creator == criteria.Creator);
			if (criteria.Owner is not null) model = model.Where(x => x.Owner == criteria.Owner);
			
            return Task.FromResult(model);
        }

        internal async override Task<NftsCreatedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent, BaseTuple<IncrementableU256, SubstrateAccount, SubstrateAccount>>();

            
			var collection = (double)(BigInteger)convertedData.Value[0].As<IncrementableU256>().Value;

			var creator = convertedData.Value[1].As<SubstrateAccount>().ToStringAddress();

			var owner = convertedData.Value[2].As<SubstrateAccount>().ToStringAddress();
            return new NftsCreatedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent                ,
				collection,
				creator,
				owner);
        }
    }
}
