using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.AjunaExtension;
using Substats.Domain.Contracts.Dto.User;
using Substats.Domain.Contracts.Secondary;
using Substats.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Substats.Domain.Contracts.Dto.GlobalStatusDto;

namespace Substats.Infrastructure.DirectAccess.Repository
{
    public class PolkadotRoleMemberRepository : IRoleMemberRepository
    {
        private readonly ISubstrateRepository _substrateNodeRepository;

        public PolkadotRoleMemberRepository(ISubstrateRepository substrateNodeRepository)
        {
            _substrateNodeRepository = substrateNodeRepository;
        }

        public async Task<ValidatorDto> GetValidatorDetailAsync(string validatorAddress, CancellationToken cancellationToken)
        {
            if (validatorAddress == null) throw new ArgumentNullException($"{nameof(validatorAddress)}");

            var validatorAccount = new AccountId32();
            validatorAccount.Create(Utils.GetPublicKeyFrom(validatorAddress));

            var activeValidators = await _substrateNodeRepository.Client.SessionStorage.Validators(cancellationToken);

            var validator = activeValidators.Value.FirstOrDefault(x => activeValidators.Value[0].IsEqual(validatorAccount));
            if (validator == null)
                throw new InvalidOperationException($"Address {validatorAddress} is not a validator");

            var chainInfo = await _substrateNodeRepository.Client.Core.System.PropertiesAsync(cancellationToken);

            var res1 = await _substrateNodeRepository.Client.SystemStorage.Account(validatorAccount, cancellationToken);
            //var res2 = await _substrateNodeRepository.Client.VestingStorage

            //Controller account
            var boundedAccount = await _substrateNodeRepository.Client.StakingStorage.Bonded(validator, cancellationToken);
            var boundedAddress = boundedAccount.ToStringAddress((short)chainInfo.Ss58Format);

            var activeErra = await _substrateNodeRepository.Client.StakingStorage.ActiveEra(cancellationToken); // ?
            var currentEra = await _substrateNodeRepository.Client.StakingStorage.CurrentEra(cancellationToken);
            var eraRewardPoints = await _substrateNodeRepository.Client.StakingStorage.ErasRewardPoints(currentEra, cancellationToken); // Reward for each validators (need to find my validator in this list)
            var validatorCount = await _substrateNodeRepository.Client.StakingStorage.CounterForValidators(cancellationToken);
            var bondedEras = await _substrateNodeRepository.Client.StakingStorage.BondedEras(cancellationToken);

            var validatorSettings = await _substrateNodeRepository.Client.StakingStorage.Validators(validator, cancellationToken);

            var tuple = new BaseTuple<U32, AccountId32>();
            tuple.Create(currentEra, validator);
            var nominators = await _substrateNodeRepository.Client.StakingStorage.ErasStakers(tuple, cancellationToken); 

            var nominatorsDto = nominators.Others.Value.Select(async n =>
            {
                var nominatorAddress = Utils.GetAddressFrom(n.Who.Value.Bytes, (short)chainInfo.Ss58Format);
                var controllerAccount = await _substrateNodeRepository.Client.StakingStorage.Bonded(n.Who, cancellationToken);
                var rewardAccount = await _substrateNodeRepository.Client.StakingStorage.Payee(n.Who, cancellationToken);
                return new NominatorDto()
                {
                    ControllerAddress = nominatorAddress,
                    RewardAddress = nominatorAddress,
                    StashAddress = nominatorAddress,
                    Bonded = (double)n.Value.Value.Value / Math.Pow(10, chainInfo.TokenDecimals)
                };
            }).ToList();

            var validatorDto = new ValidatorDto()
            {
                ControllerAddress = boundedAddress,
                StashAddress = boundedAddress,
                RewardAddress = validatorAddress,
                SelfBonded = (double)nominators.Own.Value.Value / Math.Pow(10, chainInfo.TokenDecimals),
                TotalBonded = (double)nominators.Total.Value.Value / Math.Pow(10, chainInfo.TokenDecimals),
                Commission = (double)validatorSettings.Commission.Value.Value,
                Nominators = nominatorsDto,
                Status = validatorSettings.Blocked.Value ? AliveStatusDto.Inactive : AliveStatusDto.Active
            };
            return validatorDto;
        }


