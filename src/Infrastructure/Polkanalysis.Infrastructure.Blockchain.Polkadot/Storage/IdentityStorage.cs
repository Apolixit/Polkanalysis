using Substrate.NetApi.Model.Types.Base;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NetApi.Model.Types;
using Substrate.NET.Utils;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Storage
{
    public class IdentityStorage : PolkadotAbstractStorage, IIdentityStorage
    {
        private readonly PeopleChainService _peopleChainService;
        public readonly IDelegateSystemChain _delegateSystemChain;
        public IdentityStorage(SubstrateClientExt client,
                               PolkadotMapping mapper,
                               ILogger logger,
                               PeopleChainService peopleChainService,
                               IServiceProvider serviceProvider) : base(client, mapper, logger)
        {
            _peopleChainService = peopleChainService;
            _delegateSystemChain = serviceProvider.GetRequiredService<IDelegateSystemChain>();
        }

        public async Task<Registration?> IdentityOfAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(account, token);
            var version = await GetVersionAsync(token);

            Registration? res = null;
            if (version < 1002000)
            {
                res = Map<IType, Registration>(await _client.IdentityStorage.IdentityOfAsync(accountId32, token));
            }
            else if (version < 1002006)
            {
                var res2 = Map<IType, BaseTuple<Registration, BaseOpt<BaseVec<U8>>>>(await _client.IdentityStorage.IdentityOfAsync(accountId32, token));
                res = res2?.Value[0]?.As<Registration>();
            }
            else
            {
                // Version >= 1002006 && block number from PeopleChain > 0, now PeopleChain is the reference to get identity storage
                if (BlockHash is not null)
                {
                    if(await DelegateToPeopleChainAsync(token) is null)
                    {
                        var res2 = Map<IType, BaseTuple<Registration, BaseOpt<BaseVec<U8>>>>(await _client.IdentityStorage.IdentityOfAsync(accountId32, token));
                        res = res2?.Value[0]?.As<Registration>();
                    }
                }

                return BlockHash is null ?
                await _peopleChainService.Storage.Identity.IdentityOfAsync(account, token) :
                await _peopleChainService.At(BlockHash).Storage.Identity.IdentityOfAsync(account, token);
            }

            return res;
        }

        private async Task<string?> DelegateToPeopleChainAsync(CancellationToken token)
        {
            var peopleChainBlock = await _delegateSystemChain.CurrentBlockForSystemChainAsync(_peopleChainService.AjunaClient,  "PeopleChain", BlockHash!, token);
            if (peopleChainBlock == 0)
            {
                return null;
            }
            else
            {
                BlockHash = (await _delegateSystemChain.GetAssociatedHashFromOtherChainAsync(_peopleChainService.AjunaClient, "PeopleChain", peopleChainBlock, token)).Value;
                return BlockHash;
            }
        }


        public async Task<BaseVec<BaseOpt<RegistrarInfo>>> RegistrarsAsync(CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            if (version < 1002006)
            {
                return Map<IType, BaseVec<BaseOpt<RegistrarInfo>>>(await _client.IdentityStorage.RegistrarsAsync(token));
            }
            else
            {
                if (BlockHash is not null)
                {
                    if (BlockHash is not null)
                    {
                        if (await DelegateToPeopleChainAsync(token) is null)
                        {
                            Map<IType, BaseVec<BaseOpt<RegistrarInfo>>>(await _client.IdentityStorage.RegistrarsAsync(token));
                        }
                    }
                }

                return BlockHash is null ?
                    await _peopleChainService.Storage.Identity.RegistrarsAsync(token) :
                    await _peopleChainService.At(BlockHash).Storage.Identity.RegistrarsAsync(token);
            }

        }

        public async Task<BaseTuple<U128, BaseVec<SubstrateAccount>>> SubsOfAsync(SubstrateAccount account, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            if (version < 1002006)
            {
                var accountId32 = await MapAccoundId32Async(account, token);
                return Map<IType, BaseTuple<U128, BaseVec<SubstrateAccount>>>(await _client.IdentityStorage.SubsOfAsync(accountId32, token));
            }
            else
            {
                if (BlockHash is not null)
                {
                    if (await DelegateToPeopleChainAsync(token) is null)
                    {
                        var accountId32 = await MapAccoundId32Async(account, token);
                        return Map<IType, BaseTuple<U128, BaseVec<SubstrateAccount>>>(await _client.IdentityStorage.SubsOfAsync(accountId32, token));
                    }
                }

                return BlockHash is null ?
                    await _peopleChainService.Storage.Identity.SubsOfAsync(account, token) :
                    await _peopleChainService.At(BlockHash).Storage.Identity.SubsOfAsync(account, token);
            }
        }

        public async Task<BaseTuple<SubstrateAccount, EnumData>> SuperOfAsync(SubstrateAccount account, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            if (version < 1002006)
            {
                var accountId32 = await MapAccoundId32Async(account, token);
                return Map<IType, BaseTuple<SubstrateAccount, EnumData>>(await _client.IdentityStorage.SuperOfAsync(accountId32, token));
            }
            else
            {
                if (BlockHash is not null)
                {
                    if (await DelegateToPeopleChainAsync(token) is null)
                    {
                        var accountId32 = await MapAccoundId32Async(account, token);
                        return Map<IType, BaseTuple<SubstrateAccount, EnumData>>(await _client.IdentityStorage.SuperOfAsync(accountId32, token));
                    }
                }

                return BlockHash is null ?
                    await _peopleChainService.Storage.Identity.SuperOfAsync(account, token) :
                    await _peopleChainService.At(BlockHash).Storage.Identity.SuperOfAsync(account, token);
            }
        }

        public Task<AuthorityProperties> UsernameAuthoritiesAsync(SubstrateAccount account, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<BaseTuple<SubstrateAccount, U32>> PendingUsernamesAsync(BaseVec<U8> key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<SubstrateAccount?> AccountOfUsernameAsync(BaseVec<U8> key, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
