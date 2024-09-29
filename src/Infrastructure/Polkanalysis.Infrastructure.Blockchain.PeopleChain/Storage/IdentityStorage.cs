﻿using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums;
using Polkanalysis.PeopleChain.NetApiExt.Generated;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NET.Utils;
using Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.pallet_identity.types;
using Newtonsoft.Json.Linq;
using Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.sp_core.crypto;

namespace Polkanalysis.Infrastructure.Blockchain.PeopleChain.Storage
{
    internal class IdentityStorage : PeopleChainAbstractStorage, IIdentityStorage
    {
        public IdentityStorage(SubstrateClientExt client, IBlockchainMapping mapper, ILogger logger) : base(client, mapper, logger) { }

        public async Task<Registration?> IdentityOfAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(account, token);

            Registration? res = null;
            var res2 = Map<IType, BaseTuple<Registration, BaseOpt<BaseVec<U8>>>>(await _client.IdentityStorage.IdentityOfAsync(accountId32, token));
            res = res2?.Value[0]?.As<Registration>();

            return res;
        }

        public async Task<BaseVec<BaseOpt<RegistrarInfo>>> RegistrarsAsync(CancellationToken token)
        {
            return Map<IType, BaseVec<BaseOpt<RegistrarInfo>>>(await _client.IdentityStorage.RegistrarsAsync(token));
        }

        public async Task<BaseTuple<U128, BaseVec<SubstrateAccount>>> SubsOfAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(account, token);
            return Map<IType, BaseTuple<U128, BaseVec<SubstrateAccount>>>(await _client.IdentityStorage.SubsOfAsync(accountId32, token));
        }

        public async Task<BaseTuple<SubstrateAccount, EnumData>> SuperOfAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(account, token);
            return Map<IType, BaseTuple<SubstrateAccount, EnumData>>(await _client.IdentityStorage.SuperOfAsync(accountId32, token));
        }

        public async Task<AuthorityProperties> UsernameAuthoritiesAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(account, token);
            return Map<AuthorityPropertiesBase, AuthorityProperties>(await _client.IdentityStorage.UsernameAuthoritiesAsync(accountId32, token));
        }

        public async Task<SubstrateAccount?> AccountOfUsernameAsync(BaseVec<U8> key, CancellationToken token)
        {
            return Map<AccountId32Base, SubstrateAccount>(await _client.IdentityStorage.AccountOfUsernameAsync(key, token));
        }

        public async Task<BaseTuple<SubstrateAccount, U32>> PendingUsernamesAsync(BaseVec<U8> key, CancellationToken token)
        {
            return Map<IType, BaseTuple<SubstrateAccount, U32>>(await _client.IdentityStorage.PendingUsernamesAsync(key, token));
        }
    }
}
