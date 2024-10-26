using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Domain.Contracts.Secondary.Repository
{
    public interface IStakingDatabaseRepository
    {
        /// <summary>
        /// Get every validator and every nominator for given era
        /// </summary>
        /// <param name="eraId"></param>
        /// <returns></returns>
        IEnumerable<(BaseTuple<U32, SubstrateAccount>, Exposure)> GetAllEraStackers(int eraId);

        /// <summary>
        /// Get given validator (and associated nominators) for given era
        /// </summary>
        /// <param name="eraId"></param>
        /// <param name="validatorAccount"></param>
        /// <returns></returns>
        Task<(BaseTuple<U32, SubstrateAccount>, Exposure)?> GetEraValidatorAsync(int eraId, SubstrateAccount validatorAccount, CancellationToken cancellationToken);

        /// <summary>
        /// Return the number of nominators who voted for the given validator in specific Era
        /// </summary>
        /// <param name="eraId"></param>
        /// <param name="validatorAccount"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> GetNominatorCountVotedForValidatorAsync(int eraId, SubstrateAccount validatorAccount, CancellationToken cancellationToken);

        IEnumerable<(SubstrateAccount, Exposure)> GetValidatorsVotedByNominator(int eraId, SubstrateAccount nominatorAccount);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eraId">The Era number</param>
        /// <param name="eraStakers">
        ///     BaseTuple<U32, SubstrateAccount>, U32 is agaion EraId, SubstrateAccount is the validator address.
        ///     Exposure is the validator exposure and nominators who voted for the validator
        /// </param>
        void InsertEraStakers(U32 eraId, (BaseTuple<U32, SubstrateAccount>, Exposure) eraStakers);
    }
}