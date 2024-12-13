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
    public class SearchCriteriaNftsItemAttributesApprovalRemoved : SearchCriteria
    {
        public NumberCriteria<double>? Collection { get; set; }
		public string? Item { get; set; }
		public string? Delegate { get; set; }
		
    }

    [BindEvents(RuntimeEvent.Nfts, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.ItemAttributesApprovalRemoved")]
    public class NftsItemAttributesApprovalRemovedRepository : EventDatabaseRepository<NftsItemAttributesApprovalRemovedModel, SearchCriteriaNftsItemAttributesApprovalRemoved>
    {
        public NftsItemAttributesApprovalRemovedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IHubConnection hubConnection,
            ILogger<NftsItemAttributesApprovalRemovedRepository> logger) : base(context, substrateNodeRepository, hubConnection, logger)
        {
        }

        public override string SearchName => "Nfts.ItemAttributesApprovalRemoved";

        protected override DbSet<NftsItemAttributesApprovalRemovedModel> dbTable => _context.EventNftsItemAttributesApprovalRemoved;

        protected override Task<IQueryable<NftsItemAttributesApprovalRemovedModel>> SearchInnerAsync(SearchCriteriaNftsItemAttributesApprovalRemoved criteria, IQueryable<NftsItemAttributesApprovalRemovedModel> model, CancellationToken token)
        {
            if (criteria.Collection is not null) model = model.WhereCriteria(criteria.Collection, x => x.Collection);
			if (criteria.Item is not null) model = model.Where(x => x.Item == criteria.Item);
			if (criteria.Delegate is not null) model = model.Where(x => x.Delegate == criteria.Delegate);
			
            return Task.FromResult(model);
        }

        internal async override Task<NftsItemAttributesApprovalRemovedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent, BaseTuple<IncrementableU256, U128, SubstrateAccount>>();

            
			var collection = (double)(BigInteger)convertedData.Value[0].As<IncrementableU256>().Value;

			var item = ((U128)convertedData.Value[1]).Value.ToString();

			var delegateValue = convertedData.Value[2].As<SubstrateAccount>().ToStringAddress();
            return new NftsItemAttributesApprovalRemovedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent                ,
				collection,
				item,
                delegateValue);
        }
    }
}
