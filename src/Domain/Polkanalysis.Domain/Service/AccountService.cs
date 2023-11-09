using Substrate.NetApi;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Exception;
using Newtonsoft.Json.Linq;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;

namespace Polkanalysis.Domain.Service
{
    public class AccountService : IAccountService
    {
        private readonly ISubstrateService _substrateNodeRepository;

        public AccountService(
            ISubstrateService substrateNodeRepository)
        {
            _substrateNodeRepository = substrateNodeRepository;

            if (RequiredStorage.Any(s => s == null))
                throw new PalletNotImplementedException($"{_substrateNodeRepository.BlockchainName} does not implement all storages required by {nameof(IAccountService)}");
        }

        public IEnumerable<IPalletStorage?> RequiredStorage => new List<IPalletStorage?>() {
            _substrateNodeRepository.Storage.Balances,
            _substrateNodeRepository.Storage.Identity,
            _substrateNodeRepository.Storage.System
        };

        private void EnsureAddressIsValid(string address)
        {
            if (address == null || string.IsNullOrEmpty(address))
                throw new ArgumentNullException($"{nameof(address)}");

            if (!_substrateNodeRepository.IsValidAccountAddress(address))
                throw new AddressException($"{address} is invalid");
        }

        public async Task<IEnumerable<AccountLightDto>> GetAccountsAsync(CancellationToken cancellationToken)
        {
            var accountsQuery = await _substrateNodeRepository.Storage.System.AccountsQueryAsync(cancellationToken);
            var result = await accountsQuery.Take(100).ExecuteAsync(cancellationToken);

            var accountsDto = new List<AccountLightDto>();
            if (result == null) return accountsDto;

            var chainInfo = await _substrateNodeRepository.Rpc.System.PropertiesAsync(cancellationToken);

            foreach (var (accountAddress, accountInfo) in result)
            {
                var freeAmount = accountInfo.Data.Free.ToDouble(chainInfo.TokenDecimals);
                var stakingAmount = accountInfo.Data.MiscFrozen.Value.ToDouble(chainInfo.TokenDecimals);
                var othersAmount = accountInfo.Data.Reserved.Value.ToDouble(chainInfo.TokenDecimals);
                accountsDto.Add(new AccountLightDto()
                {
                    Address = await GetAccountIdentityAsync(accountAddress, cancellationToken),
                    Balances = new Contracts.Dto.Balances.BalancesDto()
                    {
                        Transferable = freeAmount,
                        Stacking = stakingAmount,
                        Others = othersAmount
                    }
                });
            }

            return accountsDto;
        }

        public Task<AccountDto> GetAccountDetailAsync(string accountAddress, CancellationToken cancellationToken)
        {
            EnsureAddressIsValid(accountAddress);
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
            var accountNextindex = await _substrateNodeRepository.Rpc.System.AccountNextIndexAsync(account.ToStringAddress()
                , token);
            var chainInfo = await _substrateNodeRepository.Rpc.System.PropertiesAsync(token);

            //_substrateNodeRepository.Client.ParasStorage.
            var freeAmount = accountInfo.Data.Free.ToDouble(chainInfo.TokenDecimals);
            var stakingAmount = accountInfo.Data.MiscFrozen.Value.ToDouble(chainInfo.TokenDecimals);
            var othersAmount = accountInfo.Data.Reserved.Value.ToDouble(chainInfo.TokenDecimals);

            //double lockAmount = 0;
            //double stackingAmount = 0;
            //if (locks != null && locks.Value.Any())
            //{
            //    // Misc == democracy
            //    lockAmount = locks.Value
            //        .Where(x => x.Reasons.Value == Contracts.Secondary.Pallet.Balances.Enums.Reasons.Misc)
            //        .Sum(x => x.Amount.ToDouble(chainInfo.TokenDecimals));

            //    stackingAmount = locks.Value
            //        .Where(x => x.Reasons.Value == Contracts.Secondary.Pallet.Balances.Enums.Reasons.All)
            //        .Sum(x => x.Amount.ToDouble(chainInfo.TokenDecimals));
            //}


            // Stacking = lock + reason = ALL
            // other = lock + reason = misc

            var userInformation = new UserInformationsDto();
            if (identity != null && identity.Info != null)
            {
                userInformation.Name = identity.Info.Display.ToHuman();
                userInformation.Website = identity.Info.Web.ToHuman();
                userInformation.Email = identity.Info.Email.ToHuman();
                userInformation.Twitter = identity.Info.Twitter.ToHuman();
                userInformation.Legal = identity.Info.Legal.ToHuman();
                userInformation.Matrix = identity.Info.Riot.ToHuman();
                userInformation.Image = identity.Info.Image.ToHuman();

                var additionnal = identity.Info.Additional?.Value?.Select(x => ((Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums.EnumData)x.Value[1])?.ToHuman());
                if (additionnal != null)
                    await GetAccountIdentityAsync(account, token);
                {
                    userInformation.Other = string.Join(", ", additionnal);
                }
                userInformation.IdentityLevel = (Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums.EnumJudgement?)identity.Judgements?.Value[0]?.Value[1];
            }

            var accountType = await GetAccountTypeAsync(account, token);

            var accountDto = new AccountDto()
            {
                InformationsDto = userInformation,
                Address = await GetAccountIdentityAsync(account, token),
                AccountIndex = accountNextindex,
                Nonce = accountInfo.Nonce.Value,
                Balances = new Contracts.Dto.Balances.BalancesDto()
                {
                    Transferable = freeAmount,
                    Stacking = stakingAmount,
                    Others = othersAmount
                },
                AvatarUrl = string.Empty,
                AccountTypes = accountType
            };
            return accountDto;
        }

