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

[assembly: InternalsVisibleTo("Polkanalysis.Infrastructure.Database.Tests")]

namespace Polkanalysis.Infrastructure.Database.Repository.Events.Nfts
{
    public class SearchCriteriaNftsCollectionMetadataSet : SearchCriteria
    {
        public NumberCriteria<double>? Collection { get; set; }
		public string? Data { get; set; }
		
    }

    [BindEvents(RuntimeEvent.Nfts, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.CollectionMetadataSet")]
    public class NftsCollectionMetadataSetRepository : EventDatabaseRepository<NftsCollectionMetadataSetModel, SearchCriteriaNftsCollectionMetadataSet>
    {
        public NftsCollectionMetadataSetRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<NftsCollectionMetadataSetRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "Nfts.CollectionMetadataSet";

        protected override DbSet<NftsCollectionMetadataSetModel> dbTable => _context.EventNftsCollectionMetadataSet;

        protected override Task<IQueryable<NftsCollectionMetadataSetModel>> SearchInnerAsync(SearchCriteriaNftsCollectionMetadataSet criteria, IQueryable<NftsCollectionMetadataSetModel> model, CancellationToken token)
        {
            if (criteria.Collection is not null) model = model.WhereCriteria(criteria.Collection, x => x.Collection);
			if (criteria.Data is not null) model = model.Where(x => x.Data == criteria.Data);
			
            return Task.FromResult(model);
        }

        internal async override Task<NftsCollectionMetadataSetModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent, BaseTuple<IncrementableU256, BaseVec<U8>>>();

            
			var collection = (double)(BigInteger)convertedData.Value[0].As<IncrementableU256>().Value;

			var dataVal = Encoding.UTF8.GetString(convertedData.Value[1].As<BaseVec<U8>>().Value.SelectMany(x => x.Bytes).ToArray());

            return new NftsCollectionMetadataSetModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent                ,
				collection,
				dataVal);
        }
    }
}
