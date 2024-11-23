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
    public class SearchCriteriaNftsTeamChanged : SearchCriteria
    {
        public NumberCriteria<double>? Collection { get; set; }
		public string? Issuer { get; set; }
		public string? Admin { get; set; }
		public string? Freezer { get; set; }
		
    }

    [BindEvents(RuntimeEvent.Nfts, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.TeamChanged")]
    public class NftsTeamChangedRepository : EventDatabaseRepository<NftsTeamChangedModel, SearchCriteriaNftsTeamChanged>
    {
        public NftsTeamChangedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<NftsTeamChangedRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public override string SearchName => "Nfts.TeamChanged";

        protected override DbSet<NftsTeamChangedModel> dbTable => _context.EventNftsTeamChanged;

        protected override Task<IQueryable<NftsTeamChangedModel>> SearchInnerAsync(SearchCriteriaNftsTeamChanged criteria, IQueryable<NftsTeamChangedModel> model, CancellationToken token)
        {
            if (criteria.Collection is not null) model = model.WhereCriteria(criteria.Collection, x => x.Collection);
			if (criteria.Issuer is not null) model = model.Where(x => x.Issuer == criteria.Issuer);
			if (criteria.Admin is not null) model = model.Where(x => x.Admin == criteria.Admin);
			if (criteria.Freezer is not null) model = model.Where(x => x.Freezer == criteria.Freezer);
			
            return Task.FromResult(model);
        }

        internal async override Task<NftsTeamChangedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent, BaseTuple<IncrementableU256, BaseOpt<SubstrateAccount>, BaseOpt<SubstrateAccount>, BaseOpt<SubstrateAccount>>>();

            
			var collection = (double)(BigInteger)convertedData.Value[0].As<IncrementableU256>().Value;

			var issuer = convertedData.Value[1].As<BaseOpt<SubstrateAccount>?>()?.Value?.ToStringAddress();

			var admin = convertedData.Value[2].As<BaseOpt<SubstrateAccount>?>()?.Value?.ToStringAddress();

			var freezer = convertedData.Value[3].As<BaseOpt<SubstrateAccount>?>()?.Value?.ToStringAddress();
            return new NftsTeamChangedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent                ,
				collection,
				issuer,
				admin,
				freezer);
        }
    }
}
