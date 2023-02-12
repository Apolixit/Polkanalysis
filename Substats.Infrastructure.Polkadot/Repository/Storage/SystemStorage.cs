using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Secondary.Pallet.System;
using Substats.Polkadot.NetApiExt.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Polkadot.Repository.Storage
{
    public class SystemStorage : ISystemStorage
    {
        private readonly SubstrateClientExt _client;
        public SystemStorage(SubstrateClientExt client)
        {
            _client = client;
        }

        public Task<AccountInfo> AccountAsync(SubstrateAccount account, CancellationToken token)
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

        public Task<U32> EventCountAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EventRecord>> EventsAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<(U32, U32)>> EventTopicsAsync(Hash key, CancellationToken token)
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

        public Task<byte[]> ExtrinsicDataAsync(U32 extrinsicId, CancellationToken token)
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
