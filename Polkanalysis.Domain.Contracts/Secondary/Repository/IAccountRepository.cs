using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Dto.User;

namespace Polkanalysis.Domain.Contracts.Secondary.Repository
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
        public Task<IEnumerable<AccountListDto>> GetAccountsAsync(CancellationToken cancellationToken);

        public Task<UserAddressDto> GetAccountIdentityAsync(SubstrateAccount account, CancellationToken cancellationToken);
        public Task<UserAddressDto> GetAccountIdentityAsync(string accountAddress, CancellationToken cancellationToken);

        public Task<IEnumerable<AccountType>> GetAccountTypeAsync(string accountAddress, CancellationToken cancellationToken);
        public Task<IEnumerable<AccountType>> GetAccountTypeAsync(SubstrateAccount account, CancellationToken cancellationToken);
    }
}
