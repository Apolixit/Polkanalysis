using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Secondary.Pallet.ParaSessionInfo;
using Substats.Polkadot.NetApiExt.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Polkadot.Repository.Storage
{
    public class ParaSessionInfoStorage : IParaSessionInfoStorage
    {
        private readonly SubstrateClientExt _client;
        public ParaSessionInfoStorage(SubstrateClientExt client)
        {
            _client = client;
        }

        public Task<IEnumerable<SubstrateAccount>> AccountKeysAsync(U32 key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Public>> AssignmentKeysUnsafeAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> EarliestStoredSessionAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<SessionInfo> SessionsAsync(U32 key, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
