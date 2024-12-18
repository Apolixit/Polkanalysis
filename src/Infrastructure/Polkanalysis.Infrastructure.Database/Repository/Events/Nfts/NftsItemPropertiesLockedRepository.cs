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
using Polkanalysis.Hub;

[assembly: InternalsVisibleTo("Polkanalysis.Infrastructure.Database.Tests")]

namespace Polkanalysis.Infrastructure.Database.Repository.Events.Nfts
{
    public class SearchCriteriaNftsItemPropertiesLocked : SearchCriteria
    {
        public NumberCriteria<double>? Collection { get; set; }
		public string? Item { get; set; }
		public bool? Lock_metadata { get; set; }
		public bool? Lock_attributes { get; set; }
		
    }

    [BindEvents(RuntimeEvent.Nfts, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.ItemPropertiesLocked")]
    public class NftsItemPropertiesLockedRepository : EventDatabaseRepository<NftsItemPropertiesLockedModel, SearchCriteriaNftsItemPropertiesLocked>
    {
        public NftsItemPropertiesLockedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IHubConnection hubConnection,
            ILogger<NftsItemPropertiesLockedRepository> logger) : base(context, substrateNodeRepository, hubConnection, logger)
        {
        }

        public override string SearchName => "Nfts.ItemPropertiesLocked";

        protected override DbSet<NftsItemPropertiesLockedModel> dbTable => _context.EventNftsItemPropertiesLocked;

        protected override Task<IQueryable<NftsItemPropertiesLockedModel>> SearchInnerAsync(SearchCriteriaNftsItemPropertiesLocked criteria, IQueryable<NftsItemPropertiesLockedModel> model, CancellationToken token)
        {
            if (criteria.Collection is not null) model = model.WhereCriteria(criteria.Collection, x => x.Collection);
			if (criteria.Item is not null) model = model.Where(x => x.Item == criteria.Item);
			if (criteria.Lock_metadata is not null) model = model.Where(x => x.Lock_metadata == criteria.Lock_metadata);
			if (criteria.Lock_attributes is not null) model = model.Where(x => x.Lock_attributes == criteria.Lock_attributes);
			
            return Task.FromResult(model);
        }

        internal async override Task<NftsItemPropertiesLockedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent, BaseTuple<IncrementableU256, U128, Bool, Bool>>();

            
			var collection = (double)(BigInteger)convertedData.Value[0].As<IncrementableU256>().Value;

			var item = ((U128)convertedData.Value[1]).Value.ToString();

			var lock_metadata = (bool)convertedData.Value[2].As<Bool> ();

			var lock_attributes = (bool)convertedData.Value[3].As<Bool> ();
            return new NftsItemPropertiesLockedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent                ,
				collection,
				item,
				lock_metadata,
				lock_attributes);
        }
    }
}
