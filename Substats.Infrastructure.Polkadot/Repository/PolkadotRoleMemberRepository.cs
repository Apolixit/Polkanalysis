using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.AjunaExtension;
using Substats.Domain.Contracts.Dto.Era;
using Substats.Domain.Contracts.Dto.Staking;
using Substats.Domain.Contracts.Dto.User;
using Substats.Domain.Contracts.Exception;
using Substats.Domain.Contracts.Runtime;
using Substats.Domain.Contracts.Secondary;
using Substats.Polkadot.NetApiExt.Generated.Model.pallet_bags_list.list;
using Substats.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools;
using Substats.Polkadot.NetApiExt.Generated.Model.pallet_staking;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using static Substats.Domain.Contracts.Dto.GlobalStatusDto;

namespace Substats.Infrastructure.DirectAccess.Repository
{
    public class PolkadotRoleMemberRepository : IRoleMemberRepository
    {
        private readonly ISubstrateRepository _substrateNodeRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly INode _node;

        public PolkadotRoleMemberRepository(
            ISubstrateRepository substrateNodeRepository,
            IAccountRepository accountRepository,
            INode node)
        {
            _substrateNodeRepository = substrateNodeRepository;
            _accountRepository = accountRepository;
            _node = node;
        }

        private void CheckAddress(string address)
        {
            if (address == null || string.IsNullOrEmpty(address))
                throw new ArgumentNullException($"{nameof(address)}");

            if (!_substrateNodeRepository.IsValidAccountAddress(address))
                throw new AddressException($"{address} is invalid");
        }

        public Task<ValidatorDto> GetValidatorDetailAsync(string validatorAddress, CancellationToken cancellationToken)
        {
            CheckAddress(validatorAddress);
            return GetValidatorDetailInternalAsync(validatorAddress, cancellationToken);
        }

        public async Task<ValidatorDto> GetValidatorDetailInternalAsync(string validatorAddress, CancellationToken cancellationToken)
        {
            var validator = new AccountId32();
            validator.Create(Utils.GetPublicKeyFrom(validatorAddress));

            // Is my account a validator ?
            var validatorSessionKey = await _substrateNodeRepository.Client.SessionStorage.NextKeys(validator, cancellationToken);

            // If validator session key is not set => account is not a validator
            if (validatorSessionKey == null)
                throw new InvalidOperationException($"Address {validatorAddress} is not a validator");

            // Get list of currently active validator in session pallet
            var activeValidators = await _substrateNodeRepository.Client.SessionStorage.Validators(cancellationToken);
            var isValidatorActive = activeValidators != null && activeValidators.Value.Any(x => x.IsEqual(validator));

            var chainInfo = await _substrateNodeRepository.Client.Core.System.PropertiesAsync(cancellationToken);

            // Controller account
            var boundedAccount = await _substrateNodeRepository.Client.StakingStorage.Bonded(validator, cancellationToken);
            
            var currentEra = await _substrateNodeRepository.Client.StakingStorage.CurrentEra(cancellationToken);
            var eraRewardPoints = await _substrateNodeRepository.Client.StakingStorage.ErasRewardPoints(currentEra, cancellationToken); // Reward for each validators (need to find my validator in this list)
            var validatorCount = await _substrateNodeRepository.Client.StakingStorage.CounterForValidators(cancellationToken);
            var bondedEras = await _substrateNodeRepository.Client.StakingStorage.BondedEras(cancellationToken);
            var validatorSettings = await _substrateNodeRepository.Client.StakingStorage.Validators(validator, cancellationToken);

            // Era stakers will return something if my validator is currently active in this current Era
            var tuple = new BaseTuple<U32, AccountId32>();
            tuple.Create(currentEra, validator);
            var nominators = await _substrateNodeRepository.Client.StakingStorage.ErasStakers(tuple, cancellationToken); 

            var nominatorsDto = nominators.Others.Value.Select(n =>
            {
                var controllerAccount = _substrateNodeRepository.Client.StakingStorage.Bonded(n.Who, cancellationToken).Result;
                
                return new NominatorDto()
                {
                    StashAccount = _accountRepository.GetAccountIdentityAsync(n.Who, cancellationToken).Result,
                    ControllerAccount = _accountRepository.GetAccountIdentityAsync(controllerAccount, cancellationToken).Result,
                    RewardAccount = PayeeAccountAsync(n.Who, cancellationToken).Result,
                    Bonded = n.Value.Value.Value.ToDouble(chainInfo.TokenDecimals)
                };
            }).ToList();

            var validatorDto = new ValidatorDto()
            {
                ControllerAddress = await _accountRepository.GetAccountIdentityAsync(boundedAccount, cancellationToken),
                StashAddress = await _accountRepository.GetAccountIdentityAsync(boundedAccount, cancellationToken),
                RewardAddress = await _accountRepository.GetAccountIdentityAsync(validator, cancellationToken),
                SelfBonded = nominators.Own.Value.Value.ToDouble(chainInfo.TokenDecimals),
                TotalBonded = nominators.Total.Value.Value.ToDouble(chainInfo.TokenDecimals),
                Commission = (double)validatorSettings.Commission.Value.Value,
                SessionKey = _node.Create().AddData(validatorSessionKey),
                Status = isValidatorActive ? AliveStatusDto.Active : AliveStatusDto.Inactive,
                Nominators = nominatorsDto,
                Eras = new List<EraLightDto>(), // TODO mapping
                Rewards = new List<RewardDto>(), // TODO mapping
            };
            return validatorDto;
        }

