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
using System.Text;
using Polkanalysis.Hub;

[assembly: InternalsVisibleTo("Polkanalysis.Infrastructure.Database.Tests")]

namespace Polkanalysis.Infrastructure.Database.Repository.Events.Nfts
{
    public class SearchCriteriaNftsItemMetadataSet : SearchCriteria
    {
        public NumberCriteria<double>? Collection { get; set; }
		public string? Item { get; set; }
		public string? Data { get; set; }
		
    }

    [BindEvents(RuntimeEvent.Nfts, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.ItemMetadataSet")]
    public class NftsItemMetadataSetRepository : EventDatabaseRepository<NftsItemMetadataSetModel, SearchCriteriaNftsItemMetadataSet>
    {
        public NftsItemMetadataSetRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IHubConnection hubConnection,
            ILogger<NftsItemMetadataSetRepository> logger) : base(context, substrateNodeRepository, hubConnection, logger)
        {
        }

        public override string SearchName => "Nfts.ItemMetadataSet";

        protected override DbSet<NftsItemMetadataSetModel> dbTable => _context.EventNftsItemMetadataSet;

        protected override Task<IQueryable<NftsItemMetadataSetModel>> SearchInnerAsync(SearchCriteriaNftsItemMetadataSet criteria, IQueryable<NftsItemMetadataSetModel> model, CancellationToken token)
        {
            if (criteria.Collection is not null) model = model.WhereCriteria(criteria.Collection, x => x.Collection);
			if (criteria.Item is not null) model = model.Where(x => x.Item == criteria.Item);
			if (criteria.Data is not null) model = model.Where(x => x.Data == criteria.Data);
			
            return Task.FromResult(model);
        }

        internal async override Task<NftsItemMetadataSetModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent, BaseTuple<IncrementableU256, U128, BaseVec<U8>>>();

            
			var collection = (double)(BigInteger)convertedData.Value[0].As<IncrementableU256>().Value;

			var item = ((U128)convertedData.Value[1]).Value.ToString();

			var dataValue = Encoding.UTF8.GetString(convertedData.Value[2].As<BaseVec<U8>>().Value.SelectMany(x => x.Bytes).ToArray());
            return new NftsItemMetadataSetModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent                ,
				collection,
				item,
                dataValue);
        }
    }
}
