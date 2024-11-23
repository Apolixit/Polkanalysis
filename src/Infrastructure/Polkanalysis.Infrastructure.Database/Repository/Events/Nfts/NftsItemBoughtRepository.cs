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
    public class SearchCriteriaNftsItemBought : SearchCriteria
    {
        public NumberCriteria<double>? Collection { get; set; }
		public NumberCriteria<double>? Item { get; set; }
		public NumberCriteria<double>? Price { get; set; }
		public string? Seller { get; set; }
		public string? Buyer { get; set; }
		
    }

    [BindEvents(RuntimeEvent.Nfts, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.ItemBought")]
    public class NftsItemBoughtRepository : EventDatabaseRepository<NftsItemBoughtModel, SearchCriteriaNftsItemBought>
    {
        public NftsItemBoughtRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<NftsItemBoughtRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "Nfts.ItemBought";

        protected override DbSet<NftsItemBoughtModel> dbTable => _context.EventNftsItemBought;

        protected override Task<IQueryable<NftsItemBoughtModel>> SearchInnerAsync(SearchCriteriaNftsItemBought criteria, IQueryable<NftsItemBoughtModel> model, CancellationToken token)
        {
            if (criteria.Collection is not null) model = model.WhereCriteria(criteria.Collection, x => x.Collection);
			if (criteria.Item is not null) model = model.WhereCriteria(criteria.Item, x => x.Item);
			if (criteria.Price is not null) model = model.WhereCriteria(criteria.Price, x => x.Price);
			if (criteria.Seller is not null) model = model.Where(x => x.Seller == criteria.Seller);
			if (criteria.Buyer is not null) model = model.Where(x => x.Buyer == criteria.Buyer);
			
            return Task.FromResult(model);
        }

        internal async override Task<NftsItemBoughtModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent, BaseTuple<IncrementableU256, U128, U128, SubstrateAccount, SubstrateAccount>>();

            
			var collection = (double)(BigInteger)convertedData.Value[0].As<IncrementableU256>().Value;

			var item = ((U128)convertedData.Value[1]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);;

			var price = ((U128)convertedData.Value[2]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);;

			var seller = convertedData.Value[3].As<SubstrateAccount>().ToStringAddress();

			var buyer = convertedData.Value[4].As<SubstrateAccount>().ToStringAddress();
            return new NftsItemBoughtModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent                ,
				collection,
				item,
				price,
				seller,
				buyer);
        }
    }
}
