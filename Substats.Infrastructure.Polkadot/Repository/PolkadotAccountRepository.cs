using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.AjunaExtension;
using Substats.Domain.Contracts.Dto.User;
using Substats.Domain.Contracts.Secondary;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.DirectAccess.Repository
{
    public class PolkadotAccountRepository : IAccountRepository
    {
        private readonly ISubstrateRepository _substrateNodeRepository;

        public PolkadotAccountRepository(ISubstrateRepository substrateNodeRepository)
        {
            _substrateNodeRepository = substrateNodeRepository;
        }

        public async Task<AccountDto> GetAccountDetailAsync(string accountAddress, CancellationToken cancellationToken)
        {
            if (accountAddress == null) throw new ArgumentNullException($"{nameof(accountAddress)}");

            var accountId32 = new AccountId32();
            accountId32.Create(Utils.GetPublicKeyFrom(accountAddress));

            var res1 = await _substrateNodeRepository.Client.BalancesStorage.Locks(accountId32, cancellationToken);

            var res2 = await _substrateNodeRepository.Client.BalancesStorage.Reserves(accountId32, cancellationToken);

            //var res6 = await _substrateNodeRepository.Client.SystemStorage.Digest(cancellationToken);

            
            
            
            var identity = await _substrateNodeRepository.Client.IdentityStorage.IdentityOf(accountId32, cancellationToken);
            var identity2 = await _substrateNodeRepository.Client.IdentityStorage.SubsOf(accountId32, cancellationToken);
            var identity3 = await _substrateNodeRepository.Client.IdentityStorage.SuperOf(accountId32, cancellationToken);

            var isAccountPoolMember = await _substrateNodeRepository.Client.NominationPoolsStorage.PoolMembers(accountId32,   cancellationToken);

            var accountInfo = await _substrateNodeRepository.Client.SystemStorage.Account(accountId32, cancellationToken);
            var accountNextindex = await _substrateNodeRepository.Client.Core.System.AccountNextIndexAsync(accountAddress, cancellationToken);
            var chainInfo = await _substrateNodeRepository.Client.Core.System.PropertiesAsync(cancellationToken);
            if (chainInfo == null)
                throw new InvalidOperationException($"{chainInfo}");


            
            //_substrateNodeRepository.Client.ParasStorage.
            var freeAmount = accountInfo.Data.Free.ToDouble(chainInfo.TokenDecimals);
            var otherAmount = (accountInfo.Data.MiscFrozen.Value + accountInfo.Data.Reserved.Value).ToDouble(chainInfo.TokenDecimals);

            var userInformation = new UserInformationsDto();
            if(identity != null)
            {
                userInformation.Name = Encoding.Default.GetString(identity.Info.Display.Value2.Encode());
                userInformation.Website = Encoding.Default.GetString(identity.Info.Web.Value2.Encode());
                userInformation.Email = Encoding.Default.GetString(identity.Info.Email.Value2.Encode());
                userInformation.Twitter = Encoding.Default.GetString(identity.Info.Twitter.Value2.Encode());
                userInformation.Legal = Encoding.Default.GetString(identity.Info.Legal.Value2.Encode());
                userInformation.Matrix = Encoding.Default.GetString(identity.Info.Riot.Value2.Encode());
                userInformation.Image = Encoding.Default.GetString(identity.Info.Image.Value2.Encode());
                userInformation.Other = string.Join(", ", string.Join(", ", identity.Info.Additional.Value.GetValueArray().Select(x => x.ToString())));
            }


            var account = new AccountDto()
            {
                InformationsDto = userInformation,
                Address = new AddressDto()
                {
                    Address = accountAddress
                },
                AccountIndex = accountNextindex,
                Nonce = accountInfo.Nonce.Value,
                Balances = new Domain.Contracts.Dto.Balances.BalancesDto()
                {
                    Transferable = freeAmount,
                    Stacking = 0, // TODO mapping
                    Others = otherAmount
                }
            };
            return account;
        }

        public Task<UserAddressDto> GetAccountIdentityAsync
            (string accountAddress, CancellationToken cancellationToken)
        {
            if (accountAddress == null) throw new ArgumentNullException($"{nameof(accountAddress)}");

            return GetAccountIdentityInternalAsync(accountAddress, cancellationToken);
        }

        public async Task<UserAddressDto> GetAccountIdentityAsync(AccountId32 account, CancellationToken cancellationToken)
        {
            var chainInfo = await _substrateNodeRepository.Client.Core.System.PropertiesAsync(cancellationToken);
            var identity = await _substrateNodeRepository.Client.IdentityStorage.IdentityOf(account, cancellationToken);
            var blockchainAddress = account.ToStringAddress((short)chainInfo.Ss58Format);

            // Default = it's the basic address
            string name = blockchainAddress;
            if(identity != null)
            {
                var legalInfo = identity.Info.Legal.GetValue2();

                // If we got a legal identity set, display it
                if(legalInfo != null) {
                    name = legalInfo.Encode().ToHuman();
                }
            }

            return new UserAddressDto()
            {
                Name = name,
                Address = blockchainAddress,
            };
        }

        private async Task<UserAddressDto> GetAccountIdentityInternalAsync(string accountAddress, CancellationToken cancellationToken)
        {
            var accountId32 = new AccountId32();
            accountId32.Create(Utils.GetPublicKeyFrom(accountAddress));

            return await GetAccountIdentityAsync(accountId32, cancellationToken);
        }

        
    }
}
