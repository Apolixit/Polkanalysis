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
    public class SearchCriteriaNftsCollectionMintSettingsUpdated : SearchCriteria
    {
        public NumberCriteria<double>? Collection { get; set; }
		
    }

    [BindEvents(RuntimeEvent.Nfts, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.CollectionMintSettingsUpdated")]
    public class NftsCollectionMintSettingsUpdatedRepository : EventDatabaseRepository<NftsCollectionMintSettingsUpdatedModel, SearchCriteriaNftsCollectionMintSettingsUpdated>
    {
        public NftsCollectionMintSettingsUpdatedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IHubConnection hubConnection,
            ILogger<NftsCollectionMintSettingsUpdatedRepository> logger) : base(context, substrateNodeRepository, hubConnection, logger)
        {
        }

        public override string SearchName => "Nfts.CollectionMintSettingsUpdated";

        protected override DbSet<NftsCollectionMintSettingsUpdatedModel> dbTable => _context.EventNftsCollectionMintSettingsUpdated;

        protected override Task<IQueryable<NftsCollectionMintSettingsUpdatedModel>> SearchInnerAsync(SearchCriteriaNftsCollectionMintSettingsUpdated criteria, IQueryable<NftsCollectionMintSettingsUpdatedModel> model, CancellationToken token)
        {
            if (criteria.Collection is not null) model = model.WhereCriteria(criteria.Collection, x => x.Collection);
			
            return Task.FromResult(model);
        }

        internal async override Task<NftsCollectionMintSettingsUpdatedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent, IncrementableU256>();

            
			var collection = (double)(BigInteger)convertedData.Value;
            return new NftsCollectionMintSettingsUpdatedModel(
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
