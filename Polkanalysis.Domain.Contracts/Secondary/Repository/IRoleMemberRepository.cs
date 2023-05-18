using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Dto.Staking;
using Polkanalysis.Domain.Contracts.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Repository
{
    public interface IStakingRepository
    {
        /// <summary>
        /// Get validator information
        /// </summary>
        /// <param name="validatorAddress"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public Task<ValidatorDto> GetValidatorDetailAsync(string validatorAddress, CancellationToken cancellationToken);
        public Task<IEnumerable<ValidatorLightDto>> GetValidatorsAsync(CancellationToken cancellationToken);

        public Task<IEnumerable<NominatorLightDto>> GetNominatorsAsync(CancellationToken cancellationToken);
        public Task<NominatorDto> GetNominatorDetailAsync(string nominatorAddress, CancellationToken cancellationToken);

        public Task<PoolDto> GetPoolDetailAsync(uint poolId, CancellationToken cancellationToken);

        public Task<UserAddressDto?> PayeeAccountAsync(SubstrateAccount stashAccount, CancellationToken cancellationToken);
    }
}
