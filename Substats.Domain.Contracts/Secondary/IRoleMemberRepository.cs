using Substats.Domain.Contracts.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary
{
    public interface IRoleMemberRepository
    {
        /// <summary>
        /// Get validator information
        /// </summary>
        /// <param name="validatorAddress"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public Task<ValidatorDto> GetValidatorDetailAsync(string validatorAddress, CancellationToken cancellation);

        public Task<NominatorDto> GetNominatorDetailAsync(string nominatorAddress, CancellationToken cancellationToken);

        public Task<PoolDto> GetPoolDetailAsync(uint poolId, CancellationToken cancellation);
    }
}
