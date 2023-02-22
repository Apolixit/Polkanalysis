using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Dto.User;

namespace Substats.Domain.Contracts.Secondary.Repository
{
    public interface IAccountRepository : IRepositoryRequirement
    {
        /// <summary>
        /// Get account information
        /// </summary>
        /// <param name="accountAddress"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<AccountDto> GetAccountDetailAsync(string accountAddress, CancellationToken cancellationToken);

        public Task<UserAddressDto> GetAccountIdentityAsync(SubstrateAccount account, CancellationToken cancellationToken);
        public Task<UserAddressDto> GetAccountIdentityAsync(string accountAddress, CancellationToken cancellationToken);
    }
}
