using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Identity;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Identity.Enums;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using IdentityStorageExt = Polkanalysis.Polkadot.NetApiExt.Generated.Storage.IdentityStorage;
using Polkanalysis.Infrastructure.Blockchain.Mapper;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Storage
{
    public class IdentityStorage : MainStorage, IIdentityStorage
    {
        public IdentityStorage(SubstrateClientExt client, ILogger logger) : base(client, logger) { }

        public async Task<Registration> IdentityOfAsync(SubstrateAccount account, CancellationToken token)
        {
            var id = PolkadotMapping.Instance.Map<SubstrateAccount, AccountId32>(account);

            return await GetStorageWithParamsAsync<
                AccountId32,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_identity.types.Registration,
                Registration>
                (id, IdentityStorageExt.IdentityOfParams, token);
        }

        public async Task<BaseVec<BaseOpt<RegistrarInfo>>> RegistrarsAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                BoundedVecT21,
                BaseVec<BaseOpt<RegistrarInfo>>>
                (IdentityStorageExt.RegistrarsParams, token);
        }

        public async Task<SubsOfResult> SubsOfAsync(SubstrateAccount account, CancellationToken token)
        {
            var id = PolkadotMapping.Instance.Map<SubstrateAccount, AccountId32>(account);
            return await GetStorageWithParamsAsync<AccountId32, BaseTuple<U128, BoundedVecT20>, SubsOfResult>
                (id, IdentityStorageExt.SubsOfParams, token);
        }

        public async Task<BaseTuple<SubstrateAccount, EnumData>> SuperOfAsync(SubstrateAccount account, CancellationToken token)
        {
            var id = PolkadotMapping.Instance.Map<SubstrateAccount, AccountId32>(account);

            return await GetStorageWithParamsAsync<AccountId32, BaseTuple<AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_identity.types.EnumData>,
                BaseTuple<SubstrateAccount, EnumData>>
                (id, IdentityStorageExt.SuperOfParams, token);
        }
    }
}
