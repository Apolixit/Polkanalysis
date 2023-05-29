using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Dto.Era;
using Polkanalysis.Domain.Contracts.Dto.Staking.Nominator;
using Polkanalysis.Domain.Contracts.Dto.Staking.Pool;
using Polkanalysis.Domain.Contracts.Dto.Staking.Reward;
using Polkanalysis.Domain.Contracts.Dto.Staking.Validator;
using Polkanalysis.Domain.Contracts.Dto.User;

namespace Polkanalysis.Domain.Contracts.Secondary.Repository
{
    public interface IStakingRepository
    {
        /// <summary>
        /// Get validator information
        /// </summary>
        /// <param name="validatorAddress"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public Task<ValidatorDto> GetValidatorDetailAsync(string validatorAddress, CancellationToken cancellationToken);
        public Task<IEnumerable<ValidatorLightDto>> GetValidatorsAsync(CancellationToken cancellationToken);

        public Task<IEnumerable<EraLightDto>> GetErasBoundedToValidatorAsync(string validatorAddress, CancellationToken cancellationToken);
        public Task<IEnumerable<RewardDto>> GetRewardsBoundedToValidatorAsync(string validatorAddress, CancellationToken cancellationToken);
        public Task<IEnumerable<NominatorLightDto>> GetNominatorsBoundedToValidatorAsync(string validatorAddress, CancellationToken cancellationToken);

        public Task<IEnumerable<NominatorLightDto>> GetNominatorsAsync(CancellationToken cancellationToken);
        public Task<NominatorDto> GetNominatorDetailAsync(string nominatorAddress, CancellationToken cancellationToken);

        public Task<IEnumerable<PoolLightDto>> GetPoolsAsync(CancellationToken cancellationToken);
        public Task<PoolDto> GetPoolDetailAsync(uint poolId, CancellationToken cancellationToken);

        public Task<UserAddressDto?> PayeeAccountAsync(SubstrateAccount stashAccount, CancellationToken cancellationToken);
    }
}
