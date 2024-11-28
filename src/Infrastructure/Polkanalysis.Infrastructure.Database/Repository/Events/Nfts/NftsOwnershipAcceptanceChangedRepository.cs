//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
//using Polkanalysis.Infrastructure.Blockchain.Contracts;
//using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
//using Substrate.NetApi.Model.Types;
//using System.Runtime.CompilerServices;
//using Substrate.NetApi.Model.Types.Base;
//using Substrate.NetApi.Model.Types.Primitive;
//using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Nfts;
//using Substrate.NET.Utils;
//using Polkanalysis.Domain.Contracts.Common.Search;
//using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
//using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Types;
//using System.Numerics;

//[assembly: InternalsVisibleTo("Polkanalysis.Infrastructure.Database.Tests")]

//namespace Polkanalysis.Infrastructure.Database.Repository.Events.Nfts
//{
//    public class SearchCriteriaNftsOwnershipAcceptanceChanged : SearchCriteria
//    {
//        public string? Who { get; set; }
//		public NumberCriteria<double>? Maybe_collection { get; set; }
		
//    }

//    [BindEvents(RuntimeEvent.Nfts, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.OwnershipAcceptanceChanged")]
//    public class NftsOwnershipAcceptanceChangedRepository : EventDatabaseRepository<NftsOwnershipAcceptanceChangedModel, SearchCriteriaNftsOwnershipAcceptanceChanged>
//    {
//        public NftsOwnershipAcceptanceChangedRepository(
//            SubstrateDbContext context,
//            ISubstrateService substrateNodeRepository,
//            ILogger<NftsOwnershipAcceptanceChangedRepository> logger) : base(context, substrateNodeRepository, logger)
//        {
//        }

//        public override string SearchName => "Nfts.OwnershipAcceptanceChanged";

//        protected override DbSet<NftsOwnershipAcceptanceChangedModel> dbTable => _context.EventNftsOwnershipAcceptanceChanged;

//        protected override Task<IQueryable<NftsOwnershipAcceptanceChangedModel>> SearchInnerAsync(SearchCriteriaNftsOwnershipAcceptanceChanged criteria, IQueryable<NftsOwnershipAcceptanceChangedModel> model, CancellationToken token)
//        {
//            if (criteria.Who is not null) model = model.Where(x => x.Who == criteria.Who);
//			if (criteria.Maybe_collection is not null) model = model.WhereCriteria(criteria.Maybe_collection, x => x.Maybe_collection);
			
//            return Task.FromResult(model);
//        }

//        internal async override Task<NftsOwnershipAcceptanceChangedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
//        {
//            var convertedData = data.CastToEnumValues<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent, BaseTuple<SubstrateAccount, BaseOpt<IncrementableU256>>>();

            
//			var who = convertedData.Value[0].As<SubstrateAccount>().ToStringAddress();

//			var maybe_collection = (double)(BigInteger)convertedData.Value[1].As<BaseOpt<IncrementableU256>>().Value.Value;
//            return new NftsOwnershipAcceptanceChangedModel(
//                eventModel.BlockchainName,
//                eventModel.BlockId,
//                eventModel.BlockDate,
//                eventModel.EventId,
//                eventModel.ModuleName,
//                eventModel.ModuleEvent                ,
//				who,
//				maybe_collection);
//        }
//    }
//}