        public async Task<UserAddressDto?> PayeeAccountAsync(AccountId32 stashAccount, CancellationToken cancellationToken)
        {
            var rewardAccount = await _substrateNodeRepository.Client.StakingStorage.Payee(stashAccount, cancellationToken);

            var account = rewardAccount.Value switch
            {
                RewardDestination.Staked => stashAccount,
                RewardDestination.Controller => await _substrateNodeRepository.Client.StakingStorage.Bonded(stashAccount, cancellationToken),
                RewardDestination.Stash => stashAccount,
                RewardDestination.Account => (AccountId32)rewardAccount.Value2,
                RewardDestination.None => null,
            };

            if (account == null) return null;
            return await _accountRepository.GetAccountIdentityAsync(account, cancellationToken);
        }

        public Task<NominatorDto> GetNominatorDetailAsync(string nominatorAddress, CancellationToken cancellationToken)
        {
            CheckAddress(nominatorAddress);
            return GetNominatorDetailInternalAsync(nominatorAddress, cancellationToken);
        }
        private async Task<NominatorDto> GetNominatorDetailInternalAsync(string nominatorAddress, CancellationToken cancellationToken)
        {
            var nominatorAccount = new AccountId32();
            nominatorAccount.Create(Utils.GetPublicKeyFrom(nominatorAddress));

            // Is my account a nominator ?
            var nominatorSettings = await _substrateNodeRepository.Client.StakingStorage.Nominators(nominatorAccount, cancellationToken);
            if(nominatorSettings == null)
                throw new InvalidOperationException($"Address {nominatorAddress} is not a nominator");

            // Check for Event<Rewarded>

            var controllerAccount = await _substrateNodeRepository.Client.StakingStorage.Bonded(nominatorAccount, cancellationToken);
            var rewardAccount = await PayeeAccountAsync(nominatorAccount, cancellationToken);

            // currentNominators.Targets = current validators whe ave voted for

            //var nominator = nominatorSettings.Targets.Value.Value.FirstOrDefault(x => x.IsEqual(nominatorAccount));



            var targetAccountReward = await _substrateNodeRepository.Client.StakingStorage.Payee(nominatorAccount, cancellationToken);
            var numberNominator = await _substrateNodeRepository.Client.StakingStorage.CounterForNominators(cancellationToken);
            var maxNumberNominator = await _substrateNodeRepository.Client.StakingStorage.MaxNominatorsCount(cancellationToken);
            var minimumNominatorBound = await _substrateNodeRepository.Client.StakingStorage.MinNominatorBond(cancellationToken);

            var nominatorDto = new NominatorDto()
            {
                StashAccount = await _accountRepository.GetAccountIdentityAsync(nominatorAccount, cancellationToken),
                ControllerAccount = await _accountRepository.GetAccountIdentityAsync(controllerAccount, cancellationToken),
                RewardAccount = rewardAccount,
                Bonded = 0, // TODO mapping
                Status = nominatorSettings.Suppressed.Value ? AliveStatusDto.Inactive : AliveStatusDto.Active,
            };

            return nominatorDto;
        }

