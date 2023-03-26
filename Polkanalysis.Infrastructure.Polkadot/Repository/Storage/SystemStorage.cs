using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Core.Map;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotRuntime;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.SystemCore;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.SystemCore.Enums;
using Polkanalysis.Infrastructure.Polkadot.Mapper;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_support.dispatch;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.primitive_types;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using SystemStorageExt = Polkanalysis.Polkadot.NetApiExt.Generated.Storage.SystemStorage;

namespace Polkanalysis.Infrastructure.Polkadot.Repository.Storage
{
    public class SystemStorage : MainStorage, ISystemStorage
    {
        public SystemStorage(SubstrateClientExt client, ILogger logger) : base(client, logger) { }

        public async Task<AccountInfo> AccountAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = SubstrateMapper.Instance.Map<SubstrateAccount, AccountId32>(account);

            return await GetStorageWithParamsAsync<
                AccountId32,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.AccountInfo,
                AccountInfo>
                (accountId32, SystemStorageExt.AccountParams, token);

            //var result = await GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.AccountInfo>(SystemStorageExt.AccountParams(SubstrateMapper.Instance.Map<SubstrateAccount, AccountId32>(account)), token);

            //if (result == null) return new AccountInfo();

            //return SubstrateMapper.Instance.Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.AccountInfo, AccountInfo>(result);
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

        public async Task SubscribeEventsAsync(Action<BaseVec<EventRecord>> callback, CancellationToken token)
        {
            await _client.SubscribeStorageKeyAsync(
                SystemStorageExt.EventsParams(),
                async (string subscriptionId, StorageChangeSet storageChangeSet) =>
                {
                    if (storageChangeSet.Changes == null
                    || storageChangeSet.Changes.Length == 0
                    || storageChangeSet.Changes[0].Length < 2)
                    {
                        throw new InvalidOperationException("Couldn't update account information. Please check 'CallBackAccountChange'");
                    }
                    var hexString = storageChangeSet.Changes[0][1];

                    // No data
                    if (string.IsNullOrEmpty(hexString)) return;

                    var blockData = await _client.Chain.GetBlockAsync();

                    try
                    {
                        var coreResult = new BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.EventRecord>();
                        coreResult.Create(hexString);

                        
                        _logger.LogInformation(
                            $"Parsed all the events ({coreResult.Value.Length}) from block {blockData.Block.Header.Number.Value}");

                        var expectedResult = new List<EventRecord>();
                        foreach (var coreEvent in coreResult.Value)
                        {
                            var mappedPhase = SubstrateMapper.Instance.Map<EnumPhase>(coreEvent.Phase);
                            var mappedTopics = SubstrateMapper.Instance.Map<BaseVec<Hash>>(coreEvent.Topics);
                            var maybeMappedEvents = new Maybe<EnumRuntimeEvent>();

                            try
                            {

                                var mappedEvents = SubstrateMapper.Instance.Map<
                            Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime.EnumRuntimeEvent, EnumRuntimeEvent>(coreEvent.Event);

                                maybeMappedEvents = new Maybe<EnumRuntimeEvent>(mappedEvents);
                            }
                            catch (Exception ex)
                            {
                                maybeMappedEvents.Core = coreEvent;
                            }

                            expectedResult.Add(new EventRecord(mappedPhase, maybeMappedEvents, mappedTopics));
                        }

                        callback(new BaseVec<EventRecord>(expectedResult.ToArray()));
                    } catch(Exception ex)
                    {
                        _logger.LogError(
                            $"Fail to parse all the events from block {blockData.Block.Header.Number.Value}", 
                            ex.InnerException);
                    }
                }, token);

            //await SubscribeStorageKeyAsync(
            //    SystemStorageExt.EventsParams(),
            //    callback,
            //    token
            //);
        }

        public async Task<BaseVec<BaseTuple<U32, U32>>> EventTopicsAsync(Hash key, CancellationToken token)
        {
            var param = SubstrateMapper.Instance.Map<Hash, H256>(key);

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

            //var result = await GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.LastRuntimeUpgradeInfo>(SystemStorageExt.LastRuntimeUpgradeParams(), token);

            //if (result == null) return new LastRuntimeUpgradeInfo();

            //return SubstrateMapper.Instance.Map<
            //    Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.EnumPhase, LastRuntimeUpgradeInfo>(result);
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
