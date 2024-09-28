using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums;
using Polkanalysis.PeopleChain.NetApiExt.Generated;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NET.Utils;

namespace Polkanalysis.Infrastructure.Blockchain.PeopleChain.Storage
{
    internal class IdentityStorage : PeopleChainAbstractStorage, IIdentityStorage
    {
        public IdentityStorage(SubstrateClientExt client, IBlockchainMapping mapper, ILogger logger) : base(client, mapper, logger) { }

        public async Task<Registration?> IdentityOfAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(account, token);
            var version = await GetVersionAsync(token);

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
    }
}