        public async Task<NominatorDto> GetNominatorDetailAsync(string nominatorAddress, CancellationToken cancellationToken)
        {
            if (nominatorAddress == null) throw new ArgumentNullException($"{nameof(nominatorAddress)}");

            var nominatorAccount = new AccountId32();
            nominatorAccount.Create(Utils.GetPublicKeyFrom(nominatorAddress));

            // Check for Event<Rewarded>

            var boundedControllerAccount = await _substrateNodeRepository.Client.StakingStorage.Bonded(nominatorAccount, cancellationToken);
            var rewardAccount = await _substrateNodeRepository.Client.StakingStorage.Payee(nominatorAccount, cancellationToken);

            var currentNominators = await _substrateNodeRepository.Client.StakingStorage.Nominators(nominatorAccount, cancellationToken);

            var nominator = currentNominators.Targets.Value.Value.FirstOrDefault(x => x.IsEqual(nominatorAccount));



            var targetAccountReward = await _substrateNodeRepository.Client.StakingStorage.Payee(nominatorAccount, cancellationToken);
            var numberNominator = await _substrateNodeRepository.Client.StakingStorage.CounterForNominators(cancellationToken);
            var maxNumberNominator = await _substrateNodeRepository.Client.StakingStorage.MaxNominatorsCount(cancellationToken);
            var minimumNominatorBound = await _substrateNodeRepository.Client.StakingStorage.MinNominatorBond(cancellationToken);

            var nominatorDto = new NominatorDto()
            {
                ControllerAddress = "",
                RewardAddress = "",
                StashAddress = "",
                Bonded = 0,
                Status = Domain.Contracts.Dto.GlobalStatusDto.AliveStatusDto.Active
            };

            return nominatorDto;
        }

        public async Task<PoolDto> GetPoolDetailAsync(uint poolId, CancellationToken cancellationToken)
        {
            //var poolMember = await _substrateNodeRepository.Client.NominationPoolsStorage.PoolMembers(currentNominators.Targets.Value.Value[0], cancellationToken);
            var poolNumber = new U32();
            poolNumber.Create(poolId);

            var bondedPool = await _substrateNodeRepository.Client.NominationPoolsStorage.BondedPools(poolNumber, cancellationToken);

            if (bondedPool == null)
                throw new InvalidOperationException($"Pool number {poolNumber} does not exists.");

            var chainInfo = await _substrateNodeRepository.Client.Core.System.PropertiesAsync(cancellationToken);





            var nbPool = await _substrateNodeRepository.Client.NominationPoolsStorage.CounterForBondedPools(cancellationToken);
            var minJoinBond = await _substrateNodeRepository.Client.NominationPoolsStorage.MinJoinBond(cancellationToken);
            var poolMetadata = await _substrateNodeRepository.Client.NominationPoolsStorage.Metadata(poolNumber, cancellationToken);
            var rewardPool = await _substrateNodeRepository.Client.NominationPoolsStorage.RewardPools(poolNumber, cancellationToken);

            var totalBonded = bondedPool.Points.Value;

            var poolDto = new PoolDto()
            {
                Name = "", // Todo call identity storage
                CreatorAddress = bondedPool.Roles.Depositor.ToStringAddress(chainInfo.Ss58Format),
                NominatorAddress = bondedPool.Roles.Nominator.Value.ToStringAddress(chainInfo.Ss58Format),
                RewardAddress = "", // Check account ?
                StashAddress = "", // Check account ?
                TogglerAddress = bondedPool.Roles.StateToggler.Value.ToStringAddress(chainInfo.Ss58Format),
                RootAddress = bondedPool.Roles.Root.Value.ToStringAddress(chainInfo.Ss58Format),
                MemberCount = bondedPool.MemberCounter.Value,
                TotalBounded = bondedPool.Points.Value,
                RewardAmount = 0,
                Status = bondedPool.State.Value switch
                {
                    PoolState.Open => NominationPoolStatusDto.Open,
                    PoolState.Blocked => NominationPoolStatusDto.Blocked,
                    PoolState.Destroying => NominationPoolStatusDto.Destroying,
                }
            };

            return null;
        }
    }
}
