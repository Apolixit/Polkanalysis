using Substrate.NetApi;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Exception;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Domain.Contracts.Dto.Balances;
using Polkanalysis.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Common;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using Polkanalysis.Domain.Internal;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Serilog.Debugging;
using Microsoft.Extensions.Caching.Hybrid;

namespace Polkanalysis.Domain.Service
{
    public class AccountService : IAccountService
    {
        private readonly ISubstrateService _substrateNodeRepository;
        private readonly SubstrateDbContext _db;
        private readonly ILogger<AccountService> _logger;
        protected readonly HybridCache _cache;

        public AccountService(
            ISubstrateService substrateNodeRepository, SubstrateDbContext db, ILogger<AccountService> logger, HybridCache cache)
        {
            _substrateNodeRepository = substrateNodeRepository;

            //if (RequiredStorage.Any(s => s == null))
            //    throw new PalletNotImplementedException($"{_substrateNodeRepository.BlockchainName} does not implement all storages required by {nameof(IAccountService)}");

            _db = db;
            _logger = logger;
            _cache = cache;
        }

        public IEnumerable<IPalletStorage?> RequiredStorage => new List<IPalletStorage?>() {
            _substrateNodeRepository.Storage.Balances,
            _substrateNodeRepository.Storage.Identity,
            _substrateNodeRepository.Storage.System
        };

        private string? _blockHash = null;
        public IAccountService At(string blockHash)
        {
            _blockHash = blockHash;
            return this;
        }

        private IStorage _storageFrom => _blockHash == null ? _substrateNodeRepository.Storage : _substrateNodeRepository.At(_blockHash).Storage;

        private void EnsureAddressIsValid(string address)
        {
            if (address == null || string.IsNullOrEmpty(address))
                throw new ArgumentNullException($"{nameof(address)}");

            if (!_substrateNodeRepository.IsValidAccountAddress(address))
                throw new AddressException($"{address} is invalid");
        }

