using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Core.Display;
using Polkanalysis.Domain.Contracts.Core.Random;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Session;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Storage
{
    public class SessionStorage : PolkadotAbstractStorage, ISessionStorage
    {
        public SessionStorage(SubstrateClientExt client, PolkadotMapping mapper, ILogger logger) : base(client, mapper, logger) { }

        public async Task<U32> CurrentIndexAsync(CancellationToken token)
        {
            return await _client.SessionStorage.CurrentIndexAsync(token);
        }

        public async Task<BaseVec<U32>> DisabledValidatorsAsync(CancellationToken token)
        {
            return Map<IType, BaseVec<U32>>(await _client.SessionStorage.DisabledValidatorsAsync(token));
        }

        public async Task<SubstrateAccount> KeyOwnerAsync(BaseTuple<FlexibleNameable, Hexa> key, CancellationToken token)
        {
            // (Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_core.crypto.KeyTypeId, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>
            var version = await GetVersionAsync(token);
            var input = _mapper.Map(version, key, _client.SessionStorage.KeyOwnerInputType(version));

            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base, SubstrateAccount>(
                await _client.SessionStorage.KeyOwnerAsync(input, token));
        }

        public async Task<SessionKeysPolka> NextKeysAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(account, token);
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime.SessionKeysBase, SessionKeysPolka>(
                await _client.SessionStorage.NextKeysAsync(accountId32, token));
        }

        public async Task<Bool> QueuedChangedAsync(CancellationToken token)
        {
            return await _client.SessionStorage.QueuedChangedAsync(token);
        }

        public async Task<BaseVec<BaseTuple<SubstrateAccount, SessionKeysPolka>>> QueuedKeysAsync(CancellationToken token)
        {
            return Map<IType, BaseVec<BaseTuple<SubstrateAccount, SessionKeysPolka>>>(await _client.SessionStorage.QueuedKeysAsync(token));
        }

        public async Task<BaseVec<SubstrateAccount>> ValidatorsAsync(CancellationToken token)
        {
            return Map<IType, BaseVec<SubstrateAccount>>(await _client.SessionStorage.ValidatorsAsync(token));
        }
    }
}
