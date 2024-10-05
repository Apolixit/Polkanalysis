using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain.Mapping;
using Polkanalysis.PeopleChain.NetApiExt.Generated;
using Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.frame_system;
using Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.sp_core.crypto;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.PeopleChain.Storage
{
    internal class SystemStorage : PeopleChainAbstractStorage, ISystemStorage
    {
        public SystemStorage(SubstrateClientExt client, PeopleChainMapping mapper, ILogger logger) : base(client, mapper, logger)
        {
        }

        public async Task<AccountInfo> AccountAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(account, token);
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
            return Map<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.primitive_types.H256Base, Hash>(
                await _client.SystemStorage.BlockHashAsync(blockId, token));
        }

        public async Task<FrameSupportDispatchPerDispatchClassWeight> BlockWeightAsync(CancellationToken token)
        {
            return Map<IType, FrameSupportDispatchPerDispatchClassWeight>(await _client.SystemStorage.BlockWeightAsync(token));
        }

        public async Task<Digest> DigestAsync(CancellationToken token)
        {
            return Map<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.sp_runtime.generic.digest.DigestBase, Digest>(
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
            var hash = await MapWithVersionAsync<Hash, Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.primitive_types.H256Base>(key, token);
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

        public async Task<U32> NumberAsync(CancellationToken token)
        {
            return await _client.SystemStorage.NumberAsync(token);
        }

        public async Task<Hash> ParentHashAsync(CancellationToken token)
        {
            return Map<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.primitive_types.H256Base, Hash>(await _client.SystemStorage.ParentHashAsync(token));
        }

        public async Task SubscribeNewLastRuntimeUpgradeAsync(Action<LastRuntimeUpgradeInfo> callback, CancellationToken token)
        {
            await SubscribeToAsync(RequestGenerator.GetStorage("System", "LastRuntimeUpgrade", Substrate.NetApi.Model.Meta.Storage.Type.Plain), callback, token);
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
