using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Secondary.Pallet.Authorship;
using Substats.Infrastructure.Polkadot.Mapper;
using Substats.Polkadot.NetApiExt.Generated;
using AuthorshipStorageExt = Substats.Polkadot.NetApiExt.Generated.Storage.AuthorshipStorage;

namespace Substats.Infrastructure.Polkadot.Repository.Storage
{
    /// <summary>
    /// Authorship storage mapping from Polkadot blockchain to Domain
    /// Mapping is define from <see cref="SubstrateMapper.AuthorshipStorageProfile"/>
    /// </summary>
    public class AuthorshipStorage : MainStorage, IAuthorshipStorage
    {
        public AuthorshipStorage(SubstrateClientExt client, ILogger logger) : base(client, logger) { }

        public async Task<SubstrateAccount> AuthorAsync(CancellationToken token)
        {
            var author = await GetStorageAsync<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>(AuthorshipStorageExt.AuthorParams(), token);

            return SubstrateMapper.Instance.Map<SubstrateAccount>(author);
        }

        public async Task<Bool> DidSetUnclesAsync(CancellationToken token)
        {
            return await GetStorageAsync<Bool>(AuthorshipStorageExt.DidSetUnclesParams(), token);
        }

        public async Task<BaseVec<EnumUncleEntryItem>> UnclesAsync(CancellationToken token)
        {
            var res = await GetStorageAsync<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT7>(AuthorshipStorageExt.UnclesParams(), token);

            return SubstrateMapper.Instance.Map<BaseVec<EnumUncleEntryItem>>(res.Value);
        }
    }
}
