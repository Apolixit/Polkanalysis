using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Authorship;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Authorship.Enums;
using Polkanalysis.Infrastructure.Polkadot.Mapper;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec;
using AuthorshipStorageExt = Polkanalysis.Polkadot.NetApiExt.Generated.Storage.AuthorshipStorage;

namespace Polkanalysis.Infrastructure.Polkadot.Repository.Storage
{
    /// <summary>
    /// Authorship storage mapping from Polkadot blockchain to Domain
    /// Mapping is define from <see cref="PolkadotMapping.AuthorshipStorageProfile"/>
    /// </summary>
    public class AuthorshipStorage : MainStorage, IAuthorshipStorage
    {
        public AuthorshipStorage(SubstrateClientExt client, ILogger logger) : base(client, logger) { }

        public async Task<SubstrateAccount> AuthorAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                    Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32,
                    SubstrateAccount>
                (AuthorshipStorageExt.AuthorParams, token);
        }

        public async Task<Bool> DidSetUnclesAsync(CancellationToken token)
        {
            return await GetStorageAsync<Bool>(AuthorshipStorageExt.DidSetUnclesParams, token);
        }

        public async Task<BaseVec<EnumUncleEntryItem>> UnclesAsync(CancellationToken token)
        {
            return await GetStorageAsync<BoundedVecT7, BaseVec<EnumUncleEntryItem>>(AuthorshipStorageExt.UnclesParams, token);

            //var res = await GetStorageAsync<
            //    Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT7,
            //    BaseVec<EnumUncleEntryItem>>
            //    (AuthorshipStorageExt.UnclesParams, token);

            //return SubstrateMapper.Instance.Map<BaseVec<EnumUncleEntryItem>>(res.Value);
        }
    }
}
