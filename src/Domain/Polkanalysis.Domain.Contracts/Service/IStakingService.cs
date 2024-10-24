using Polkanalysis.Domain.Contracts.Dto.Era;
using Polkanalysis.Domain.Contracts.Dto.Staking.Era;
using Polkanalysis.Domain.Contracts.Dto.Staking.Nominator;
using Polkanalysis.Domain.Contracts.Dto.Staking.Pool;
using Polkanalysis.Domain.Contracts.Dto.Staking.Reward;
using Polkanalysis.Domain.Contracts.Dto.Staking.Validator;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Domain.Contracts.Service
{
    public interface IStakingService
    {
        #region Validator
        /// <summary>
        /// Get validator full details informations
        /// </summary>
        /// <param name="validatorAddress"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public Task<ValidatorDto> GetValidatorDetailAsync(string validatorAddress, CancellationToken cancellationToken);

        /// <summary>
        /// Get the validator voted by current nominator (for current era)
        /// </summary>
        /// <param name="nominatorAddress"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<ValidatorLightDto>> GetValidatorsElectedByNominatorAsync(string nominatorAddress, CancellationToken cancellationToken);
        public Task<IEnumerable<ValidatorLightDto>> GetValidatorsElectedByNominatorAsync(uint eraId, string nominatorAddress, CancellationToken cancellationToken);

        /// <summary>
        /// Get all current validators (active and inactive)
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<ValidatorLightDto>> GetValidatorsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Get eras and reward points
        /// </summary>
        /// <param name="validatorAddress"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<EraLightDto>> GetErasBoundedToValidatorAsync(string validatorAddress, CancellationToken cancellationToken);

        /// <summary>
        /// Get rewards given to validator for each era
        /// </summary>
        /// <param name="validatorAddress"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<RewardDto>> GetRewardsBoundedToValidatorAsync(string validatorAddress, CancellationToken cancellationToken);
        #endregion

        #region Nominator
        /// <summary>
        /// Return all nominators who voted for given validator
        /// </summary>
        /// <param name="validatorAddress"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<NominatorLightDto>> GetNominatorsBoundedToValidatorAsync(string validatorAddress, CancellationToken cancellationToken);

        /// <summary>
        /// Return all the current nominators
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<NominatorLightDto>> GetNominatorsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Return full detail of a validator
        /// </summary>
        /// <param name="nominatorAddress"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<NominatorDto> GetNominatorDetailAsync(string nominatorAddress, CancellationToken cancellationToken);
        #endregion

        #region Pools
        /// <summary>
        /// Return all current pools
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<PoolLightDto>> GetPoolsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Return pool details
        /// </summary>
        /// <param name="poolId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<PoolDto> GetPoolDetailAsync(uint poolId, CancellationToken cancellationToken);
        #endregion

        /// <summary>
        /// Return reward account associated to given stash account
        /// </summary>
        /// <param name="stashAccount"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<UserIdentityDto?> PayeeAccountAsync(SubstrateAccount stashAccount, CancellationToken cancellationToken);

        #region Era
        public Task<CurrentEraDto> CurrentEraInformationAsync(CancellationToken cancellationToken);
        #endregion
    }
}
