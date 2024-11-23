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
    public class SearchCriteriaNftsCollectionMetadataCleared : SearchCriteria
    {
        public NumberCriteria<double>? Collection { get; set; }
		
    }

    [BindEvents(RuntimeEvent.Nfts, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.CollectionMetadataCleared")]
    public class NftsCollectionMetadataClearedRepository : EventDatabaseRepository<NftsCollectionMetadataClearedModel, SearchCriteriaNftsCollectionMetadataCleared>
    {
        public NftsCollectionMetadataClearedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<NftsCollectionMetadataClearedRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "Nfts.CollectionMetadataCleared";

        protected override DbSet<NftsCollectionMetadataClearedModel> dbTable => _context.EventNftsCollectionMetadataCleared;

        protected override Task<IQueryable<NftsCollectionMetadataClearedModel>> SearchInnerAsync(SearchCriteriaNftsCollectionMetadataCleared criteria, IQueryable<NftsCollectionMetadataClearedModel> model, CancellationToken token)
        {
            if (criteria.Collection is not null) model = model.WhereCriteria(criteria.Collection, x => x.Collection);
			
            return Task.FromResult(model);
        }

        internal async override Task<NftsCollectionMetadataClearedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent, IncrementableU256>();

            
			var collection = (double)(BigInteger)convertedData.Value;
            return new NftsCollectionMetadataClearedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent                ,
				collection);
        }
    }
}
