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
    public class SearchCriteriaNftsTransferred : SearchCriteria
    {
        public NumberCriteria<double>? Collection { get; set; }
		public NumberCriteria<double>? Item { get; set; }
		public string? From { get; set; }
		public string? To { get; set; }
		
    }

    [BindEvents(RuntimeEvent.Nfts, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.Transferred")]
    public class NftsTransferredRepository : EventDatabaseRepository<NftsTransferredModel, SearchCriteriaNftsTransferred>
    {
        public NftsTransferredRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<NftsTransferredRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "Nfts.Transferred";

        protected override DbSet<NftsTransferredModel> dbTable => _context.EventNftsTransferred;

        protected override Task<IQueryable<NftsTransferredModel>> SearchInnerAsync(SearchCriteriaNftsTransferred criteria, IQueryable<NftsTransferredModel> model, CancellationToken token)
        {
            if (criteria.Collection is not null) model = model.WhereCriteria(criteria.Collection, x => x.Collection);
			if (criteria.Item is not null) model = model.WhereCriteria(criteria.Item, x => x.Item);
			if (criteria.From is not null) model = model.Where(x => x.From == criteria.From);
			if (criteria.To is not null) model = model.Where(x => x.To == criteria.To);
			
            return Task.FromResult(model);
        }

        internal async override Task<NftsTransferredModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent, BaseTuple<IncrementableU256, U128, SubstrateAccount, SubstrateAccount>>();

            
			var collection = (double)(BigInteger)convertedData.Value[0].As<IncrementableU256>().Value;

			var item = ((U128)convertedData.Value[1]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);;

			var from = convertedData.Value[2].As<SubstrateAccount>().ToStringAddress();

			var to = convertedData.Value[3].As<SubstrateAccount>().ToStringAddress();
            return new NftsTransferredModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent                ,
				collection,
				item,
				from,
				to);
        }
    }
}
