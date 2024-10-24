using Polkanalysis.Domain.Contracts.Dto.Financial;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Domain.Contracts.Service
{
    public interface IFinancialService
    {
        /// <summary>
        /// Get transactions for a specific account during a specific time period
        /// </summary>
        /// <param name="account"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<IEnumerable<TransactionDto>> GetAccountTransactionsAsync(SubstrateAccount account, DateTime? from, DateTime? to, CancellationToken token);

        /// <summary>
        /// Get transactions on the whole network during a specific time period
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<IEnumerable<TransactionDto>> GetTransactionsAsync(DateTime? from, DateTime? to, CancellationToken token);
    }
}
