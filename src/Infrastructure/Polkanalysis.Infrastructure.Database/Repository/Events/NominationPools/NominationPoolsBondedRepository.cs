using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Substrate.NetApi.Model.Types;
using System.Runtime.CompilerServices;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.NominationPools;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Hub;
[assembly: InternalsVisibleTo("Polkanalysis.Infrastructure.Database.Tests")]

namespace Polkanalysis.Infrastructure.Database.Repository.Events.NominationPools
{
    public class SearchCriteriaNominationPoolsBonded : SearchCriteria
    {
        public string? Member { get; set; }
        public NumberCriteria<uint>? Pool_id { get; set; }
        public NumberCriteria<double>? Bonded { get; set; }
        public bool? Joined { get; set; }
    }

    [BindEvents(RuntimeEvent.NominationPools, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.Event.Bonded")]
    public class NominationPoolsBondedRepository : EventDatabaseRepository<NominationPoolsBondedModel, SearchCriteriaNominationPoolsBonded>
    {
        public NominationPoolsBondedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IHubConnection hubConnection,
            ILogger<NominationPoolsBondedRepository> logger) : base(context, substrateNodeRepository, hubConnection, logger)
        {
        }

        public override string SearchName => "NominationPools.Bonded";

        protected override DbSet<NominationPoolsBondedModel> dbTable => _context.EventNominationPoolsBonded;

        protected override Task<IQueryable<NominationPoolsBondedModel>> SearchInnerAsync(SearchCriteriaNominationPoolsBonded criteria, IQueryable<NominationPoolsBondedModel> model, CancellationToken token)
        {
            if (criteria.Member is not null) model = model.Where(x => x.Member == criteria.Member);
            if (criteria.Pool_id is not null) model = model.WhereCriteria(criteria.Pool_id, x => x.Pool_id);
            if (criteria.Bonded is not null) model = model.WhereCriteria(criteria.Bonded, x => x.Bonded);
            if (criteria.Joined is not null) model = model.Where(x => x.Joined == criteria.Joined);
            return Task.FromResult(model);
        }

        internal async override Task<NominationPoolsBondedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.EnumEvent,
                BaseTuple<SubstrateAccount, U32, U128, Bool>>();


            var member = convertedData.Value[0].As<SubstrateAccount>().ToStringAddress();

            var pool_id = (uint)convertedData.Value[1].As<U32>();

            var bonded = ((U128)convertedData.Value[2]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals); ;

            var joined = (bool)convertedData.Value[3].As<Bool>();
            return new NominationPoolsBondedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
                member,
                pool_id,
                bonded,
                joined);
        }
    }
}