        public async Task<IEnumerable<AccountLightDto>> GetAccountsAsync(CancellationToken cancellationToken, Pagination pagination)
        {
            var accountsQuery = await _storageFrom.System.AccountsQueryAsync(cancellationToken);
            var result = await accountsQuery.Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ExecuteAsync(cancellationToken);

            var accountsDto = new List<AccountLightDto>();
            if (result == null) return accountsDto;

            await _substrateNodeRepository.Rpc.System.PropertiesAsync(cancellationToken);

            foreach (var (account, _) in result)
            {
                accountsDto.Add(new AccountLightDto()
                {
                    Address = await GetAccountIdentityAsync(account, cancellationToken),
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
                _storageFrom.Balances.LocksAsync(account, cancellationToken),
                _storageFrom.Balances.ReservesAsync(account, cancellationToken),
                _storageFrom.System.AccountAsync(account, cancellationToken),
                _substrateNodeRepository.Rpc.System.PropertiesAsync(cancellationToken),
                _storageFrom.NominationPools.PoolMembersAsync(account, cancellationToken)
            );

            var freeAmount = accountInfo?.Data?.Free?.ToDouble(chainInfo.TokenDecimals) ?? 0;
            var stakingAmount = accountInfo?.Data?.MiscFrozen?.Value.ToDouble(chainInfo.TokenDecimals) ?? 0;
            var lockedAmount = accountInfo?.Data?.Frozen?.Value.ToDouble(chainInfo.TokenDecimals) ?? 0;
            var othersAmount = accountInfo?.Data?.Reserved?.Value.ToDouble(chainInfo.TokenDecimals) ?? 0;

            var lastUsdValue = await _db.TokenPrices
                .Where(x => x.BlockchainName.ToLower() == _substrateNodeRepository.BlockchainName.ToLower())
                .OrderByDescending(x => x.Date)
                .FirstOrDefaultAsync(cancellationToken);

            var nonTransferable = new List<(CurrencyDto, string)>();
            if (locks != null && locks.Value.Any())
            {
                foreach (var lockBalance in locks.Value)
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
                Transferable = new CurrencyDto(freeAmount - lockedAmount, lastUsdValue?.Price),
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
                _storageFrom.Balances.LocksAsync(account, token),
                _storageFrom.Balances.ReservesAsync(account, token),
                _storageFrom.Identity.IdentityOfAsync(account, token),
                _storageFrom.Identity.SubsOfAsync(account, token),
                _storageFrom.Identity.SuperOfAsync(account, token),
                _storageFrom.NominationPools.PoolMembersAsync(account, token),
                _storageFrom.System.AccountAsync(account, token),
                _substrateNodeRepository.Rpc.System.PropertiesAsync(token)
            );

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

            var (accountType, accountIdentity, accountBalance, accountNextindex) = await Helper.WaiterHelper.WaitAndReturnAsync(GetAccountTypeAsync(account, token),
                GetAccountIdentityAsync(account, token),
                GetBalancesAsync(account, token),
                _substrateNodeRepository.Rpc.System.AccountNextIndexAsync(account.ToStringAddress((short)chainInfo.Ss58Format)
                , token));

            var accountDto = new AccountDto()
            {
                InformationsDto = userInformation,
                Address = accountIdentity,
                AccountIndex = accountNextindex,
                Nonce = accountInfo?.Nonce?.Value ?? 0,
                Balances = accountBalance,
                AvatarUrl = string.Empty,
                AccountTypes = accountType.ToList()
            };
            return accountDto;
        }

        public Task<UserIdentityDto> GetAccountIdentityAsync
            (string accountAddress, CancellationToken cancellationToken)
        {
            EnsureAddressIsValid(accountAddress);
            return GetAccountIdentityAsync(new SubstrateAccount(accountAddress), cancellationToken);
        }

        public async Task<UserIdentityDto> GetAccountIdentityAsync(SubstrateAccount account, CancellationToken cancellationToken)
        {
            return await _cache.HandleFromCacheAsync(
                $"AccountIdentity_{account.ToStringAddress()}",
                async () =>
                {
                    return await GetAccountIdentityInnerAsync(account, UserIdentityTypeDto.Anonymous, cancellationToken);
                },
            (res) => { return res is not null; },
            30,
            ["AccountIdentity"],
            cancellationToken);
        }

        private async Task<UserIdentityDto> GetAccountIdentityInnerAsync(SubstrateAccount account, UserIdentityTypeDto type, CancellationToken cancellationToken)
        {
            var (chainInfo, identity, identitySuper) = await Helper.WaiterHelper.WaitAndReturnAsync(
                _substrateNodeRepository.Rpc.System.PropertiesAsync(cancellationToken),
                _storageFrom.Identity.IdentityOfAsync(account, cancellationToken),
                _storageFrom.Identity.SuperOfAsync(account, cancellationToken)
            );

            var blockchainAddress = account.ToStringAddress((short)chainInfo.Ss58Format);

            // Default = it's the basic address
            string name = blockchainAddress;

            if (identitySuper != null)
            {
                type = UserIdentityTypeDto.SubOf;
                var parentAccount = identitySuper.Value[0].As<SubstrateAccount>();
                var identityOfSuper = await _storageFrom.Identity.IdentityOfAsync(parentAccount, cancellationToken);

                // It cannot be null, otherwise it mean that substrate tells us that this account is a sub account but no parent
                // identity has been set. Should never happened, but let's log just in case of
                if (identityOfSuper is null) 
                {
                    _logger.LogError("[{serviceName}] {subAccountAddress} should be SubOf {superAccountAddress} but parent account is not set.", nameof(AccountService), account.ToPolkadotAddress(), parentAccount.ToPolkadotAddress());
                }

                name = identityOfSuper!.Info.Display.ToHuman();
            }

            if (identity != null && identity.Info != null)
            {
                var identityDisplay = identity.Info.Display.ToHuman();
                // If we got a legal identity set, display it
                if (!string.IsNullOrEmpty(identityDisplay))
                {
                    name = identityDisplay;
                }

                type = type == UserIdentityTypeDto.Anonymous ? UserIdentityTypeDto.IdentitySet : type;
            }

            var userAddressDto = new UserIdentityDto()
            {
                Name = name,
                Address = blockchainAddress,
                PublicKey = Utils.Bytes2HexString(Utils.GetPublicKeyFrom(account.ToStringAddress())),
                IdentityType = type
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

            var validatorTask = _storageFrom.Session.NextKeysAsync(account, cancellationToken);
            var nominatorTask = _storageFrom.Staking.NominatorsAsync(account, cancellationToken);
            var identityTask = _storageFrom.Identity.IdentityOfAsync(account, cancellationToken);
            var poolMemberTask = _storageFrom.NominationPools.PoolMembersAsync(account, cancellationToken);

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
