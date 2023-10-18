using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.SystemCore;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.SystemCore.Enums;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using SystemStorageExt = Polkanalysis.Polkadot.NetApiExt.Generated.Storage.SystemStorage;
using Polkanalysis.Domain.Contracts.Secondary.Common;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base.Abstraction;
using Substrate.NetApi;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Storage
{
    public class SystemStorage : MainStorage, ISystemStorage
    {
        public SystemStorage(SubstrateClientExt client, ILogger logger) : base(client, logger) { }

        public async Task<AccountInfo> AccountAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(account, token);
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_system.AccountInfoBase, AccountInfo>(
                await _client.SystemStorage.AccountAsync(accountId32, token));
        }

        public QueryStorage<SubstrateAccount, AccountInfo> AccountsQuery()
        {
            //return new QueryStorage<SubstrateAccount, AccountInfo>(
            //    GetAllStorageAsync<AccountId32,
            //    SubstrateAccount,
            //    Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.AccountInfo,
            //    AccountInfo>, "System", "Account");
            throw new InvalidOperationException();
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
            return Map<IBaseEnumerable, BaseVec<EventRecord>>(await _client.SystemStorage.EventsAsync(token));
        }

        public async Task<BaseVec<BaseTuple<U32, U32>>> EventTopicsAsync(Hash key, CancellationToken token)
        {
            var hash = await MapWithVersionAsync<Hash, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.primitive_types.H256Base>(key, token);
            return Map<IBaseEnumerable, BaseVec<BaseTuple<U32, U32>>>(await _client.SystemStorage.EventTopicsAsync(hash, token));
        }

        public async Task<EnumPhase> ExecutionPhaseAsync(CancellationToken token)
        {
            return Map<IBaseEnum, EnumPhase>(await _client.SystemStorage.ExecutionPhaseAsync(token));
        }

        public async Task<U32> ExtrinsicCountAsync(CancellationToken token)
        {
            return await _client.SystemStorage.ExtrinsicCountAsync(token);
        }

        public async Task<BaseVec<U8>> ExtrinsicDataAsync(U32 extrinsicId, CancellationToken token)
        {
            return Map<IBaseEnumerable, BaseVec<U8>>(await _client.SystemStorage.ExtrinsicDataAsync(extrinsicId, token));
        }

        public async Task<LastRuntimeUpgradeInfo> LastRuntimeUpgradeAsync(CancellationToken token)
        {
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_system.LastRuntimeUpgradeInfoBase, LastRuntimeUpgradeInfo>(
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
