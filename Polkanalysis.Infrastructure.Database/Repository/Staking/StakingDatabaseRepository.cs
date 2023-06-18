using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Staking;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Staking;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.Contracts.Secondary;
using Microsoft.EntityFrameworkCore;

namespace Polkanalysis.Infrastructure.Database.Repository.Staking
{
    public class StakingDatabaseRepository : IStakingDatabaseRepository
    {
        protected readonly SubstrateDbContext _context;
        private readonly ISubstrateService _substrateService;
        protected readonly ILogger<StakingDatabaseRepository> _logger;

        public StakingDatabaseRepository(SubstrateDbContext context, ILogger<StakingDatabaseRepository> logger, ISubstrateService substrateService)
        {
            _context = context;
            _logger = logger;
            _substrateService = substrateService;
        }

        public void InsertEraStakers(U32 eraId, (BaseTuple<U32, SubstrateAccount>, Exposure) eraStakers)
        {
            try
            {
                var model = new EraStakersModel(eraStakers, _substrateService.BlockchainName, eraId);
                _context.EraStakersModels.Add(model);
                var nbRows = _context.SaveChanges();
                if (nbRows != 1 + model.EraNominatorsVote.Count())
                    throw new InvalidOperationException("Inserted rows are inconsistent");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while trying to insert in database");
            }
        }

        public IEnumerable<(BaseTuple<U32, SubstrateAccount>, Exposure)> GetAllEraStackers(int eraId)
        {
            var eraStackersModel = _context.EraStakersModels.Where(x => 
            x.EraId == eraId && 
            x.BlockchainName == _substrateService.BlockchainName);

            return eraStackersModel.Select(x => x.ToCore());
        }

        public (BaseTuple<U32, SubstrateAccount>, Exposure)? GetEraValidator(int eraId, SubstrateAccount validatorAccount)
        {
            return _context.EraStakersModels
                .SingleOrDefault(x => 
                x.EraId == eraId &&
                x.ValidatorAddress == validatorAccount.ToPolkadotAddress() &&
                x.BlockchainName == _substrateService.BlockchainName)?
                .ToCore();
        }

        public IEnumerable<(SubstrateAccount, Exposure)> GetValidatorsVotedByNominator(int eraId, SubstrateAccount nominatorAccount)
        {
            return _context.EraStakersModels
                .Where(x => x.EraId == eraId && x.EraNominatorsVote.Any(n => n.NominatorAddress == nominatorAccount.ToPolkadotAddress()))
                .Select(x => new ValueTuple<SubstrateAccount, Exposure>(
                    new SubstrateAccount(x.ValidatorAddress), 
                    new Exposure(
                        new BaseCom<U128>(new Substrate.NetApi.CompactInteger(x.TotalStake)),
                        new BaseCom<U128>(new Substrate.NetApi.CompactInteger(x.OwnStake)),
                        new BaseVec<IndividualExposure>(x.EraNominatorsVote.Select(x => x.ToCore()).ToArray())
                )));
        }
    }
}
