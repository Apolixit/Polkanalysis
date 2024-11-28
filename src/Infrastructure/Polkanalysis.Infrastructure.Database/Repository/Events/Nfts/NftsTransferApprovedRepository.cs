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
    public class SearchCriteriaNftsTransferApproved : SearchCriteria
    {
        public NumberCriteria<double>? Collection { get; set; }
		public string? Item { get; set; }
		public string? Owner { get; set; }
		public string? Delegate { get; set; }
		public NumberCriteria<uint>? Deadline { get; set; }
		
    }

    [BindEvents(RuntimeEvent.Nfts, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.TransferApproved")]
    public class NftsTransferApprovedRepository : EventDatabaseRepository<NftsTransferApprovedModel, SearchCriteriaNftsTransferApproved>
    {
        public NftsTransferApprovedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<NftsTransferApprovedRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "Nfts.TransferApproved";

        protected override DbSet<NftsTransferApprovedModel> dbTable => _context.EventNftsTransferApproved;

        protected override Task<IQueryable<NftsTransferApprovedModel>> SearchInnerAsync(SearchCriteriaNftsTransferApproved criteria, IQueryable<NftsTransferApprovedModel> model, CancellationToken token)
        {
            if (criteria.Collection is not null) model = model.WhereCriteria(criteria.Collection, x => x.Collection);
			if (criteria.Item is not null) model = model.Where(x => x.Item == criteria.Item);
			if (criteria.Owner is not null) model = model.Where(x => x.Owner == criteria.Owner);
			if (criteria.Delegate is not null) model = model.Where(x => x.Delegate == criteria.Delegate);
			if (criteria.Deadline is not null) model = model.WhereCriteria(criteria.Deadline, x => x.Deadline);
			
            return Task.FromResult(model);
        }

        internal async override Task<NftsTransferApprovedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent, BaseTuple<IncrementableU256, U128, SubstrateAccount, SubstrateAccount, BaseOpt<U32>>>();

            
			var collection = (double)(BigInteger)convertedData.Value[0].As<IncrementableU256>().Value;

			var item = ((U128)convertedData.Value[1]).Value.ToString();

			var owner = convertedData.Value[2].As<SubstrateAccount>().ToStringAddress();

			var delegateValue = convertedData.Value[3].As<SubstrateAccount>().ToStringAddress();

			var deadline = (uint?)convertedData.Value[4].As<BaseOpt<U32>>().Value;
            return new NftsTransferApprovedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent                ,
				collection,
				item,
				owner,
                delegateValue,
                deadline.GetValueOrDefault());
        }
    }
}
