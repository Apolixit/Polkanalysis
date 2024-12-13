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
    public class SearchCriteriaNftsTipSent : SearchCriteria
    {
        public NumberCriteria<double>? Collection { get; set; }
		public string? Item { get; set; }
		public string? Sender { get; set; }
		public string? Receiver { get; set; }
		public NumberCriteria<double>? Amount { get; set; }
		
    }

    [BindEvents(RuntimeEvent.Nfts, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.TipSent")]
    public class NftsTipSentRepository : EventDatabaseRepository<NftsTipSentModel, SearchCriteriaNftsTipSent>
    {
        public NftsTipSentRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IHubConnection hubConnection,
            ILogger<NftsTipSentRepository> logger) : base(context, substrateNodeRepository, hubConnection, logger)
        {
        }

        public override string SearchName => "Nfts.TipSent";

        protected override DbSet<NftsTipSentModel> dbTable => _context.EventNftsTipSent;

        protected override Task<IQueryable<NftsTipSentModel>> SearchInnerAsync(SearchCriteriaNftsTipSent criteria, IQueryable<NftsTipSentModel> model, CancellationToken token)
        {
            if (criteria.Collection is not null) model = model.WhereCriteria(criteria.Collection, x => x.Collection);
			if (criteria.Item is not null) model = model.Where(x => x.Item == criteria.Item);
			if (criteria.Sender is not null) model = model.Where(x => x.Sender == criteria.Sender);
			if (criteria.Receiver is not null) model = model.Where(x => x.Receiver == criteria.Receiver);
			if (criteria.Amount is not null) model = model.WhereCriteria(criteria.Amount, x => x.Amount);
			
            return Task.FromResult(model);
        }

        internal async override Task<NftsTipSentModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent, BaseTuple<IncrementableU256, U128, SubstrateAccount, SubstrateAccount, U128>>();

            
			var collection = (double)(BigInteger)convertedData.Value[0].As<IncrementableU256>().Value;

			var item = ((U128)convertedData.Value[1]).Value.ToString();

			var sender = convertedData.Value[2].As<SubstrateAccount>().ToStringAddress();

			var receiver = convertedData.Value[3].As<SubstrateAccount>().ToStringAddress();

			var amount = ((U128)convertedData.Value[4]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);;
            return new NftsTipSentModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent                ,
				collection,
				item,
				sender,
				receiver,
				amount);
        }
    }
}
