using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Dto.Staking;
using Substats.Domain.Contracts.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Repository
{
    public interface IRoleMemberRepository
    {
        /// <summary>
        /// Get validator information
        /// </summary>
        /// <param name="validatorAddress"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public Task<ValidatorDto> GetValidatorDetailAsync(string validatorAddress, CancellationToken cancellationToken);

        public Task<NominatorDto> GetNominatorDetailAsync(string nominatorAddress, CancellationToken cancellationToken);

        public Task<PoolDto> GetPoolDetailAsync(uint poolId, CancellationToken cancellationToken);

        public Task<UserAddressDto?> PayeeAccountAsync(SubstrateAccount stashAccount, CancellationToken cancellationToken);
    }
}
