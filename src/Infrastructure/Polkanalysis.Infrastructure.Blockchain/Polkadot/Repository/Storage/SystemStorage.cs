using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Core.Map;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotRuntime;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.SystemCore;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.SystemCore.Enums;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_support.dispatch;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.primitive_types;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using SystemStorageExt = Polkanalysis.Polkadot.NetApiExt.Generated.Storage.SystemStorage;
using Polkanalysis.Domain.Contracts.Secondary.Common;
using Polkanalysis.Infrastructure.Blockchain.Mapper;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Storage
{
    public class SystemStorage : MainStorage, ISystemStorage
    {
        public SystemStorage(SubstrateClientExt client, ILogger logger) : base(client, logger) { }

        public async Task<AccountInfo> AccountAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = PolkadotMapping.Instance.Map<SubstrateAccount, AccountId32>(account);

            return await GetStorageWithParamsAsync<
                AccountId32,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.AccountInfo,
                AccountInfo>
                (accountId32, SystemStorageExt.AccountParams, token);
        }

        public QueryStorage<SubstrateAccount, AccountInfo> AccountsQuery()
        {
            return new QueryStorage<SubstrateAccount, AccountInfo>(
                GetAllStorageAsync<AccountId32,
                SubstrateAccount,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.AccountInfo,
                AccountInfo>, "System", "Account");
        }

        public async Task<U32> AllExtrinsicsLenAsync(CancellationToken token)
        {
            return await GetStorageAsync<U32>(SystemStorageExt.AllExtrinsicsLenParams, token);
        }

        public async Task<Hash> BlockHashAsync(U32 blockId, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<U32, H256, Hash>(blockId, SystemStorageExt.BlockHashParams, token);

            //var result = await GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.primitive_types.H256>(SystemStorageExt.BlockHashParams(blockId), token);

            //if (result == null) return new Hash();

            //return SubstrateMapper.Instance.Map<
            //    Polkanalysis.Polkadot.NetApiExt.Generated.Model.primitive_types.H256, Hash>(result);
        }

        public async Task<FrameSupportDispatchPerDispatchClassWeight> BlockWeightAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                PerDispatchClassT1,
                FrameSupportDispatchPerDispatchClassWeight>(SystemStorageExt.BlockWeightParams, token);

            //var result = await GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_support.dispatch.PerDispatchClassT1>(SystemStorageExt.BlockWeightParams(), token);

            //if (result == null) return new FrameSupportDispatchPerDispatchClassWeight();

            //return SubstrateMapper.Instance.Map<
            //    Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_support.dispatch.PerDispatchClassT1, FrameSupportDispatchPerDispatchClassWeight>(result);
        }

        public async Task<Domain.Contracts.Secondary.Pallet.SystemCore.Digest> DigestAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_runtime.generic.digest.Digest, Domain.Contracts.Secondary.Pallet.SystemCore.Digest>(SystemStorageExt.DigestParams, token);

            //var result = await GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_runtime.generic.digest.Digest>(SystemStorageExt.DigestParams(), token);

            //if (result == null) return new Digest();

            //return SubstrateMapper.Instance.Map<
            //    Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_runtime.generic.digest.Digest, Digest>(result);
        }

        public async Task<U32> EventCountAsync(CancellationToken token)
        {
            return await GetStorageAsync<U32>(SystemStorageExt.EventCountParams, token);
        }

        public async Task<BaseVec<EventRecord>> EventsAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.EventRecord>,
                BaseVec<EventRecord>>
                (SystemStorageExt.EventsParams, token);
        }

        public async Task<BaseVec<BaseTuple<U32, U32>>> EventTopicsAsync(Hash key, CancellationToken token)
        {
            var param = PolkadotMapping.Instance.Map<Hash, H256>(key);

            return await GetStorageWithParamsAsync<
                H256,
                BaseVec<BaseTuple<U32, U32>>,
                BaseVec<BaseTuple<U32, U32>>>
                (param, SystemStorageExt.EventTopicsParams, token);
        }

        public async Task<EnumPhase> ExecutionPhaseAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.EnumPhase, EnumPhase>(SystemStorageExt.ExecutionPhaseParams, token);

            //var result = await GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.EnumPhase>(SystemStorageExt.ExecutionPhaseParams(), token);

            //if (result == null) return new EnumPhase();

            //return SubstrateMapper.Instance.Map<
            //    Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.EnumPhase, EnumPhase>(result);
        }

        public async Task<U32> ExtrinsicCountAsync(CancellationToken token)
        {
            return await GetStorageAsync<U32>(SystemStorageExt.ExtrinsicCountParams, token);
        }

        public async Task<BaseVec<U8>> ExtrinsicDataAsync(U32 extrinsicId, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                U32,
                BaseVec<U8>,
                BaseVec<U8>>
                (extrinsicId, SystemStorageExt.ExtrinsicDataParams, token);

            //return await GetStorageAsync<BaseVec<U8>>(
            //    SystemStorageExt.ExtrinsicDataParams(extrinsicId), token) ?? new BaseVec<U8>();
        }

        public async Task<LastRuntimeUpgradeInfo> LastRuntimeUpgradeAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.LastRuntimeUpgradeInfo, LastRuntimeUpgradeInfo>(SystemStorageExt.LastRuntimeUpgradeParams, token);
        }

        public async Task SubscribeNewLastRuntimeUpgradeAsync(Action<LastRuntimeUpgradeInfo> callback, CancellationToken token)
        {
            await SubscribeToAsync(SystemStorageExt.LastRuntimeUpgradeParams(), callback, token);
        }

        public async Task<U32> NumberAsync(CancellationToken token)
        {
            return await GetStorageAsync<U32>(SystemStorageExt.NumberParams, token);
        }

        public async Task<Hash> ParentHashAsync(CancellationToken token)
        {
            return await GetStorageAsync<H256, Hash>(SystemStorageExt.ParentHashParams, token);
        }

        public async Task<Bool> UpgradedToTripleRefCountAsync(CancellationToken token)
        {
            return await GetStorageAsync<Bool>(SystemStorageExt.UpgradedToTripleRefCountParams, token);
        }

        public async Task<Bool> UpgradedToU32RefCountAsync(CancellationToken token)
        {
            return await GetStorageAsync<Bool>(SystemStorageExt.UpgradedToU32RefCountParams, token);
        }
    }
}
