using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Dto.Era;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Exception;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking.Enums;
using static Polkanalysis.Domain.Contracts.Dto.GlobalStatusDto;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking;
using Polkanalysis.Domain.Helper;
using Substrate.NetApi.Model.Rpc;
using Ardalis.GuardClauses;
using Polkanalysis.Domain.Contracts.Dto.Staking.Pool;
using Polkanalysis.Domain.Contracts.Dto.Staking.Reward;
using Polkanalysis.Domain.Contracts.Dto.Staking.Validator;
using Polkanalysis.Domain.Contracts.Dto.Staking.Nominator;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.Contracts.Dto.Staking.Era;
using Polkanalysis.Domain.Helper.Enumerables;
using Polkanalysis.Infrastructure.Blockchain.Contracts;

namespace Polkanalysis.Domain.Service
{
    public class StakingService : IStakingService
    {
        private readonly ISubstrateService _substrateService;
        private readonly IAccountService _accountRepository;
        private readonly IStakingDatabaseRepository _stakingDatabaseRepository;
        private readonly ILogger<StakingService> _logger;

        public StakingService(
            ISubstrateService substrateService,
            IAccountService accountRepository,
            IStakingDatabaseRepository stakingDatabaseRepository,
            ILogger<StakingService> logger)
        {
            _substrateService = substrateService;
            _accountRepository = accountRepository;
            _stakingDatabaseRepository = stakingDatabaseRepository;
            _logger = logger;
        }

        private void CheckAddress(string address)
        {
            if (address == null || string.IsNullOrEmpty(address))
                throw new ArgumentNullException($"{nameof(address)}");

            if (!_substrateService.IsValidAccountAddress(address))
                throw new AddressException($"{address} is invalid");
        }

        public async Task<IEnumerable<ValidatorLightDto>> GetValidatorsAsync(CancellationToken cancellationToken)
        {
            var validators = await _substrateService.Storage.Session.ValidatorsAsync(cancellationToken);
            var currentEra = await _substrateService.Storage.Staking.CurrentEraAsync(cancellationToken);

            return await BuildFromSubsrateAccountAsync(currentEra.Value, validators.Value, cancellationToken);
        }

        public async Task<IEnumerable<ValidatorLightDto>> GetValidatorsElectedByNominatorAsync(string nominatorAddress, CancellationToken cancellationToken)
        {
            var activeEra = await _substrateService.Storage.Staking.ActiveEraAsync(cancellationToken);
            return await GetValidatorsElectedByNominatorAsync(activeEra.Index.Value, nominatorAddress, cancellationToken);
        }

        public async Task<IEnumerable<ValidatorLightDto>> GetValidatorsElectedByNominatorAsync(uint eraId, string nominatorAddress, CancellationToken cancellationToken)
        {
            var validators = _stakingDatabaseRepository.GetValidatorsVotedByNominator((int)eraId, new SubstrateAccount(nominatorAddress));

            if (validators is null || !validators.Any())
            {
                _logger.LogWarning($"No validator has been elected by nominator {nominatorAddress} for era {eraId}");
                return new List<ValidatorLightDto>();
            }

            return await BuildFromSubsrateAccountAsync(eraId, validators, cancellationToken);
        }

        /// <summary>
        /// Build a ValidatorLightDto from validator substrate account
        /// /!\ This function is private and assume every accounts are valid validator accounts, there is no verification
        /// here so please proceed verification before call this function
        /// </summary>
        /// <param name="eraId"></param>
        /// <param name="validators"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task<IEnumerable<ValidatorLightDto>> BuildFromSubsrateAccountAsync(
            uint eraId,
            IEnumerable<SubstrateAccount> validators,
            CancellationToken cancellationToken)
        {
            var validatorsExtended = await validators
                .ExtendWith(validator => _substrateService.Storage.Staking.ErasStakersAsync(new BaseTuple<U32, SubstrateAccount>(new U32(eraId), validator), cancellationToken))
                .WaitAllAndGetResultAsync();

            if (validatorsExtended == null)
                throw new InvalidOperationException("Validators extended with exposure return null");

            return await BuildFromSubsrateAccountAsync(eraId, validatorsExtended, cancellationToken);
        }

