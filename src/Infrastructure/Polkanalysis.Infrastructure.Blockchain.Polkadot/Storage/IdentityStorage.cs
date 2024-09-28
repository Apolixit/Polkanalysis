using Substrate.NetApi.Model.Types.Base;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NetApi.Model.Types;
using Substrate.NET.Utils;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Storage
{
    public class IdentityStorage : PolkadotAbstractStorage, IIdentityStorage
    {
        public IdentityStorage(SubstrateClientExt client, IBlockchainMapping mapper, ILogger logger) : base(client, mapper, logger) { }

        public async Task<Registration?> IdentityOfAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(account, token);
            var version = await GetVersionAsync(token);

            Registration? res = null;
            if (version < 1002000)
            {
                res = Map<IType, Registration>(await _client.IdentityStorage.IdentityOfAsync(accountId32, token));
            }
            else
            {
                var res2 = Map<IType, BaseTuple<Registration, BaseOpt<BaseVec<U8>>>>(await _client.IdentityStorage.IdentityOfAsync(accountId32, token));
                res = res2?.Value[0]?.As<Registration>();
            }

            return res;
        }

        public async Task<BaseVec<BaseOpt<RegistrarInfo>>> RegistrarsAsync(CancellationToken token)
        {
            return Map<IType, BaseVec<BaseOpt<RegistrarInfo>>>(
                await _client.IdentityStorage.RegistrarsAsync(token));
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
