using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Core.Public;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ParaSessionInfo;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Storage
{
    public class ParaSessionInfoStorage : MainStorage, IParaSessionInfoStorage
    {
        public ParaSessionInfoStorage(SubstrateClientExt client, IBlockchainMapping mapper, ILogger logger) : base(client, mapper, logger) { }

        public async Task<BaseVec<SubstrateAccount>> AccountKeysAsync(U32 key, CancellationToken token)
        {
            return Map<IType, BaseVec<SubstrateAccount>>(await _client.ParaSessionInfoStorage.AccountKeysAsync(key, token));
        }

        public async Task<BaseVec<PublicSr25519>> AssignmentKeysUnsafeAsync(CancellationToken token)
        {
            return Map<IType, BaseVec<PublicSr25519>>(await _client.ParaSessionInfoStorage.AssignmentKeysUnsafeAsync(token));
        }

        public async Task<U32> EarliestStoredSessionAsync(CancellationToken token)
        {
            return await _client.ParaSessionInfoStorage.EarliestStoredSessionAsync(token);
        }

        public async Task<ExecutorParams> SessionExecutorParamsAsync(U32 key, CancellationToken token)
        {
            return Map<IType, ExecutorParams>(
                await _client.ParaSessionInfoStorage.SessionExecutorParamsAsync(key, token));
        }

        public async Task<SessionInfo> SessionsAsync(U32 key, CancellationToken token)
        {
            return Map<IType, SessionInfo>(
                await _client.ParaSessionInfoStorage.SessionsAsync(key, token));
        }
    }
}
