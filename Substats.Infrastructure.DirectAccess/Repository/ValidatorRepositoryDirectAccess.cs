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
    public class ValidatorRepositoryDirectAccess : IValidatorRepository
    {
        private readonly ISubstrateNodeRepository _substrateNodeRepository;

        public ValidatorRepositoryDirectAccess(ISubstrateNodeRepository substrateNodeRepository)
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

            var res1 = await _substrateNodeRepository.Client.SystemStorage.Account(validatorAccount, cancellationToken);
            //var res2 = await _substrateNodeRepository.Client.VestingStorage
            var res3 = await _substrateNodeRepository.Client.StakingStorage.Bonded(validator, cancellationToken);
            var boundedAddress = Utils.GetAddressFrom(res3.Bytes);
            var boundedAddress2 = Utils.GetAddressFrom(res3.Bytes, 0);

            var res4 = await _substrateNodeRepository.Client.StakingStorage.ActiveEra(cancellationToken);
            var res5 = await _substrateNodeRepository.Client.StakingStorage.CurrentEra(cancellationToken);
            var res6 = await _substrateNodeRepository.Client.StakingStorage.ErasRewardPoints(res5, cancellationToken);
            var res7 = await _substrateNodeRepository.Client.StakingStorage.CounterForValidators(cancellationToken);
            var res8 = await _substrateNodeRepository.Client.StakingStorage.BondedEras(cancellationToken);

            var tuple = new BaseTuple<U32, AccountId32>();
            tuple.Create(res5, validator);
            var res9 = await _substrateNodeRepository.Client.StakingStorage.ErasStakers(tuple, cancellationToken);

            //Utils.GetPublicKeyFrom(AccountHelper.BuildAddress((AccountId32)input))
            //var xx = Utils.GetAddressFrom(res1.Value[0].Value.Bytes);
            return null;
        }
    }
}
