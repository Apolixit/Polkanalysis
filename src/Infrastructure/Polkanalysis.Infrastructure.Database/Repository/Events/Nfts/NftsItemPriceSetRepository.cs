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
    public class SearchCriteriaNftsItemPriceSet : SearchCriteria
    {
        public NumberCriteria<double>? Collection { get; set; }
		public NumberCriteria<double>? Item { get; set; }
		public NumberCriteria<double>? Price { get; set; }
		public string? Whitelisted_buyer { get; set; }
		
    }

    [BindEvents(RuntimeEvent.Nfts, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.ItemPriceSet")]
    public class NftsItemPriceSetRepository : EventDatabaseRepository<NftsItemPriceSetModel, SearchCriteriaNftsItemPriceSet>
    {
        public NftsItemPriceSetRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<NftsItemPriceSetRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "Nfts.ItemPriceSet";

        protected override DbSet<NftsItemPriceSetModel> dbTable => _context.EventNftsItemPriceSet;

        protected override Task<IQueryable<NftsItemPriceSetModel>> SearchInnerAsync(SearchCriteriaNftsItemPriceSet criteria, IQueryable<NftsItemPriceSetModel> model, CancellationToken token)
        {
            if (criteria.Collection is not null) model = model.WhereCriteria(criteria.Collection, x => x.Collection);
			if (criteria.Item is not null) model = model.WhereCriteria(criteria.Item, x => x.Item);
			if (criteria.Price is not null) model = model.WhereCriteria(criteria.Price, x => x.Price);
			if (criteria.Whitelisted_buyer is not null) model = model.Where(x => x.Whitelisted_buyer == criteria.Whitelisted_buyer);
			
            return Task.FromResult(model);
        }

        internal async override Task<NftsItemPriceSetModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent, BaseTuple<IncrementableU256, U128, U128, BaseOpt<SubstrateAccount>>>();

            
			var collection = (double)(BigInteger)convertedData.Value[0].As<IncrementableU256>().Value;

			var item = ((U128)convertedData.Value[1]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);;

			var price = ((U128)convertedData.Value[2]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);;

			var whitelisted_buyer = convertedData.Value[3].As<BaseOpt<SubstrateAccount>?>()?.Value?.ToStringAddress();
            return new NftsItemPriceSetModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent                ,
				collection,
				item,
				price,
				whitelisted_buyer);
        }
    }
}
