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
using Polkanalysis.Infrastructure.Blockchain.Exceptions;
using Newtonsoft.Json.Linq;

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
                return Map<IType, Registration>(await _client.IdentityStorage.IdentityOfAsync(accountId32, token));
            }
            else if (version < 1002006)
            {
                var res2 = Map<IType, BaseTuple<Registration, BaseOpt<BaseVec<U8>>>>(await _client.IdentityStorage.IdentityOfAsync(accountId32, token));
                return res2?.Value[0]?.As<Registration>();
            }
            else
            {
                // Version >= 1002006 && block number from PeopleChain > 0, now PeopleChain is the reference to get identity storage
                if (BlockHash is not null)
                {
                    var blockHashPeopleChain = await GetBlockHashPeopleChainAsync(token);
                    if (blockHashPeopleChain is null)
                    {
                        var res2 = Map<IType, BaseTuple<Registration, BaseOpt<BaseVec<U8>>>>(await _client.IdentityStorage.IdentityOfAsync(accountId32, token));
                        return res2?.Value[0]?.As<Registration>();
                    }
                    else
                    {
                        return await _peopleChainService.At(blockHashPeopleChain).Storage.Identity.IdentityOfAsync(account, token);
                    }
                } else
                {
                    return await _peopleChainService.Storage.Identity.IdentityOfAsync(account, token);
                }
            }
        }

        /// <summary>
        /// Return the block hash from PeopleChain at the same time of Polkadot block hash
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private async Task<string?> GetBlockHashPeopleChainAsync(CancellationToken token)
        {
            try
            {
                var peopleChainBlock = await _delegateSystemChain.CurrentBlockForSystemChainAsync(_peopleChainService.AjunaClient, "PeopleChain", BlockHash!, token);

                return (await _delegateSystemChain.GetAssociatedHashFromOtherChainAsync(_peopleChainService.AjunaClient, "PeopleChain", peopleChainBlock, token)).Value;
            } catch(SystemParachainDidntExistYetException ex)
            {
                _logger.LogError(ex, "PeopleChain didn't exist yet");
                return null;
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
                    var blockHashPeopleChain = await GetBlockHashPeopleChainAsync(token);
                    if (blockHashPeopleChain is null)
                    {
                        return Map<IType, BaseVec<BaseOpt<RegistrarInfo>>>(await _client.IdentityStorage.RegistrarsAsync(token));
                    }
                    else
                    {
                        return await _peopleChainService.At(blockHashPeopleChain).Storage.Identity.RegistrarsAsync(token);
                    }
                }
                else
                {
                    return await _peopleChainService.Storage.Identity.RegistrarsAsync(token);
                }
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
                    var blockHashPeopleChain = await GetBlockHashPeopleChainAsync(token);
                    if (blockHashPeopleChain is null)
                    {
                        var accountId32 = await MapAccoundId32Async(account, token);
                        return Map<IType, BaseTuple<U128, BaseVec<SubstrateAccount>>>(await _client.IdentityStorage.SubsOfAsync(accountId32, token));
                    }
                    else
                    {
                        return await _peopleChainService.At(blockHashPeopleChain).Storage.Identity.SubsOfAsync(account, token);
                    }
                }
                else
                {
                    return await _peopleChainService.Storage.Identity.SubsOfAsync(account, token);
                }
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
                    var blockHashPeopleChain = await GetBlockHashPeopleChainAsync(token);
                    if (blockHashPeopleChain is null)
                    {
                        var accountId32 = await MapAccoundId32Async(account, token);
                        return Map<IType, BaseTuple<SubstrateAccount, EnumData>>(await _client.IdentityStorage.SuperOfAsync(accountId32, token));
                    }
                    else
                    {
                        return await _peopleChainService.At(blockHashPeopleChain).Storage.Identity.SuperOfAsync(account, token);
                    }
                }
                else
                {
                    return await _peopleChainService.Storage.Identity.SuperOfAsync(account, token);
                }
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