        /// <summary>
        /// Build a ValidatorLightDto from validator substrate account
        /// /!\ This function is private and assume every accounts are valid validator accounts, there is no verification
        /// here so please proceed verification before call this function
        /// </summary>
        /// <param name="eraId"></param>
        /// <param name="validators"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task<IEnumerable<ValidatorLightDto>> BuildFromSubsrateAccountAsync(
            uint eraId,
            IEnumerable<(SubstrateAccount, Exposure)> validators,
            CancellationToken cancellationToken)
        {
            var validatorsDto = new List<ValidatorLightDto>();
            var chainInfo = await _substrateService.Rpc.System.PropertiesAsync(cancellationToken);
            var eraStakers = _stakingDatabaseRepository.GetAllEraStackers((int)eraId);

            var validatorsExtended = validators
                .ExtendWith(x => _accountRepository.GetAccountAddressAsync(x.Item1, cancellationToken))
                .ExtendWith(x => _substrateService.Storage.Staking.ValidatorsAsync(x.Item1, cancellationToken));

            foreach (var v in validatorsExtended.GetExendedList())
            {

                var (_, exposure) = v.Item1;
                var (identity, validatorPrefs) = await validatorsExtended.WaitAndReturnAsync(v);

                if (validatorPrefs is null)
                    _logger.LogWarning("[{serviceName}] ValidatorPrefs for validator {validatorAddress} is null", nameof(StakingService), v.Item1.Item1);

                var validatorDatabase = eraStakers.SingleOrDefault(x => ((SubstrateAccount)x.Item1.Value[1]).Equals(v.Item1));
                int nominatorsCount = 0;
                if (validatorDatabase == default)
                {
                    _logger.LogWarning("[{serviceName}] [Era {eraId}] Validator {validatorAddress} does not found in database !", nameof(StakingService), eraId, v.Item1.Item1);
                }
                else
                {
                    nominatorsCount = validatorDatabase.Item2.Others.Value.Length;
                }

                validatorsDto.Add(new ValidatorLightDto()
                {
                    StashAddress = identity,
                    SelfBonded = exposure is not null && exposure.Own is not null ? exposure.Own.Value.Value.ToDouble(chainInfo.TokenDecimals) : 0,
                    TotalBonded = exposure is not null && exposure.Total is not null ? exposure.Total.Value.Value.ToDouble(chainInfo.TokenDecimals) : 0,
                    Commission = validatorPrefs != null ? validatorPrefs.Commission is not null ? (double)validatorPrefs.Commission.Value.Value : 0 : 0,
                    NbNominatorsVote = nominatorsCount
                });
            }

            return validatorsDto;
        }

        public Task<ValidatorDto> GetValidatorDetailAsync(string validatorAddress, CancellationToken cancellationToken)
        {
            CheckAddress(validatorAddress);
            return GetValidatorDetailInternalAsync(validatorAddress, cancellationToken);
        }

        public async Task<ValidatorDto> GetValidatorDetailInternalAsync(string validatorAddress, CancellationToken cancellationToken)
        {
            var validator = new SubstrateAccount(validatorAddress);

            // Is my account a validator ?
            var validatorSessionKey = await _substrateService.Storage.Session.NextKeysAsync(validator, cancellationToken);

            // If validator session key is not set => account is not a validator
            if (validatorSessionKey == null)
                throw new InvalidOperationException($"Address {validatorAddress} is not a validator");

            var currentEra = await _substrateService.Storage.Staking.CurrentEraAsync(cancellationToken);

            // Get list of currently active validator in session pallet
            var activeValidatorsTask = _substrateService.Storage.Session.ValidatorsAsync(cancellationToken);
            var chainInfoTask = _substrateService.Rpc.System.PropertiesAsync(cancellationToken);

            // Controller account
            var boundedAccountTask = _substrateService.Storage.Staking.BondedAsync(validator, cancellationToken);

            var eraRewardPointsTask = _substrateService.Storage.Staking.ErasRewardPointsAsync(currentEra, cancellationToken); // Reward for each validators (need to find my validator in this list)

            var validatorCountTask = _substrateService.Storage.Staking.CounterForValidatorsAsync(cancellationToken);
            var bondedErasTask = _substrateService.Storage.Staking.BondedErasAsync(cancellationToken);
            var validatorSettingsTask = _substrateService.Storage.Staking.ValidatorsAsync(validator, cancellationToken);

            // Era stakers will return something if my validator is currently active in this current Era
            var nominatorsTask = _substrateService.Storage.Staking.ErasStakersAsync(new BaseTuple<U32, SubstrateAccount>(currentEra, validator), cancellationToken);

            var (activeValidators, chainInfo, boundedAccount, eraRewardPoints, validatorCount, bondedEras, validatorSettings, nominators) = await WaiterHelper.WaitAndReturnAsync(
                activeValidatorsTask, chainInfoTask, boundedAccountTask, eraRewardPointsTask, validatorCountTask, bondedErasTask, validatorSettingsTask, nominatorsTask);

            var publicsDto = validatorSessionKey.Publics.Select(x =>
            {
                return new PublicDto()
                {
                    Name = x.name,
                    KeyType = x.key.Key,
                    Data = Utils.Bytes2HexString(x.key.Value.ToBytes())
                };
            });
            var isValidatorActive = activeValidatorsTask != null && activeValidators.Value.Any(x => x.Equals(validator));
            var validatorDto = new ValidatorDto()
            {
                ControllerAddress = await _accountRepository.GetAccountAddressAsync(boundedAccount, cancellationToken),
                StashAddress = await _accountRepository.GetAccountAddressAsync(boundedAccount, cancellationToken),
                RewardAddress = await _accountRepository.GetAccountAddressAsync(validator, cancellationToken),
                SelfBonded = nominators.Own.Value.Value.ToDouble(chainInfo.TokenDecimals),
                TotalBonded = nominators.Total.Value.Value.ToDouble(chainInfo.TokenDecimals),
                Commission = (double)validatorSettings.Commission.Value.Value,
                SessionKey = publicsDto,
                Status = isValidatorActive ? AliveStatusDto.Active : AliveStatusDto.Inactive
            };
            return validatorDto;
        }

        public async Task<IEnumerable<EraLightDto>> GetErasBoundedToValidatorAsync(string validatorAddress, CancellationToken cancellationToken)
        {
            var validatorAccount = new SubstrateAccount(validatorAddress);
            var erasResult = new List<EraLightDto>();

            // Active Era give current era id and start block
            // According to https://wiki.polkadot.network/docs/maintain-polkadot-parameters
            // One session = 2400 blocks
            uint nbBlockBySession = 2400; // TODO : change by constant on-chain
            var activeEra = await _substrateService.Storage.Staking.ActiveEraAsync(cancellationToken);
            ulong? activeEraBlockStart = activeEra.Start.OptionFlag ? activeEra.Start.Value.Value : null;

            // List eras
            var bondedEras = await _substrateService.Storage.Staking.BondedErasAsync(cancellationToken);
            Guard.Against.Null(bondedEras, nameof(bondedEras));

            foreach (var bondedEra in bondedEras.Value)
            {
                var currentEra = (U32)bondedEra.Value[0];
                var startSession = (U32)bondedEra.Value[1];

                var rewardPoints = await _substrateService.Storage.Staking.ErasRewardPointsAsync(currentEra, cancellationToken);

                if (rewardPoints == null)
                {
                    _logger.LogWarning($"No reward point for Era = {currentEra}");
                    continue;
                }

                var validatorReward = rewardPoints.Individual.Value.SingleOrDefault(x =>
                {
                    var account = (SubstrateAccount)x.Value[0];
                    return account.Equals(validatorAccount);
                });

                if (validatorReward != null)
                {
                    var eraLight = new EraLightDto();
                    eraLight.EraId = currentEra.Value;

                    if (activeEraBlockStart is not null)
                    {
                        eraLight.StartBlock = (uint)activeEraBlockStart.Value + (activeEra.Index.Value - currentEra.Value) * nbBlockBySession;
                        eraLight.EndBlock = (uint)activeEraBlockStart.Value + (activeEra.Index.Value + 1 - currentEra.Value) * nbBlockBySession - 1;
                    }

                    eraLight.BlocksProduced = null; // TODO : for each block need to insert the validator in database to allow fast query
                    eraLight.NbBlockValidated = 0; //eraLight.BlocksProduced.Count();
                    eraLight.RewardPoint = ((U32)validatorReward.Value[1]).Value;

                    erasResult.Add(eraLight);
                }
            }

            // for each eras => staking.erasRewardPoints: PalletStakingEraRewardPoints

            return erasResult;
        }

        public async Task<IEnumerable<RewardDto>> GetRewardsBoundedToValidatorAsync(string validatorAddress, CancellationToken cancellationToken)
        {

            return new List<RewardDto>();
        }

        public async Task<IEnumerable<NominatorLightDto>> GetNominatorsBoundedToValidatorAsync(string validatorAddress, CancellationToken cancellationToken)
        {
            var validator = new SubstrateAccount(validatorAddress);

            // Is my account a validator ?
            var validatorSessionKey = await _substrateService.Storage.Session.NextKeysAsync(validator, cancellationToken);

            // If validator session key is not set => account is not a validator
            if (validatorSessionKey == null)
                throw new InvalidOperationException($"Address {validatorAddress} is not a validator");

            var currentEra = await _substrateService.Storage.Staking.CurrentEraAsync(cancellationToken);
            var chainInfo = await _substrateService.Rpc.System.PropertiesAsync(cancellationToken);

            // Era stakers will return something if my validator is currently active in this current Era
            var nominators = await _substrateService.Storage.Staking.ErasStakersAsync(new BaseTuple<U32, SubstrateAccount>(currentEra, validator), cancellationToken);

            return await ConvertNominatorsAsync(nominators, chainInfo, cancellationToken);
        }

        /// <summary>
        /// Convert substrate nominators to a comphrensive dto
        /// </summary>
        /// <param name="nominators"></param>
        /// <param name="chainInfo"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<NominatorLightDto>> ConvertNominatorsAsync(Exposure nominators, Properties chainInfo, CancellationToken cancellationToken)
        {
            // I try to do the most non-blocking asynchronous call to optimize fetching data
            List<(
                Task<Nominations> nominationsTask,
                Task<SubstrateAccount> nominatorControllerAccountTask,
                Task<UserAddressDto> nominatorStashAccountTask,
                Task<UserAddressDto> nominatorRewardAccountTask,
                double bounded,
                Task<UserAddressDto>? userAddressTask)> nominatorsAccountTask = new List<(Task<Nominations>, Task<SubstrateAccount>, Task<UserAddressDto>, Task<UserAddressDto>, double, Task<UserAddressDto>?)>();

            // I need to get nominator account result to fetch identity
            var nominatorsAndBoundedAccount = nominators.Others.Value.Select(x =>
            {
                return new { IndividualExposure = x, BoundedAccount = _substrateService.Storage.Staking.BondedAsync(x.Who, cancellationToken) };
            });
            await Task.WhenAll(nominatorsAndBoundedAccount.Select(x => x.BoundedAccount));

            // Every asynchronous calls are saved as Task
            foreach (var n in nominatorsAndBoundedAccount)
            {
                nominatorsAccountTask.Add(
                    (
                    _substrateService.Storage.Staking.NominatorsAsync(n.IndividualExposure.Who, cancellationToken),
                    n.BoundedAccount,
                    _accountRepository.GetAccountAddressAsync(n.IndividualExposure.Who, cancellationToken),
                    PayeeAccountAsync(n.IndividualExposure.Who, cancellationToken),
                    n.IndividualExposure.Value.Value.Value.ToDouble(chainInfo.TokenDecimals),
                    _accountRepository.GetAccountAddressAsync(n.BoundedAccount.Result, cancellationToken)
                    )
                );
            }

            var nominatorsDto = new List<NominatorLightDto>();
            foreach (var nominatorAccount in nominatorsAccountTask)
            {
                var (nominations, nominatorStashAccount, nominatorRewardAccount, nominatorIdentityController) = await WaiterHelper.WaitAndReturnAsync(
                    nominatorAccount.nominationsTask,
                    nominatorAccount.nominatorStashAccountTask,
                    nominatorAccount.nominatorRewardAccountTask,
                    nominatorAccount.userAddressTask);

                nominatorsDto.Add(new NominatorLightDto()
                {
                    StashAccount = nominatorStashAccount,
                    ControllerAccount = nominatorIdentityController,
                    RewardAccount = nominatorRewardAccount,
                    Bonded = nominatorAccount.bounded,
                    Status = nominations.Suppressed.Value ? AliveStatusDto.Inactive : AliveStatusDto.Active
                });
            }

            return nominatorsDto;
        }

        public async Task<UserAddressDto?> PayeeAccountAsync(SubstrateAccount stashAccount, CancellationToken cancellationToken)
        {
            var rewardAccount = await _substrateService.Storage.Staking.PayeeAsync(stashAccount, cancellationToken);

            if (rewardAccount is null) return null;

            var account = rewardAccount.Value switch
            {
                RewardDestination.Staked => stashAccount,
                RewardDestination.Controller => await _substrateService.Storage.Staking.BondedAsync(stashAccount, cancellationToken),
                RewardDestination.Stash => stashAccount,
                RewardDestination.Account => (SubstrateAccount)rewardAccount.Value2,
                RewardDestination.None => null,
                _ => throw new NotImplementedException()
            };

            if (account == null) return null;
            return await _accountRepository.GetAccountAddressAsync(account, cancellationToken);
        }

        public async Task<IEnumerable<NominatorLightDto>> GetNominatorsAsync(CancellationToken cancellationToken)
        {
            var nominatorsQuery = await _substrateService.Storage.Staking.NominatorsQueryAsync(cancellationToken);
            var nominatorsResult = await nominatorsQuery.Take(1000).ExecuteAsync(cancellationToken);
            Guard.Against.Null(nominatorsResult, nameof(nominatorsResult));

            var nominatorsDto = new List<NominatorLightDto>();
            if (nominatorsResult.Count == 0) return nominatorsDto;

            var nominatorsExtended = await nominatorsResult
                .ExtendWith(x => _accountRepository.GetAccountAddressAsync(x.Item1, cancellationToken))
                .WaitAllAndGetResultAsync();

            var stashAccount = await Task.WhenAll(nominatorsResult.Select(x =>
            {
                return _accountRepository.GetAccountAddressAsync(x.Item1, cancellationToken);
            }));

            foreach(var ((nominatorAccount, nomination), stashAccountIdentity) in nominatorsExtended)
            {
                var nominatorLight = new NominatorLightDto();
                nominatorLight.StashAccount = stashAccountIdentity;
                nominatorLight.Bonded = 0;
                nominatorLight.NbMembers = nomination.Targets.Value.Length;
                nominatorLight.Status = nomination.Suppressed.Value ? AliveStatusDto.Inactive : AliveStatusDto.Active;
                nominatorsDto.Add(nominatorLight);
            }

            return nominatorsDto;
        }

        public Task<NominatorDto> GetNominatorDetailAsync(string nominatorAddress, CancellationToken cancellationToken)
        {
            CheckAddress(nominatorAddress);
            return GetNominatorDetailInternalAsync(nominatorAddress, cancellationToken);
        }
        private async Task<NominatorDto> GetNominatorDetailInternalAsync(string nominatorAddress, CancellationToken cancellationToken)
        {
            var nominatorAccount = new SubstrateAccount(nominatorAddress);

            // Is my account a nominator ?
            var nominatorSettings = await _substrateService.Storage.Staking.NominatorsAsync(nominatorAccount, cancellationToken);
            if (nominatorSettings.Suppressed == null && nominatorSettings.Targets == null && nominatorSettings.SubmittedIn == null)
                throw new InvalidOperationException($"Address {nominatorAddress} is not a nominator");

            // Check for Event<Rewarded>

            var controllerAccount = await _substrateService.Storage.Staking.BondedAsync(nominatorAccount, cancellationToken);
            var rewardAccount = await PayeeAccountAsync(nominatorAccount, cancellationToken);

            // currentNominators.Targets = current validators whe ave voted for

            //var nominator = nominatorSettings.Targets.Value.Value.FirstOrDefault(x => x.IsEqual(nominatorAccount));



            var targetAccountReward = await _substrateService.Storage.Staking.PayeeAsync(nominatorAccount, cancellationToken);
            var numberNominator = await _substrateService.Storage.Staking.CounterForNominatorsAsync(cancellationToken);
            var maxNumberNominator = await _substrateService.Storage.Staking.MaxNominatorsCountAsync(cancellationToken);
            var minimumNominatorBound = await _substrateService.Storage.Staking.MinNominatorBondAsync(cancellationToken);

            var nominatorDto = new NominatorDto()
            {
                StashAccount = await _accountRepository.GetAccountAddressAsync(nominatorAccount, cancellationToken),
                ControllerAccount = await _accountRepository.GetAccountAddressAsync(controllerAccount, cancellationToken),
                RewardAccount = rewardAccount,
                Bonded = 0, // TODO mapping
                Status = nominatorSettings.Suppressed.Value ? AliveStatusDto.Inactive : AliveStatusDto.Active,
            };

            return nominatorDto;
        }

        public async Task<PoolDto> GetPoolDetailAsync(uint poolId, CancellationToken cancellationToken)
        {
            var poolNumber = new U32();
            poolNumber.Create(poolId);

            // Get nb pools created
            var lastPoolId = await _substrateService.Storage.NominationPools.LastPoolIdAsync(cancellationToken);

            // Check if pool exists 
            if (poolNumber.Value > lastPoolId.Value)
                throw new InvalidOperationException($"Nomination pool num {poolId} does not exists");

            var chainInfo = await _substrateService.Rpc.System.PropertiesAsync(cancellationToken);

            // Get informations about this pool
            var bondedPoolTask = _substrateService.Storage.NominationPools.BondedPoolsAsync(poolNumber, cancellationToken);
            var poolMetadataTask = _substrateService.Storage.NominationPools.MetadataAsync(poolNumber, cancellationToken);
            var rewardPoolTask = _substrateService.Storage.NominationPools.RewardPoolsAsync(poolNumber, cancellationToken);

            // Get pool id associated to account
            //var reverseAccount = await _substrateService.Storage.NominationPools.ReversePoolIdLookupAsync(poolNumber, cancellationToken);

            var counterForBoundedPoolsTask = _substrateService.Storage.NominationPools.CounterForBondedPoolsAsync(cancellationToken);
            var minJoinBondTask = _substrateService.Storage.NominationPools.MinJoinBondAsync(cancellationToken);
            var maxPoolMembersPerPoolTask = _substrateService.Storage.NominationPools.MaxPoolMembersPerPoolAsync(cancellationToken);
            var minimumCreatePoolTask = _substrateService.Storage.NominationPools.MinCreateBondAsync(cancellationToken);
            var maxPoolsTask = _substrateService.Storage.NominationPools.MaxPoolsAsync(cancellationToken);


            //var boundedAccount = await _substrateNodeRepository.Client.StakingStorage.Bonded(validator, cancellationToken);

            var (bondedPool, poolMetadata, rewardPool, counterForBoundedPools, minJoinBond, maxPoolMembersPerPool, minimumCreatePool, maxPools) = await WaiterHelper.WaitAndReturnAsync(bondedPoolTask, poolMetadataTask, rewardPoolTask, counterForBoundedPoolsTask, minJoinBondTask, maxPoolMembersPerPoolTask, minimumCreatePoolTask, maxPoolsTask);

            // Should never happened because we previously check pool counter
            if (bondedPool == null)
                throw new InvalidOperationException($"Pool number {poolNumber} does not exists.");

            // Pool name is integrated in metadata
            var poolName = poolMetadata == null ? string.Empty : poolMetadata.Value.ToHuman();

            var poolGlobalSettings = new PoolGlobalSettingsDto()
            {
                ActivePoolNumber = counterForBoundedPools.Value,
                MinimumJoinPool = minJoinBond.ToDouble(chainInfo.TokenDecimals),
                MaximumMemberPerPool = maxPoolMembersPerPool?.Value,
                MinimumCreatePool = minimumCreatePool.ToDouble(chainInfo.TokenDecimals),
                MaximumPoolNumber = maxPools?.Value
            };

            var rewardAccount = await PayeeAccountAsync(bondedPool.Roles.Depositor, cancellationToken);
            var creatorAccount = await _accountRepository.GetAccountAddressAsync(bondedPool.Roles.Depositor, cancellationToken);
            var nominatorAccount = await _accountRepository.GetAccountAddressAsync(bondedPool.Roles.Nominator.Value, cancellationToken);
            var stashAccount = await _accountRepository.GetAccountAddressAsync(bondedPool.Roles.Root.Value, cancellationToken);
            var togglerAccount = bondedPool.Roles.StateToggler is not null ? await _accountRepository.GetAccountAddressAsync(bondedPool.Roles.StateToggler.Value, cancellationToken) : null;
            var rootAccount = await _accountRepository.GetAccountAddressAsync(bondedPool.Roles.Root.Value, cancellationToken);

            var poolDto = new PoolDto()
            {
                Name = poolName,
                PoolGlobalSettings = poolGlobalSettings,
                CreatorAccount = creatorAccount,
                NominatorAccount = nominatorAccount,
                RewardAccount = rewardAccount,
                StashAccount = stashAccount, // TODO change with real stash account
                TogglerAccount = togglerAccount,
                RootAccount = rootAccount,
                Metadata = poolMetadata is not null ? Utils.Bytes2HexString(poolMetadata.Value.ToBytes()) : string.Empty,
                MemberCount = bondedPool.MemberCounter.Value,
                TotalBonded = bondedPool.Points.Value.ToDouble(chainInfo.TokenDecimals),
                RewardPool = rewardPool.LastRecordedTotalPayouts.Value.ToDouble(chainInfo.TokenDecimals),
                Status = bondedPool.State.Value switch
                {
                    PoolState.Open => NominationPoolStatusDto.Open,
                    PoolState.Blocked => NominationPoolStatusDto.Blocked,
                    PoolState.Destroying => NominationPoolStatusDto.Destroying,
                    _ => throw new NotImplementedException(),
                },
                Members = Enumerable.Empty<PoolMemberDto>(),
                Events = null, // TODO mapping
                ContextEvents = null, // TODO mapping
                PayoutEvents = null, // TODO mapping
                RewardEvents = null, // TODO mapping
                ValidatorsSelected = null, // TODO mapping
            };

            return poolDto;
        }

        public async Task<IEnumerable<PoolLightDto>> GetPoolsAsync(CancellationToken cancellationToken)
        {
            var poolsQuery = await _substrateService.Storage.NominationPools.BondedPoolsQueryAsync(cancellationToken);
            var pools = await poolsQuery.ExecuteAsync(cancellationToken);
            Guard.Against.Null(pools);

            var chainInfo = await _substrateService.Rpc.System.PropertiesAsync(cancellationToken);

            List<PoolLightDto> poolsDto = new List<PoolLightDto>();

            var poolsMetadataTask = pools.Select(x => _substrateService.Storage.NominationPools.MetadataAsync(x.Item1, cancellationToken));
            var poolsMetadata = await Task.WhenAll(poolsMetadataTask);


            foreach (var ((poolId, bondedPool), poolMetadata) in pools.Zip(poolsMetadata))
            {
                //var rewardPool = await _substrateService.Storage.NominationPools.RewardPoolsAsync(poolId, cancellationToken);
                var poolLight = new PoolLightDto();
                poolLight.PoolId = poolId.Value;
                poolLight.Name = poolMetadata == null ? string.Empty : poolMetadata.Value.ToHuman();
                poolLight.NbPoolMembers = bondedPool.MemberCounter.Value;
                poolLight.Commission = 0;
                poolLight.Status = bondedPool.State.Value switch
                {
                    PoolState.Open => NominationPoolStatusDto.Open,
                    PoolState.Blocked => NominationPoolStatusDto.Blocked,
                    PoolState.Destroying => NominationPoolStatusDto.Destroying,
                    _ => throw new NotImplementedException(),
                };
                poolLight.TotalBonded = bondedPool.Points.Value.ToDouble(chainInfo.TokenDecimals);
                poolLight.RewardPool = 0;
                //poolLight.RewardPool = rewardPool.LastRecordedTotalPayouts.Value.ToDouble(chainInfo.TokenDecimals);

                poolsDto.Add(poolLight);
            }

            return poolsDto;
        }

        public async Task<CurrentEraDto> CurrentEraInformationAsync(CancellationToken cancellationToken)
        {
            var activeEra = await _substrateService.Storage.Staking.ActiveEraAsync(cancellationToken);
            var chainProperty = await _substrateService.Rpc.System.PropertiesAsync(cancellationToken);

            var (sessionStart, sessionCurrent, currentNbTotalValidators, activeValidators, idealActiveValidator, currentNbTotalNominators, minValidatorBound, maxValidatorsCount, minNominatorBound, maxNominatorsCount) = await WaiterHelper.WaitAndReturnAsync(
                _substrateService.Storage.Staking.ErasStartSessionIndexAsync(activeEra.Index, cancellationToken),
                _substrateService.Storage.Session.CurrentIndexAsync(cancellationToken),
                _substrateService.Storage.Staking.CounterForValidatorsAsync(cancellationToken),
                _substrateService.Storage.Session.ValidatorsAsync(cancellationToken),
                _substrateService.Storage.Staking.ValidatorCountAsync(cancellationToken),
                _substrateService.Storage.Staking.CounterForNominatorsAsync(cancellationToken),
                _substrateService.Storage.Staking.MinValidatorBondAsync(cancellationToken),
                _substrateService.Storage.Staking.MaxValidatorsCountAsync(cancellationToken),
                _substrateService.Storage.Staking.MinNominatorBondAsync(cancellationToken),
                _substrateService.Storage.Staking.MaxNominatorsCountAsync(cancellationToken));

            var currentEraDto = new CurrentEraDto();
            
            currentEraDto.EraId = activeEra.Index.Value;
            currentEraDto.EraBlockNumberStart = (uint)activeEra.Start.Value.Value;
            currentEraDto.SessionCurrentIndex = sessionCurrent.Value;
            currentEraDto.SessionStartIndex = sessionStart.Value;
            currentEraDto.NbSessionPerEra = 6; // TODO CONSTANTES

            currentEraDto.NbActiveValidators = (uint)activeValidators.Value.Length;
            currentEraDto.NbTotalValidators = currentNbTotalValidators.Value;
            currentEraDto.NbIdealActiveValidators = idealActiveValidator.Value;
            currentEraDto.NbInactiveValidators = currentEraDto.NbTotalValidators - currentEraDto.NbActiveValidators;
            currentEraDto.MinAmountBondValidator = minValidatorBound.ToDouble(chainProperty);
            currentEraDto.NbMaxValidators = maxValidatorsCount.Value;

            currentEraDto.NbTotalNominators = currentNbTotalNominators.Value;
            currentEraDto.MinAmountBondNominator = minNominatorBound.ToDouble(chainProperty);
            currentEraDto.NbMaxNominators = maxNominatorsCount is not null ? maxNominatorsCount.Value : 0;

            return currentEraDto;
        }
    }
}
