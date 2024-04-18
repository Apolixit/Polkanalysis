using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Authorship;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Authorship.Enums;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Substrate.NetApi.Model.Types;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Storage
{
    /// <summary>
    /// Authorship storage mapping from Polkadot blockchain to Domain
    /// Mapping is define from <see cref="PolkadotMapping.AuthorshipStorageProfile"/>
    /// </summary>
    public class AuthorshipStorage : MainStorage, IAuthorshipStorage
    {
        public AuthorshipStorage(SubstrateClientExt client, IBlockchainMapping mapper, ILogger logger) : base(client, mapper, logger) { }

        public async Task<SubstrateAccount> AuthorAsync(CancellationToken token)
        {
            return Map<AccountId32Base, SubstrateAccount>(await _client.AuthorshipStorage.AuthorAsync(token));
        }

        public async Task<Bool> DidSetUnclesAsync(CancellationToken token)
        {
            return await _client.AuthorshipStorage.DidSetUnclesAsync(token);
        }

        public async Task<BaseVec<EnumUncleEntryItem>> UnclesAsync(CancellationToken token)
        {
            return Map<IType, BaseVec<EnumUncleEntryItem>>(await _client.AuthorshipStorage.UnclesAsync(token));
        }
    }
}
