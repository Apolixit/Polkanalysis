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
    public class SearchCriteriaNftsCollectionMaxSupplySet : SearchCriteria
    {
        public NumberCriteria<double>? Collection { get; set; }
		public NumberCriteria<double>? Max_supply { get; set; }
		
    }

    [BindEvents(RuntimeEvent.Nfts, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.CollectionMaxSupplySet")]
    public class NftsCollectionMaxSupplySetRepository : EventDatabaseRepository<NftsCollectionMaxSupplySetModel, SearchCriteriaNftsCollectionMaxSupplySet>
    {
        public NftsCollectionMaxSupplySetRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<NftsCollectionMaxSupplySetRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "Nfts.CollectionMaxSupplySet";

        protected override DbSet<NftsCollectionMaxSupplySetModel> dbTable => _context.EventNftsCollectionMaxSupplySet;

        protected override Task<IQueryable<NftsCollectionMaxSupplySetModel>> SearchInnerAsync(SearchCriteriaNftsCollectionMaxSupplySet criteria, IQueryable<NftsCollectionMaxSupplySetModel> model, CancellationToken token)
        {
            if (criteria.Collection is not null) model = model.WhereCriteria(criteria.Collection, x => x.Collection);
			if (criteria.Max_supply is not null) model = model.WhereCriteria(criteria.Max_supply, x => x.Max_supply);
			
            return Task.FromResult(model);
        }

        internal async override Task<NftsCollectionMaxSupplySetModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent, BaseTuple<IncrementableU256, U128>>();

            
			var collection = (double)(BigInteger)convertedData.Value[0].As<IncrementableU256>().Value;

			var max_supply = ((U128)convertedData.Value[1]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);;
            return new NftsCollectionMaxSupplySetModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent                ,
				collection,
				max_supply);
        }
    }
}
