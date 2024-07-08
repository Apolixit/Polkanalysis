using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_system;
using System;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Storage
{
    public class SystemStorage : MainStorage, ISystemStorage
    {
        public SystemStorage(SubstrateClientExt client, IBlockchainMapping mapper, ILogger logger) : base(client, mapper, logger) { }

        public async Task<AccountInfo> AccountAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(account, token);

            //if(accountId32 is null)
            //{
            //    accountId32 = _mapper.MapWithVersion<SubstrateAccount, AccountId32Base>(9110, account);
            //}
            //var parameters = RequestGenerator.GetStorage("System", "Account", Substrate.NetApi.Model.Meta.Storage.Type.Map, [Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat], [accountId32]);

            ////Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.frame_system.AccountInfo;
            ////var res = await _client.GetStorageAsync<AccountInfo>(parameters, BlockHash, token);
            //string text = await _client.InvokeAsync<string>("state_getStorage", new object[2] { parameters, BlockHash! }, token);
            //var res = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.frame_system.AccountInfo();
            //res.Create(text);

            //var res2 = _mapper.Map<AccountInfoBase, AccountInfo>(res);
            //return res2;
            return Map<AccountInfoBase, AccountInfo>(
                await _client.SystemStorage.AccountAsync(accountId32, token));
        }

        public async Task<IQueryStorage<SubstrateAccount, AccountInfo>> AccountsQueryAsync(CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            var sourceKeyType = AccountId32Base.TypeByVersion(version);
            var storageKeyType = AccountInfoBase.TypeByVersion(version);

            var storageFunction = new QueryStorageFunction("System", "Account", sourceKeyType, storageKeyType, 32);

            return new QueryStorage<SubstrateAccount, AccountInfo>(
                GetAllStorageAsync<SubstrateAccount, AccountInfo>, storageFunction);
        }

        public async Task<U32> AllExtrinsicsLenAsync(CancellationToken token)
        {
            return await _client.SystemStorage.AllExtrinsicsLenAsync(token);
        }

        public async Task<Hash> BlockHashAsync(U32 blockId, CancellationToken token)
        {
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.primitive_types.H256Base, Hash>(
                await _client.SystemStorage.BlockHashAsync(blockId, token));
        }

        public async Task<FrameSupportDispatchPerDispatchClassWeight> BlockWeightAsync(CancellationToken token)
        {
            return Map<IType, FrameSupportDispatchPerDispatchClassWeight>(await _client.SystemStorage.BlockWeightAsync(token));
        }

        public async Task<Digest> DigestAsync(CancellationToken token)
        {
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_runtime.generic.digest.DigestBase, Digest>(
                await _client.SystemStorage.DigestAsync(token));
        }

        public async Task<U32> EventCountAsync(CancellationToken token)
        {
            return await _client.SystemStorage.EventCountAsync(token);
        }

        public async Task<BaseVec<EventRecord>> EventsAsync(CancellationToken token)
        {
            return Map<IType, BaseVec<EventRecord>>(await _client.SystemStorage.EventsAsync(token));
        }

        public async Task<BaseVec<BaseTuple<U32, U32>>> EventTopicsAsync(Hash key, CancellationToken token)
        {
            var hash = await MapWithVersionAsync<Hash, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.primitive_types.H256Base>(key, token);
            return Map<IType, BaseVec<BaseTuple<U32, U32>>>(await _client.SystemStorage.EventTopicsAsync(hash, token));
        }

        public async Task<EnumPhase> ExecutionPhaseAsync(CancellationToken token)
        {
            return Map<IType, EnumPhase>(await _client.SystemStorage.ExecutionPhaseAsync(token));
        }

        public async Task<U32> ExtrinsicCountAsync(CancellationToken token)
        {
            return await _client.SystemStorage.ExtrinsicCountAsync(token);
        }

        public async Task<BaseVec<U8>> ExtrinsicDataAsync(U32 extrinsicId, CancellationToken token)
        {
            return Map<IType, BaseVec<U8>>(await _client.SystemStorage.ExtrinsicDataAsync(extrinsicId, token));
        }

        public async Task<LastRuntimeUpgradeInfo> LastRuntimeUpgradeAsync(CancellationToken token)
        {
            return Map<LastRuntimeUpgradeInfoBase, LastRuntimeUpgradeInfo>(
                await _client.SystemStorage.LastRuntimeUpgradeAsync(token));
        }

        public async Task SubscribeNewLastRuntimeUpgradeAsync(Action<LastRuntimeUpgradeInfo> callback, CancellationToken token)
        {
            await SubscribeToAsync(RequestGenerator.GetStorage("System", "LastRuntimeUpgrade", Substrate.NetApi.Model.Meta.Storage.Type.Plain), callback, token);
        }

        public async Task<U32> NumberAsync(CancellationToken token)
        {
            return await _client.SystemStorage.NumberAsync(token);
        }

        public async Task<Hash> ParentHashAsync(CancellationToken token)
        {
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.primitive_types.H256Base, Hash>(await _client.SystemStorage.ParentHashAsync(token));

        }

        public async Task<Bool> UpgradedToTripleRefCountAsync(CancellationToken token)
        {
            return await _client.SystemStorage.UpgradedToTripleRefCountAsync(token);
        }

        public async Task<Bool> UpgradedToU32RefCountAsync(CancellationToken token)
        {
            return await _client.SystemStorage.UpgradedToU32RefCountAsync(token);
        }
    }
}
