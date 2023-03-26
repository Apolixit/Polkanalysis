using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Core.Public;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.ParaSessionInfo;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using ParaSessionStorageExt = Polkanalysis.Polkadot.NetApiExt.Generated.Storage.ParaSessionInfoStorage;

namespace Polkanalysis.Infrastructure.Polkadot.Repository.Storage
{
    public class ParaSessionInfoStorage : MainStorage, IParaSessionInfoStorage
    {
        public ParaSessionInfoStorage(SubstrateClientExt client, ILogger logger) : base(client, logger) { }

        public async Task<BaseVec<SubstrateAccount>> AccountKeysAsync(U32 key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                U32,
                BaseVec<AccountId32>,
                BaseVec <SubstrateAccount>>
                (key, ParaSessionStorageExt.AccountKeysParams, token);
        }

        public async Task<BaseVec<PublicSr25519>> AssignmentKeysUnsafeAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                BaseVec<
                        Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.assignment_app.Public> , BaseVec<PublicSr25519>>
                        (ParaSessionStorageExt.AssignmentKeysUnsafeParams, token);
        }

        public async Task<U32> EarliestStoredSessionAsync(CancellationToken token)
        {
            return await GetStorageAsync<U32>(ParaSessionStorageExt.EarliestStoredSessionParams, token);
        }

        public async Task<SessionInfo> SessionsAsync(U32 key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                U32,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.SessionInfo,
                SessionInfo>(key, ParaSessionStorageExt.SessionsParams, token);
        }
    }
}
