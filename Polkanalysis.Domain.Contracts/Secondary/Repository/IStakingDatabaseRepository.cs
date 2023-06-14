using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Staking;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Domain.Contracts.Secondary.Repository
{
    public interface IStakingDatabaseRepository
    {
        IEnumerable<(BaseTuple<U32, SubstrateAccount>, Exposure)> GetAllEraStackers(int eraId);
        (BaseTuple<U32, SubstrateAccount>, Exposure)? GetEraValidator(int eraId, SubstrateAccount validatoraccount);
        void InsertEraStakers((BaseTuple<U32, SubstrateAccount>, Exposure) eraStakers);
    }
}