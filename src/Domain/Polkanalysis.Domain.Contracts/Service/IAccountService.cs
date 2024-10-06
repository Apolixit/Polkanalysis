using Polkanalysis.Domain.Contracts.Common;
using Polkanalysis.Domain.Contracts.Dto.Balances;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Domain.Contracts.Service
{
    public interface IAccountService : IServiceRequirement
    {
        /// <summary>
        /// Aggregate all the information on the given account
        /// </summary>
        /// <param name="accountAddress"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<AccountDto> GetAccountDetailAsync(string accountAddress, CancellationToken cancellationToken);

        /// <summary>
        /// Aggregate all the information on the given account
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<AccountLightDto>> GetAccountsAsync(CancellationToken cancellationToken, Pagination pagination);

        /// <summary>
        /// Get the account address and the public key
        /// </summary>
        /// <param name="account"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<UserIdentityDto> GetAccountIdentityAsync(SubstrateAccount account, CancellationToken cancellationToken);

        /// <summary>
        /// Get the account address and the public key
        /// </summary>
        /// <param name="accountAddress"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<UserIdentityDto> GetAccountIdentityAsync(string accountAddress, CancellationToken cancellationToken);

        /// <summary>
        /// Get the account type, what is it, a Nominator, a validator, a pool member, a system account etc.
        /// </summary>
        /// <param name="accountAddress"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<AccountType>> GetAccountTypeAsync(string accountAddress, CancellationToken cancellationToken);

        /// <summary>
        /// Get the account type, what is it, a Nominator, a validator, a pool member, a system account etc.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<AccountType>> GetAccountTypeAsync(SubstrateAccount account, CancellationToken cancellationToken);

        /// <summary>
        /// Get the details of the account balance, what is free, reserved, locked, pool etc.
        /// </summary>
        /// <param name="accountAddress"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<BalancesDto> GetBalancesAsync(string accountAddress, CancellationToken cancellationToken);

        /// <summary>
        /// Get the details of the account balance, what is free, reserved, locked, pool etc.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<BalancesDto> GetBalancesAsync(SubstrateAccount account, CancellationToken cancellationToken);
    }
}
