using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Staking;
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
        (BaseTuple<U32, SubstrateAccount>, Exposure)? GetEraValidator(int eraId, SubstrateAccount validatorAccount);

        IEnumerable<(SubstrateAccount, Exposure)> GetValidatorsVotedByNominator(int eraId, SubstrateAccount nominatorAccount);

        void InsertEraStakers(U32 eraId, (BaseTuple<U32, SubstrateAccount>, Exposure) eraStakers);
    }
}