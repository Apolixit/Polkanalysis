using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.AjunaExtension;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Dto.Era;
using Substats.Domain.Contracts.Dto.Staking;
using Substats.Domain.Contracts.Dto.User;
using Substats.Domain.Contracts.Exception;
using Substats.Domain.Contracts.Runtime;
using Substats.Domain.Contracts.Secondary;
using Substats.Domain.Contracts.Secondary.Pallet.NominationPools;
using Substats.Domain.Contracts.Secondary.Pallet.NominationPools.Enums;
using Substats.Domain.Contracts.Secondary.Pallet.Staking;
using Substats.Domain.Contracts.Secondary.Repository;
using static Substats.Domain.Contracts.Dto.GlobalStatusDto;

namespace Substats.Domain.Repository
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
            var validator = new SubstrateAccount(validatorAddress);

            // Is my account a validator ?
            var validatorSessionKey = await _substrateNodeRepository.Storage.Session.NextKeysAsync(validator, cancellationToken);

            // If validator session key is not set => account is not a validator
            if (validatorSessionKey == null)
                throw new InvalidOperationException($"Address {validatorAddress} is not a validator");

            // Get list of currently active validator in session pallet
            var activeValidators = await _substrateNodeRepository.Storage.Session.ValidatorsAsync(cancellationToken);
            var isValidatorActive = activeValidators != null && activeValidators.Any(x => x.Equals(validator));

            var chainInfo = await _substrateNodeRepository.Rpc.System.PropertiesAsync(cancellationToken);

            // Controller account
            var boundedAccount = await _substrateNodeRepository.Storage.Staking.BondedAsync(validator, cancellationToken);

            var currentEra = await _substrateNodeRepository.Storage.Staking.CurrentEraAsync(cancellationToken);
            var eraRewardPoints = await _substrateNodeRepository.Storage.Staking.ErasRewardPointsAsync(currentEra, cancellationToken); // Reward for each validators (need to find my validator in this list)
            var validatorCount = await _substrateNodeRepository.Storage.Staking.CounterForValidatorsAsync(cancellationToken);
            var bondedEras = await _substrateNodeRepository.Storage.Staking.BondedErasAsync(cancellationToken);
            var validatorSettings = await _substrateNodeRepository.Storage.Staking.ValidatorsAsync(validator, cancellationToken);

            // Era stakers will return something if my validator is currently active in this current Era
            var nominators = await _substrateNodeRepository.Storage.Staking.ErasStakersAsync((currentEra, validator), cancellationToken);

            var nominatorsDto = nominators.Others.Select(n =>
            {
                var controllerAccount = _substrateNodeRepository.Storage.Staking.BondedAsync(n.Who, cancellationToken).Result;

                return new NominatorDto()
                {
                    StashAccount = _accountRepository.GetAccountIdentityAsync(n.Who, cancellationToken).Result,
                    ControllerAccount = _accountRepository.GetAccountIdentityAsync(controllerAccount, cancellationToken).Result,
                    RewardAccount = PayeeAccountAsync(n.Who, cancellationToken).Result,
                    Bonded = n.Value.Value.ToDouble(chainInfo.TokenDecimals)
                };
            }).ToList();

            var validatorDto = new ValidatorDto()
            {
                ControllerAddress = await _accountRepository.GetAccountIdentityAsync(boundedAccount, cancellationToken),
                StashAddress = await _accountRepository.GetAccountIdentityAsync(boundedAccount, cancellationToken),
                RewardAddress = await _accountRepository.GetAccountIdentityAsync(validator, cancellationToken),
                SelfBonded = nominators.Own.ToDouble(chainInfo.TokenDecimals),
                TotalBonded = nominators.Total.ToDouble(chainInfo.TokenDecimals),
                Commission = (double)validatorSettings.Commission.Value.Value,
                SessionKey = _node.Create().AddData(validatorSessionKey),
                Status = isValidatorActive ? AliveStatusDto.Active : AliveStatusDto.Inactive,
                Nominators = nominatorsDto,
                Eras = new List<EraLightDto>(), // TODO mapping
                Rewards = new List<RewardDto>(), // TODO mapping
            };
            return validatorDto;
        }

        public async Task<UserAddressDto?> PayeeAccountAsync(SubstrateAccount stashAccount, CancellationToken cancellationToken)
        {
            var rewardAccount = await _substrateNodeRepository.Storage.Staking.PayeeAsync(stashAccount, cancellationToken);

            var account = rewardAccount.Value switch
            {
                RewardDestination.Staked => stashAccount,
                RewardDestination.Controller => await _substrateNodeRepository.Storage.Staking.BondedAsync(stashAccount, cancellationToken),
                RewardDestination.Stash => stashAccount,
                RewardDestination.Account => (SubstrateAccount)rewardAccount.Value2,
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
            var nominatorAccount = new SubstrateAccount(nominatorAddress);

            // Is my account a nominator ?
            var nominatorSettings = await _substrateNodeRepository.Storage.Staking.NominatorsAsync(nominatorAccount, cancellationToken);
            if (nominatorSettings == null)
                throw new InvalidOperationException($"Address {nominatorAddress} is not a nominator");

            // Check for Event<Rewarded>

            var controllerAccount = await _substrateNodeRepository.Storage.Staking.BondedAsync(nominatorAccount, cancellationToken);
            var rewardAccount = await PayeeAccountAsync(nominatorAccount, cancellationToken);

            // currentNominators.Targets = current validators whe ave voted for

            //var nominator = nominatorSettings.Targets.Value.Value.FirstOrDefault(x => x.IsEqual(nominatorAccount));



            var targetAccountReward = await _substrateNodeRepository.Storage.Staking.PayeeAsync(nominatorAccount, cancellationToken);
            var numberNominator = await _substrateNodeRepository.Storage.Staking.CounterForNominatorsAsync(cancellationToken);
            var maxNumberNominator = await _substrateNodeRepository.Storage.Staking.MaxNominatorsCountAsync(cancellationToken);
            var minimumNominatorBound = await _substrateNodeRepository.Storage.Staking.MinNominatorBondAsync(cancellationToken);

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
            var lastPoolId = await _substrateNodeRepository.Storage.NominationPools.LastPoolIdAsync(cancellationToken);

            // Check if pool exists 
            if (poolNumber.Value > lastPoolId.Value)
                throw new InvalidOperationException($"Nomination pool num {poolId} does not exists");

            // Get informations about this pool
            var bondedPool = await _substrateNodeRepository.Storage.NominationPools.BondedPoolsAsync(poolNumber, cancellationToken);

            // Should never happened because we previously check pool counter
            if (bondedPool == null)
                throw new InvalidOperationException($"Pool number {poolNumber} does not exists.");

            var chainInfo = await _substrateNodeRepository.Rpc.System.PropertiesAsync(cancellationToken);

            var poolMetadata = await _substrateNodeRepository.Storage.NominationPools.MetadataAsync(poolNumber, cancellationToken);
            // Pool name is integrated in metadata
            var poolName = poolMetadata == null ? string.Empty : poolMetadata.ToHuman();

            var rewardPool = await _substrateNodeRepository.Storage.NominationPools.RewardPoolsAsync(poolNumber, cancellationToken);

            // Get pool id associated to account
            //var reverseAccount = await _substrateNodeRepository.Client.NominationPoolsStorage.ReversePoolIdLookup(poolNumber, cancellationToken);

            var poolGlobalSettings = new PoolGlobalSettingsDto()
            {
                ActivePoolNumber = (await _substrateNodeRepository.Storage.NominationPools.CounterForBondedPoolsAsync(cancellationToken)).Value,
                MinimumJoinPool = (await _substrateNodeRepository.Storage.NominationPools.MinJoinBondAsync(cancellationToken)).ToDouble(chainInfo.TokenDecimals),
                MaximumMemberPerPool = (await _substrateNodeRepository.Storage.NominationPools.MaxPoolMembersPerPoolAsync(cancellationToken))?.Value,
                MinimumCreatePool = (await _substrateNodeRepository.Storage.NominationPools.MinCreateBondAsync(cancellationToken)).ToDouble(chainInfo.TokenDecimals),
                MaximumPoolNumber = (await _substrateNodeRepository.Storage.NominationPools.MaxPoolsAsync(cancellationToken))?.Value
            };


            //var boundedAccount = await _substrateNodeRepository.Client.StakingStorage.Bonded(validator, cancellationToken);

            var poolDto = new PoolDto()
            {
                Name = poolName,
                PoolGlobalSettings = poolGlobalSettings,
                CreatorAccount = await _accountRepository.GetAccountIdentityAsync(bondedPool.Roles.Depositor, cancellationToken),
                NominatorAccount = await _accountRepository.GetAccountIdentityAsync(bondedPool.Roles.Nominator, cancellationToken),
                RewardAccount = await _accountRepository.GetAccountIdentityAsync(bondedPool.Roles.Root, cancellationToken), // TODO change with real stash account
                StashAccount = await _accountRepository.GetAccountIdentityAsync(bondedPool.Roles.Root, cancellationToken), // TODO change with real stash account
                TogglerAccount = await _accountRepository.GetAccountIdentityAsync(bondedPool.Roles.StateToggler, cancellationToken),
                RootAccount = await _accountRepository.GetAccountIdentityAsync(bondedPool.Roles.Root, cancellationToken),
                Metadata = Utils.Bytes2HexString(poolMetadata.ToBytes()),
                MemberCount = bondedPool.MemberCounter.Value,
                TotalBonded = bondedPool.Points.Value,
                RewardPool = 0,
                Status = bondedPool.State switch
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
