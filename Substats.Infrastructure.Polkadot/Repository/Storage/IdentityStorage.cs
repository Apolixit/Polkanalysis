using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Secondary.Pallet.Identity;
using Substats.Polkadot.NetApiExt.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Polkadot.Repository.Storage
{
    public class IdentityStorage : IIdentityStorage
    {
        private readonly SubstrateClientExt _client;
        public IdentityStorage(SubstrateClientExt client)
        {
            _client = client;
        }

        public Task<Registration> IdentityOfAsync(SubstrateAccount account, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<RegistarInfo> RegistrarsAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<SubsOfResult?> SubsOfAsync(SubstrateAccount account, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<SuperOfResult?> SuperOfAsync(SubstrateAccount account, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
