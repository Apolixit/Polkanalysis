using Substrate.NetApi;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Exception;
using Newtonsoft.Json.Linq;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Domain.Contracts.Dto.Balances;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System;
using Polkanalysis.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Polkanalysis.Domain.Service
{
    public class AccountService : IAccountService
    {
        private readonly ISubstrateService _substrateNodeRepository;
        private readonly SubstrateDbContext _db;
        private readonly ILogger<AccountService> _logger;

        public AccountService(
            ISubstrateService substrateNodeRepository, SubstrateDbContext db, ILogger<AccountService> logger)
        {
            _substrateNodeRepository = substrateNodeRepository;

            if (RequiredStorage.Any(s => s == null))
                throw new PalletNotImplementedException($"{_substrateNodeRepository.BlockchainName} does not implement all storages required by {nameof(IAccountService)}");

            _db = db;
            _logger = logger;
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
            var result = await accountsQuery.Take(20).ExecuteAsync(cancellationToken);

            var accountsDto = new List<AccountLightDto>();
            if (result == null) return accountsDto;

            var chainInfo = await _substrateNodeRepository.Rpc.System.PropertiesAsync(cancellationToken);

            foreach (var (account, accountInfo) in result)
            {
                accountsDto.Add(new AccountLightDto()
                {
                    Address = await GetAccountAddressAsync(account, cancellationToken),
                    Balances = await GetBalancesAsync(account, cancellationToken)
                });
            }

            return accountsDto;
        }

        public Task<BalancesDto> GetBalancesAsync(string accountAddress, CancellationToken cancellationToken)
        {
            EnsureAddressIsValid(accountAddress);
            return GetBalancesAsync(new SubstrateAccount(accountAddress), cancellationToken);
        }

        public async Task<BalancesDto> GetBalancesAsync(SubstrateAccount account, CancellationToken cancellationToken)
        {
            var (locks, reserves, accountInfo, chainInfo, poolMember) = await Helper.WaiterHelper.WaitAndReturnAsync(
                _substrateNodeRepository.Storage.Balances.LocksAsync(account, cancellationToken),
                _substrateNodeRepository.Storage.Balances.ReservesAsync(account, cancellationToken),
                _substrateNodeRepository.Storage.System.AccountAsync(account, cancellationToken),
                _substrateNodeRepository.Rpc.System.PropertiesAsync(cancellationToken),
                _substrateNodeRepository.Storage.NominationPools.PoolMembersAsync(account, cancellationToken)
            );

            var freeAmount = accountInfo.Data.Free.ToDouble(chainInfo.TokenDecimals);
            var stakingAmount = accountInfo.Data.MiscFrozen?.Value.ToDouble(chainInfo.TokenDecimals);
            var lockedAmount = accountInfo.Data.Frozen?.Value.ToDouble(chainInfo.TokenDecimals);
            var othersAmount = accountInfo.Data.Reserved.Value.ToDouble(chainInfo.TokenDecimals);

            var lastUsdValue = await _db.TokenPrices
                .Where(x => x.BlockchainName.ToLower() == _substrateNodeRepository.BlockchainName.ToLower())
                .OrderByDescending(x => x.Date)
                .FirstOrDefaultAsync(cancellationToken);

            var nonTransferable = new List<(CurrencyDto, string)>();
            if (locks != null && locks.Value.Any())
            {
                foreach(var lockBalance in locks.Value)
                {
                    string reason = lockBalance.Id.Display();
                    switch (lockBalance.Id.Display())
                    {
                        case "pyconvot": reason = "Referenda"; break;
                        case "democrac": reason = "Democracy"; break;
                        default:
                            _logger.LogWarning("[{serviceName}] Balances.Locks.Id = {lockBalancesId} is not handled correctly", nameof(AccountService), lockBalance.Id.Display());
                            reason = lockBalance.Id.Display(); 
                            break;
                    }

                    nonTransferable.Add((new CurrencyDto(lockBalance.Amount.ToDouble(chainInfo.TokenDecimals), lastUsdValue?.Price), reason));
                }
            }

            // Nb of token in the pool
            CurrencyDto pool = poolMember is null ? 
                CurrencyDto.Empty : 
                new CurrencyDto(poolMember.Points.Value.ToDouble(chainInfo.TokenDecimals), lastUsdValue?.Price);

            var balances = new BalancesDto()
            {
                Transferable = new CurrencyDto(freeAmount - lockedAmount.GetValueOrDefault(0), lastUsdValue?.Price),
                NonTransferable = nonTransferable,
                Crowdloan = new CurrencyDto(0, lastUsdValue?.Price),
                Pool = pool,
                LastTimeUsdUpdated = lastUsdValue?.Date,
            };

            return balances;
        }

        public Task<AccountDto> GetAccountDetailAsync(string accountAddress, CancellationToken cancellationToken)
        {
            EnsureAddressIsValid(accountAddress);
            return GetAccountDetailAsync(new SubstrateAccount(accountAddress), cancellationToken);
        }

        public async Task<AccountDto> GetAccountDetailAsync(SubstrateAccount account, CancellationToken token)
        {
            var (locks, reserves, identity, identity2, identity3, isAccountPoolMember, accountInfo, chainInfo) = await Helper.WaiterHelper.WaitAndReturnAsync(
                _substrateNodeRepository.Storage.Balances.LocksAsync(account, token),
                _substrateNodeRepository.Storage.Balances.ReservesAsync(account, token),
                _substrateNodeRepository.Storage.Identity.IdentityOfAsync(account, token),
                _substrateNodeRepository.Storage.Identity.SubsOfAsync(account, token),
                _substrateNodeRepository.Storage.Identity.SuperOfAsync(account, token),
                _substrateNodeRepository.Storage.NominationPools.PoolMembersAsync(account, token),
                _substrateNodeRepository.Storage.System.AccountAsync(account, token),
                _substrateNodeRepository.Rpc.System.PropertiesAsync(token)
            );

            var accountNextindex = await _substrateNodeRepository.Rpc.System.AccountNextIndexAsync(account.ToStringAddress((short)chainInfo.Ss58Format)
                , token);
            
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
                {
                    userInformation.Other = string.Join(", ", additionnal);
                }
                userInformation.IdentityLevel = (Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums.EnumJudgement?)identity.Judgements?.Value[0]?.Value[1];
            }

            var accountType = await GetAccountTypeAsync(account, token);

            var accountDto = new AccountDto()
            {
                InformationsDto = userInformation,
                Address = await GetAccountAddressAsync(account, token),
                AccountIndex = accountNextindex,
                Nonce = accountInfo.Nonce.Value,
                Balances = await GetBalancesAsync(account, token),
                AvatarUrl = string.Empty,
                AccountTypes = accountType.ToList()
            };
            return accountDto;
        }

        public Task<UserAddressDto> GetAccountAddressAsync
            (string accountAddress, CancellationToken cancellationToken)
        {
            EnsureAddressIsValid(accountAddress);
            return GetAccountAddressAsync(new SubstrateAccount(accountAddress), cancellationToken);
        }

        public async Task<UserAddressDto> GetAccountAddressAsync(SubstrateAccount account, CancellationToken cancellationToken)
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

            var userAddressDto = new UserAddressDto()
            {
                Name = name,
                Address = blockchainAddress,
                PublicKey = Utils.Bytes2HexString(Utils.GetPublicKeyFrom(account.ToStringAddress()))
            };

            return userAddressDto;
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
