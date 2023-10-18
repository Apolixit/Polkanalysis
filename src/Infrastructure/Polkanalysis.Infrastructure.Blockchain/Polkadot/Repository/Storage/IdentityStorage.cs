using Substrate.NetApi.Model.Types.Base;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Substrate.NetApi.Model.Types.Base.Abstraction;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Storage
{
    public class IdentityStorage : MainStorage, IIdentityStorage
    {
        public IdentityStorage(SubstrateClientExt client, ILogger logger) : base(client, logger) { }

        public async Task<Registration> IdentityOfAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(account, token);
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_identity.types.RegistrationBase, Registration>(
                await _client.IdentityStorage.IdentityOfAsync(accountId32, token));
        }

        public async Task<BaseVec<BaseOpt<RegistrarInfo>>> RegistrarsAsync(CancellationToken token)
        {
            return Map<IBaseEnumerable, BaseVec<BaseOpt<RegistrarInfo>>>(
                await _client.IdentityStorage.RegistrarsAsync(token));
        }

        public async Task<SubsOfResult> SubsOfAsync(SubstrateAccount account, CancellationToken token)
        {

            var accountId32 = await MapAccoundId32Async(account, token);
            return Map<IBaseEnumerable, SubsOfResult>(await _client.IdentityStorage.SubsOfAsync(accountId32, token));
        }

        public async Task<BaseTuple<SubstrateAccount, EnumData>> SuperOfAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(account, token);
            return Map<IBaseEnumerable, BaseTuple<SubstrateAccount, EnumData>>(await _client.IdentityStorage.SuperOfAsync(accountId32, token));
        }
    }
}
