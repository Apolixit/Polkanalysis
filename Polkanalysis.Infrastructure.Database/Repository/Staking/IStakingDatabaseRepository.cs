using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Staking;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Infrastructure.Database.Repository.Staking
{
    public interface IStakingDatabaseRepository
    {
        IEnumerable<(BaseTuple<U32, SubstrateAccount>, Exposure)> GetAllEraStackers(int eraId);
        (BaseTuple<U32, SubstrateAccount>, Exposure)? GetEraValidator(int eraId, SubstrateAccount validatorAccount);
        void InsertEraStakers(string blockchainName, U32 eraId, (BaseTuple<U32, SubstrateAccount>, Exposure) eraStakers);
    }
}