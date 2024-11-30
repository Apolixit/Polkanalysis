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
    public class SearchCriteriaNftsOwnerChanged : SearchCriteria
    {
        public NumberCriteria<double>? Collection { get; set; }
		public string? New_owner { get; set; }
		
    }

    [BindEvents(RuntimeEvent.Nfts, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.OwnerChanged")]
    public class NftsOwnerChangedRepository : EventDatabaseRepository<NftsOwnerChangedModel, SearchCriteriaNftsOwnerChanged>
    {
        public NftsOwnerChangedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<NftsOwnerChangedRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "Nfts.OwnerChanged";

        protected override DbSet<NftsOwnerChangedModel> dbTable => _context.EventNftsOwnerChanged;

        protected override Task<IQueryable<NftsOwnerChangedModel>> SearchInnerAsync(SearchCriteriaNftsOwnerChanged criteria, IQueryable<NftsOwnerChangedModel> model, CancellationToken token)
        {
            if (criteria.Collection is not null) model = model.WhereCriteria(criteria.Collection, x => x.Collection);
			if (criteria.New_owner is not null) model = model.Where(x => x.New_owner == criteria.New_owner);
			
            return Task.FromResult(model);
        }

        internal async override Task<NftsOwnerChangedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent, BaseTuple<IncrementableU256, SubstrateAccount>>();

            
			var collection = (double)(BigInteger)convertedData.Value[0].As<IncrementableU256>().Value;

			var new_owner = convertedData.Value[1].As<SubstrateAccount>().ToStringAddress();
            return new NftsOwnerChangedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent                ,
				collection,
				new_owner);
        }
    }
}
