using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Polkanalysis.Infrastructure.Blockchain.Mythos.Mapping;
using Polkanalysis.Mythos.NetApiExt.Generated;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Mythos.Storage
{
    public class SystemStorage : MythosAbstractStorage, ISystemStorage
    {
        public SystemStorage(SubstrateClientExt client, MythosMapping mapper, ILogger logger) : base(client, mapper, logger)
        {
        }

        public Task<AccountInfo> AccountAsync(SubstrateAccount account, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryStorage<SubstrateAccount, AccountInfo>> AccountsQueryAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> AllExtrinsicsLenAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Hash> BlockHashAsync(U32 blockId, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<FrameSupportDispatchPerDispatchClassWeight> BlockWeightAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Digest> DigestAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<U32> EventCountAsync(CancellationToken token)
        {
            return await _client.SystemStorage.EventCountAsync(token);
        }

        public async Task<BaseVec<EventRecord>> EventsAsync(CancellationToken token)
        {
            return Map<IType, BaseVec<EventRecord>>(await _client.SystemStorage.EventsAsync(token));
        }

        public Task<BaseVec<BaseTuple<U32, U32>>> EventTopicsAsync(Hash key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<EnumPhase> ExecutionPhaseAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> ExtrinsicCountAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<BaseVec<U8>> ExtrinsicDataAsync(U32 extrinsicId, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<LastRuntimeUpgradeInfo> LastRuntimeUpgradeAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> NumberAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Hash> ParentHashAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task SubscribeNewLastRuntimeUpgradeAsync(Action<LastRuntimeUpgradeInfo> callback, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Bool> UpgradedToTripleRefCountAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Bool> UpgradedToU32RefCountAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
