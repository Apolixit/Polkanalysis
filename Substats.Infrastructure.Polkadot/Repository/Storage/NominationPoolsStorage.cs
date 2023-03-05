using Ajuna.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Math;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Secondary.Pallet.NominationPools;
using Substats.Polkadot.NetApiExt.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Polkadot.Repository.Storage
{
    public class NominationPoolsStorage : MainStorage, INominationPoolsStorage
    {
        public NominationPoolsStorage(SubstrateClientExt client, ILogger logger) : base(client, logger) { }

        public Task<BondedPoolInner> BondedPoolsAsync(U32 poolId, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> CounterForBondedPoolsAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> CounterForMetadataAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> CounterForPoolMembersAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> CounterForReversePoolIdLookupAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> CounterForRewardPoolsAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> CounterForSubPoolsStorageAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> LastPoolIdAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> MaxPoolMembersAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> MaxPoolMembersPerPoolAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> MaxPoolsAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<U8>> MetadataAsync(U32 key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U128> MinCreateBondAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U128> MinJoinBondAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<PoolMember> PoolMembersAsync(SubstrateAccount account, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> ReversePoolIdLookupAsync(SubstrateAccount account, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<RewardPool> RewardPoolsAsync(U32 poolId, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<SubPools> SubPoolsStorageAsync(U32 key, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
