using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Secondary.Pallet.Session;
using Substats.Polkadot.NetApiExt.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Polkadot.Repository.Storage
{
    public class SessionStorage : ISessionStorage
    {
        private readonly SubstrateClientExt _client;
        public SessionStorage(SubstrateClientExt client)
        {
            _client = client;
        }

        public Task<U32> CurrentIndexAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<U32>> DisabledValidatorsAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<SubstrateAccount> KeyOwnerAsync((string, byte[]) key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<SessionKeys> NextKeysAsync(SubstrateAccount account, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Bool> QueuedChangedAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IDictionary<SubstrateAccount, SessionKeys>> QueuedKeysAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SubstrateAccount>> ValidatorsAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
