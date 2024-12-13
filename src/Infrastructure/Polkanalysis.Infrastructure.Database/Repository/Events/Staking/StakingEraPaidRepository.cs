using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Substrate.NetApi.Model.Types;
using System.Runtime.CompilerServices;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Staking;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Polkanalysis.Hub;

[assembly: InternalsVisibleTo("Polkanalysis.Infrastructure.Database.Tests")]

namespace Polkanalysis.Infrastructure.Database.Repository.Events.Staking
{
    public class SearchCriteriaStakingEraPaid : SearchCriteria
    {
        public NumberCriteria<uint>? Era_index { get; set; }
		public NumberCriteria<double>? Validator_payout { get; set; }
		public NumberCriteria<double>? Remainder { get; set; }
		
    }

    [BindEvents(RuntimeEvent.Staking, "Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking.Enums.Event.EraPaid")]
    public class StakingEraPaidRepository : EventDatabaseRepository<StakingEraPaidModel, SearchCriteriaStakingEraPaid>
    {
        public StakingEraPaidRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IHubConnection hubConnection,
            ILogger<StakingEraPaidRepository> logger) : base(context, substrateNodeRepository, hubConnection, logger)
        {
        }

        public override string SearchName => "Staking.EraPaid";

        protected override DbSet<StakingEraPaidModel> dbTable => _context.EventStakingEraPaid;

        protected override Task<IQueryable<StakingEraPaidModel>> SearchInnerAsync(SearchCriteriaStakingEraPaid criteria, IQueryable<StakingEraPaidModel> model, CancellationToken token)
        {
            if (criteria.Era_index is not null) model = model.WhereCriteria(criteria.Era_index, x => x.Era_index);
			if (criteria.Validator_payout is not null) model = model.WhereCriteria(criteria.Validator_payout, x => x.Validator_payout);
			if (criteria.Remainder is not null) model = model.WhereCriteria(criteria.Remainder, x => x.Remainder);
			
            return Task.FromResult(model);
        }

        internal async override Task<StakingEraPaidModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking.Enums.EnumEvent, BaseTuple<U32, U128, U128>>();

            
			var era_index = (uint)convertedData.Value[0].As<U32>();

			var validator_payout = ((U128)convertedData.Value[1]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);;

			var remainder = ((U128)convertedData.Value[2]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);;
            return new StakingEraPaidModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent                ,
				era_index,
				validator_payout,
				remainder);
        }
    }
}
