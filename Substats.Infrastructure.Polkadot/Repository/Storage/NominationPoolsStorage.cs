using Ajuna.NetApi.Model.Types.Primitive;
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
    public class NominationPoolsStorage : INominationPoolsStorage
    {
        private readonly SubstrateClientExt _client;
        public NominationPoolsStorage(SubstrateClientExt client)
        {
            _client = client;
        }

        public Task<BondedPoolInner> BondedPoolsAsync(U32 poolId, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> CounterForBondedPoolsAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> CounterForPoolMembersAsync(CancellationToken token)
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

        public Task<RewardPool> RewardPoolsAsync(U32 poolId, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
