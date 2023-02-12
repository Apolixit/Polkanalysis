using Ajuna.NetApi;
using Substats.AjunaExtension;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Dto.User;
using Substats.Domain.Contracts.Exception;
using Substats.Domain.Contracts.Secondary;
using Substats.Domain.Contracts.Secondary.Contracts;
using Substats.Domain.Contracts.Secondary.Repository;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;

namespace Substats.Domain.Repository
{
    public class PolkadotAccountRepository : IAccountRepository
    {
        private readonly ISubstrateRepository _substrateNodeRepository;

        public PolkadotAccountRepository(ISubstrateRepository substrateNodeRepository)
        {
            _substrateNodeRepository = substrateNodeRepository;

            if (RequiredStorage.Any(s => s == null))
                throw new PalletNotImplementedException($"{_substrateNodeRepository.BlockchainName} does not implement all storages required by {nameof(IAccountRepository)}");
        }

        public IEnumerable<IPalletStorage?> RequiredStorage => new List<IPalletStorage?>() {
            _substrateNodeRepository.Storage.Balances,
            _substrateNodeRepository.Storage.Identity,
            _substrateNodeRepository.Storage.System
        };

        public Task<AccountDto> GetAccountDetailAsync(string accountAddress, CancellationToken cancellationToken)
        {
            if (accountAddress == null) throw new ArgumentNullException($"{nameof(accountAddress)}");

            return GetAccountDetailInternalAsync(new SubstrateAccount(accountAddress), cancellationToken);
        }

        private async Task<AccountDto> GetAccountDetailInternalAsync(SubstrateAccount account, CancellationToken token)
        {
            var locks = await _substrateNodeRepository.Storage.Balances.LocksAsync(account, token);
            var reserves = await _substrateNodeRepository.Storage.Balances.ReservesAsync(account, token);

            var identity = await _substrateNodeRepository.Storage.Identity.IdentityOfAsync(account, token);
            var identity2 = await _substrateNodeRepository.Storage.Identity.SubsOfAsync(account, token);
            var identity3 = await _substrateNodeRepository.Storage.Identity.SuperOfAsync(account, token);

            var isAccountPoolMember = await _substrateNodeRepository.Storage.NominationPools.PoolMembersAsync(account, token);

            var accountInfo = await _substrateNodeRepository.Storage.System.AccountAsync(account, token);
            var accountNextindex = await _substrateNodeRepository.Rpc.System.AccountNextIndexAsync(account.Address
                , token);
            var chainInfo = await _substrateNodeRepository.Rpc.System.PropertiesAsync(token);
            if (chainInfo == null)
                throw new InvalidOperationException($"{chainInfo}");

            //_substrateNodeRepository.Client.ParasStorage.
            var freeAmount = accountInfo.Data.Free.ToDouble(chainInfo.TokenDecimals);
            var otherAmount = (accountInfo.Data.MiscFrozen.Value + accountInfo.Data.Reserved.Value).ToDouble(chainInfo.TokenDecimals);

            var userInformation = new UserInformationsDto();
            if (identity != null)
            {
                userInformation.Name = identity.Info.Display;
                userInformation.Website = identity.Info.Web;
                userInformation.Email = identity.Info.Email;
                userInformation.Twitter = identity.Info.Twitter;
                userInformation.Legal = identity.Info.Legal;
                userInformation.Matrix = identity.Info.Riot;
                userInformation.Image = identity.Info.Image;
                userInformation.Other = identity.Info.Additional;
            }


            var accountDto = new AccountDto()
            {
                InformationsDto = userInformation,
                Address = new AddressDto()
                {
                    Address = account.Address
                },
                AccountIndex = accountNextindex,
                Nonce = accountInfo.Nonce.Value,
                Balances = new Contracts.Dto.Balances.BalancesDto()
                {
                    Transferable = freeAmount,
                    Stacking = 0, // TODO mapping
                    Others = otherAmount
                }
            };
            return accountDto;
        }

        public Task<UserAddressDto> GetAccountIdentityAsync
            (string accountAddress, CancellationToken cancellationToken)
        {
            if (accountAddress == null) throw new ArgumentNullException($"{nameof(accountAddress)}");

            return GetAccountIdentityInternalAsync(accountAddress, cancellationToken);
        }

        public async Task<UserAddressDto> GetAccountIdentityAsync(SubstrateAccount account, CancellationToken cancellationToken)
        {
            var chainInfo = await _substrateNodeRepository.Rpc.System.PropertiesAsync(cancellationToken);
            var identity = await _substrateNodeRepository.Storage.Identity.IdentityOfAsync(account, cancellationToken);
            var blockchainAddress = account.ToStringAddress((short)chainInfo.Ss58Format);

            // Default = it's the basic address
            string name = blockchainAddress;
            if (identity != null)
            {
                // If we got a legal identity set, display it
                if (!string.IsNullOrEmpty(identity.Info.Legal))
                {
                    name = identity.Info.Legal;
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
            return await GetAccountIdentityAsync(new SubstrateAccount(accountAddress), cancellationToken);
        }


    }
}
