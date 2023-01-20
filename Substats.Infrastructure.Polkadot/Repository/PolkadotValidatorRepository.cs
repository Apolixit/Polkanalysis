using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
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
    public class PolkadotValidatorRepository : IValidatorRepository
    {
        private readonly ISubstrateNodeRepository _substrateNodeRepository;

        public PolkadotValidatorRepository(ISubstrateNodeRepository substrateNodeRepository)
        {
            _substrateNodeRepository = substrateNodeRepository;
        }

        public async Task<ValidatorDto> GetValidatorDetailAsync(string validatorAddress, CancellationToken cancellationToken)
        {
            if (validatorAddress == null) throw new ArgumentNullException($"{nameof(validatorAddress)}");

            var validatorAccount = new AccountId32();
            validatorAccount.Create(Utils.GetPublicKeyFrom(validatorAddress));

            var currentValidators = await _substrateNodeRepository.Client.SessionStorage.Validators(cancellationToken);

            var validator = currentValidators.Value.FirstOrDefault(x => currentValidators.Value[0].Value.Encode().SequenceEqual(validatorAccount.Value.Encode()));
            if (validator == null)
                throw new InvalidOperationException($"Address {validatorAddress} is not a validator");

            var chainInfo = await _substrateNodeRepository.Client.Core.System.PropertiesAsync(cancellationToken);

            var res1 = await _substrateNodeRepository.Client.SystemStorage.Account(validatorAccount, cancellationToken);
            //var res2 = await _substrateNodeRepository.Client.VestingStorage
            var bondedAddress = await _substrateNodeRepository.Client.StakingStorage.Bonded(validator, cancellationToken);
            //var boundedAddress = Utils.GetAddressFrom(res3.Bytes);
            var boundedAddress = Utils.GetAddressFrom(bondedAddress.Bytes, (short)chainInfo.Ss58Format);

            var res4 = await _substrateNodeRepository.Client.StakingStorage.ActiveEra(cancellationToken);
            var res5 = await _substrateNodeRepository.Client.StakingStorage.CurrentEra(cancellationToken);
            var res6 = await _substrateNodeRepository.Client.StakingStorage.ErasRewardPoints(res5, cancellationToken);
            var res7 = await _substrateNodeRepository.Client.StakingStorage.CounterForValidators(cancellationToken);
            var res8 = await _substrateNodeRepository.Client.StakingStorage.BondedEras(cancellationToken);

            var validatorSettings = await _substrateNodeRepository.Client.StakingStorage.Validators(validator, cancellationToken);

            var tuple = new BaseTuple<U32, AccountId32>();
            tuple.Create(res5, validator);
            var nominators = await _substrateNodeRepository.Client.StakingStorage.ErasStakers(tuple, cancellationToken);

            var nominatorsDto = nominators.Others.Value.Select(n =>
            {
                var nominatorAddress = Utils.GetAddressFrom(n.Who.Value.Bytes, (short)chainInfo.Ss58Format);
                return new NominatorDto()
                {
                    ControllerAddress = nominatorAddress,
                    RewardAddress = nominatorAddress,
                    StashAddress = nominatorAddress,
                    Bonded = (double)n.Value.Value.Value / Math.Pow(10, chainInfo.TokenDecimals)
                };
            }).ToList();
            //Utils.GetPublicKeyFrom(AccountHelper.BuildAddress((AccountId32)input))
            //var xx = Utils.GetAddressFrom(res1.Value[0].Value.Bytes);

            var validatorDto = new ValidatorDto()
            {
                ControllerAddress = boundedAddress,
                StashAddress = boundedAddress,
                RewardAddress = validatorAddress,
                SelfBonded = (double)nominators.Own.Value.Value / Math.Pow(10, chainInfo.TokenDecimals),
                TotalBonded = (double)nominators.Total.Value.Value / Math.Pow(10, chainInfo.TokenDecimals),
                Commission = (double)validatorSettings.Commission.Value.Value,
                Nominators = nominatorsDto,
                Status = validatorSettings.Blocked.Value ? 
                    Domain.Contracts.Dto.GlobalStatusDto.AliveStatusDto.Active : Domain.Contracts.Dto.GlobalStatusDto.AliveStatusDto.Inactive
            };
            return validatorDto;
        }
    }
}
