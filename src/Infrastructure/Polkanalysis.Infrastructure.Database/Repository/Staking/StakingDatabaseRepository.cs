using Microsoft.Extensions.Logging;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Staking;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Microsoft.EntityFrameworkCore;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

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
                _logger.LogError(ex, "Error while trying to insert in database (EraId = {eraId})", eraId);
            }
        }

        public IEnumerable<(BaseTuple<U32, SubstrateAccount>, Exposure)> GetAllEraStackers(int eraId)
        {
            var eraStackersModel = _context.EraStakersModels.Where(x => 
            x.EraId == eraId && 
            x.BlockchainName == _substrateService.BlockchainName);

            return eraStackersModel.Select(x => x.ToCore());
        }

        public async Task<(BaseTuple<U32, SubstrateAccount>, Exposure)?> GetEraValidatorAsync(int eraId, SubstrateAccount validatorAccount, CancellationToken cancellationToken)
        {
            var res = await _context.EraStakersModels
                .SingleOrDefaultAsync(x => 
                x.EraId == eraId &&
                x.ValidatorAddress == validatorAccount.ToPolkadotAddress() &&
                x.BlockchainName == _substrateService.BlockchainName, cancellationToken);

            if(res == null) { return null; }

            return res.ToCore();
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

        public async Task<int> GetNominatorCountVotedForValidatorAsync(int eraId, SubstrateAccount validatorAccount, CancellationToken cancellationToken)
        {
            var stackersValidator = await GetEraValidatorAsync(eraId, validatorAccount, cancellationToken);
            if (stackersValidator is null) return 0;

            return (int)stackersValidator.Value.Item2.NominatorCount.Value;
        }
    }
}
