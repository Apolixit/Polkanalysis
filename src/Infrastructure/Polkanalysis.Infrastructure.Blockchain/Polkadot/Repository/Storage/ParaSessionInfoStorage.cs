using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Core.Public;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.ParaSessionInfo;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using ParaSessionStorageExt = Polkanalysis.Polkadot.NetApiExt.Generated.Storage.ParaSessionInfoStorage;
using Substrate.NetApi.Model.Types.Base.Abstraction;
using Substrate.NetApi.Model.Types;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Storage
{
    public class ParaSessionInfoStorage : MainStorage, IParaSessionInfoStorage
    {
        public ParaSessionInfoStorage(SubstrateClientExt client, ILogger logger) : base(client, logger) { }

        public async Task<BaseVec<SubstrateAccount>> AccountKeysAsync(U32 key, CancellationToken token)
        {
            return Map<IBaseEnumerable, BaseVec<SubstrateAccount>>(await _client.ParaSessionInfoStorage.AccountKeysAsync(key, token));
        }

        public async Task<BaseVec<PublicSr25519>> AssignmentKeysUnsafeAsync(CancellationToken token)
        {
            return Map<IBaseEnumerable, BaseVec<PublicSr25519>>(await _client.ParaSessionInfoStorage.AssignmentKeysUnsafeAsync(token));
        }

        public async Task<U32> EarliestStoredSessionAsync(CancellationToken token)
        {
            return await _client.ParaSessionInfoStorage.EarliestStoredSessionAsync(token);
        }

        public async Task<ExecutorParams> SessionExecutorParamsAsync(U32 key, CancellationToken token)
        {
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v4.executor_params.ExecutorParamsBase, ExecutorParams>(
                await _client.ParaSessionInfoStorage.SessionExecutorParamsAsync(key, token));
        }

        public async Task<SessionInfo> SessionsAsync(U32 key, CancellationToken token)
        {
            return Map<IType, SessionInfo>(
                await _client.ParaSessionInfoStorage.SessionsAsync(key, token));
        }
    }
}