        public Task<UserAddressDto> GetAccountIdentityAsync
            (string accountAddress, CancellationToken cancellationToken)
        {
            EnsureAddressIsValid(accountAddress);
            return GetAccountIdentityAsync(new SubstrateAccount(accountAddress), cancellationToken);
        }

        public async Task<UserAddressDto> GetAccountIdentityAsync(SubstrateAccount account, CancellationToken cancellationToken)
        {
            var chainInfo = await _substrateNodeRepository.Rpc.System.PropertiesAsync(cancellationToken);
            var identity = await _substrateNodeRepository.Storage.Identity.IdentityOfAsync(account, cancellationToken);
            var blockchainAddress = account.ToStringAddress((short)chainInfo.Ss58Format);

            // Default = it's the basic address
            string name = blockchainAddress;
            if (identity != null && identity.Info != null)
            {
                var identityDisplay = identity.Info.Display.ToHuman();
                // If we got a legal identity set, display it
                if (!string.IsNullOrEmpty(identityDisplay))
                {
                    name = identityDisplay;
                }
            }

            return new UserAddressDto()
            {
                Name = name,
                Address = blockchainAddress,
                PublicKey = Utils.Bytes2HexString(Utils.GetPublicKeyFrom(account.ToStringAddress()))
            };
        }

        public Task<IEnumerable<AccountType>> GetAccountTypeAsync(string accountAddress, CancellationToken cancellationToken)
        {
            EnsureAddressIsValid(accountAddress);
            return GetAccountTypeAsync(new SubstrateAccount(accountAddress), cancellationToken);
        }

        public async Task<IEnumerable<AccountType>> GetAccountTypeAsync(SubstrateAccount account, CancellationToken cancellationToken)
        {
            var accountTypes = new List<AccountType>();

            var validatorTask = _substrateNodeRepository.Storage.Session.NextKeysAsync(account, cancellationToken);
            var nominatorTask = _substrateNodeRepository.Storage.Staking.NominatorsAsync(account, cancellationToken);
            var identityTask = _substrateNodeRepository.Storage.Identity.IdentityOfAsync(account, cancellationToken);
            var poolMemberTask = _substrateNodeRepository.Storage.NominationPools.PoolMembersAsync(account, cancellationToken);

            await Task.WhenAll(new Task[] { validatorTask, nominatorTask, identityTask, poolMemberTask });

            if (await validatorTask != null)
                accountTypes.Add(AccountType.Validator);

            if (await nominatorTask != null)
                accountTypes.Add(AccountType.Nominator);

            if (await identityTask != null)
                accountTypes.Add(AccountType.OnChainIdentity);

            if (await poolMemberTask != null)
                accountTypes.Add(AccountType.PoolMember);

            // Import technical comitee storage ?
            return accountTypes;
        }
    }
}
