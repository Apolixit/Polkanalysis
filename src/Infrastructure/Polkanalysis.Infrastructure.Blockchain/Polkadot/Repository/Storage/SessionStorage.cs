﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Core.Display;
using Polkanalysis.Domain.Contracts.Core.Random;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Session;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using SessionStorageExt = Polkanalysis.Polkadot.NetApiExt.Generated.Storage.SessionStorage;
using Polkanalysis.Infrastructure.Blockchain.Mapper;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Storage
{
    public class SessionStorage : MainStorage, ISessionStorage
    {
        public SessionStorage(SubstrateClientExt client, ILogger logger) : base(client, logger) { }

        public async Task<U32> CurrentIndexAsync(CancellationToken token)
        {
            return await GetStorageAsync<U32>(SessionStorageExt.CurrentIndexParams, token);
        }

        public async Task<BaseVec<U32>> DisabledValidatorsAsync(CancellationToken token)
        {
            return await GetStorageAsync<BaseVec<U32>>(SessionStorageExt.DisabledValidatorsParams, token);
        }

        public async Task<SubstrateAccount> KeyOwnerAsync(BaseTuple<FlexibleNameable, Hexa> key, CancellationToken token)
        {
            var param = PolkadotMapping.Instance.Map<BaseTuple<KeyTypeId, BaseVec<U8>>>(key);
            return await GetStorageWithParamsAsync<
                BaseTuple<KeyTypeId, BaseVec<U8>>, AccountId32, SubstrateAccount>(param, SessionStorageExt.KeyOwnerParams, token);
        }

        public async Task<SessionKeysPolka> NextKeysAsync(SubstrateAccount account, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                AccountId32,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime.SessionKeys,
                SessionKeysPolka>
                (PolkadotMapping.Instance.Map<AccountId32>(account), SessionStorageExt.NextKeysParams, token);
        }

        public async Task<Bool> QueuedChangedAsync(CancellationToken token)
        {
            return await GetStorageAsync<Bool>(SessionStorageExt.QueuedChangedParams, token);
        }

        public async Task<BaseVec<BaseTuple<SubstrateAccount, SessionKeysPolka>>> QueuedKeysAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                BaseVec<BaseTuple<AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime.SessionKeys>>,
                BaseVec<BaseTuple<SubstrateAccount, SessionKeysPolka>>>
                (SessionStorageExt.QueuedKeysParams, token);
        }

        public async Task<BaseVec<SubstrateAccount>> ValidatorsAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                BaseVec<AccountId32>,
                BaseVec<SubstrateAccount>>
                (SessionStorageExt.ValidatorsParams, token);
        }
    }
}