        public async Task<PoolDto> GetPoolDetailAsync(uint poolId, CancellationToken cancellationToken)
        {
            //var poolMember = await _substrateNodeRepository.Client.NominationPoolsStorage.PoolMembers(currentNominators.Targets.Value.Value[0], cancellationToken);
            var poolNumber = new U32();
            poolNumber.Create(poolId);

            // Get nb pools created
            var lastPoolId = await _substrateNodeRepository.Client.NominationPoolsStorage.LastPoolId(cancellationToken);

            // Check if pool exists 
            if (poolNumber.Value > lastPoolId.Value)
                throw new InvalidOperationException($"Nomination pool num {poolId} does not exists");

            // Get informations about this pool
            var bondedPool = await _substrateNodeRepository.Client.NominationPoolsStorage.BondedPools(poolNumber, cancellationToken);

            // Should never happened because we previously check pool counter
            if (bondedPool == null)
                throw new InvalidOperationException($"Pool number {poolNumber} does not exists.");

            var chainInfo = await _substrateNodeRepository.Client.Core.System.PropertiesAsync(cancellationToken);

            var poolMetadata = await _substrateNodeRepository.Client.NominationPoolsStorage.Metadata(poolNumber, cancellationToken);
            // Pool name is integrated in metadata
            var poolName = poolMetadata.Bytes.ToHuman();
            
            var rewardPool = await _substrateNodeRepository.Client.NominationPoolsStorage.RewardPools(poolNumber, cancellationToken);

            // Get pool id associated to account
            //var reverseAccount = await _substrateNodeRepository.Client.NominationPoolsStorage.ReversePoolIdLookup(poolNumber, cancellationToken);

            var poolGlobalSettings = new PoolGlobalSettingsDto()
            {
                ActivePoolNumber = (await _substrateNodeRepository.Client.NominationPoolsStorage.CounterForBondedPools(cancellationToken)).Value,
                MinimumJoinPool = (await _substrateNodeRepository.Client.NominationPoolsStorage.MinJoinBond(cancellationToken)).ToDouble(chainInfo.TokenDecimals),
                MaximumMemberPerPool = (await _substrateNodeRepository.Client.NominationPoolsStorage.MaxPoolMembersPerPool(cancellationToken))?.Value,
                MinimumCreatePool = (await _substrateNodeRepository.Client.NominationPoolsStorage.MinCreateBond(cancellationToken)).ToDouble(chainInfo.TokenDecimals),
                MaximumPoolNumber = (await _substrateNodeRepository.Client.NominationPoolsStorage.MaxPools(cancellationToken))?.Value
            };
            

            //var boundedAccount = await _substrateNodeRepository.Client.StakingStorage.Bonded(validator, cancellationToken);

            var poolDto = new PoolDto()
            {
                Name = poolName,
                PoolGlobalSettings = poolGlobalSettings,
                CreatorAccount = await _accountRepository.GetAccountIdentityAsync(bondedPool.Roles.Depositor, cancellationToken),
                NominatorAccount = await _accountRepository.GetAccountIdentityAsync(bondedPool.Roles.Nominator.Value, cancellationToken),
                RewardAccount = await _accountRepository.GetAccountIdentityAsync(bondedPool.Roles.Root.Value, cancellationToken), // TODO change with real stash account
                StashAccount = await _accountRepository.GetAccountIdentityAsync(bondedPool.Roles.Root.Value, cancellationToken), // TODO change with real stash account
                TogglerAccount = await _accountRepository.GetAccountIdentityAsync(bondedPool.Roles.StateToggler.Value, cancellationToken),
                RootAccount = await _accountRepository.GetAccountIdentityAsync(bondedPool.Roles.Root.Value, cancellationToken),
                Metadata = Utils.Bytes2HexString(poolMetadata.Value.Bytes),
                MemberCount = bondedPool.MemberCounter.Value,
                TotalBonded = bondedPool.Points.Value,
                RewardPool = 0,
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
    }
}
