using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Secondary.Pallet.Authorship;
using Substats.Polkadot.NetApiExt.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Polkadot.Repository.Storage
{
    public class AuthorshipStorage : IAuthorshipStorage
    {
        private readonly SubstrateClientExt _client;
        public AuthorshipStorage(SubstrateClientExt client)
        {
            _client = client;
        }

        public Task<SubstrateAccount> AuthorAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Bool> DidSetUnclesAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EnumUncleEntryItem>> UnclesAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
