using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Dto.Financial;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Infrastructure.Database;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances;

namespace Polkanalysis.Domain.Service
{
    public class FinancialService : IFinancialService
    {
        private readonly ISubstrateService _substrateService;
        private readonly SubstrateDbContext _dbContext;
        private readonly ILogger<FinancialService> _logger;

        public FinancialService(ISubstrateService substrateService, SubstrateDbContext dbContext, ILogger<FinancialService> logger)
        {
            _substrateService = substrateService;
            _dbContext = dbContext;
            _logger = logger;
        }

        /// <summary>
        /// Get transactions for a specific account during a specific time period
        /// </summary>
        /// <param name="account"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TransactionDto>> GetAccountTransactionsAsync(SubstrateAccount account, DateTime? from, DateTime? to, CancellationToken token)
        {
            var stringAccount = account.ToStringAddress();
            var accountBalancesTransfer = _dbContext.EventBalancesTransfer
                .Where(x => x.From.ToLower() == stringAccount.ToLower() || x.To.ToLower() == stringAccount.ToLower());

            return await buildTransactionInnerAsync(from, to, accountBalancesTransfer);
        }

        /// <summary>
        /// Get transactions on the whole network during a specific time period
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TransactionDto>> GetTransactionsAsync(DateTime? from, DateTime? to, CancellationToken token)
        {
            var accountBalancesTransfer = _dbContext.EventBalancesTransfer.AsQueryable();
            return await buildTransactionInnerAsync(from, to, accountBalancesTransfer);
        }

        private async Task<IEnumerable<TransactionDto>> buildTransactionInnerAsync(DateTime? from, DateTime? to, IQueryable<BalancesTransferModel> accountBalancesTransfer)
        {
            if (from is not null)
            {
                accountBalancesTransfer = accountBalancesTransfer.Where(x => x.BlockDate >= from.Value);
            }

            if (to is not null)
            {
                accountBalancesTransfer = accountBalancesTransfer.Where(x => x.BlockDate <= to.Value);
            }

            var dbResult = await accountBalancesTransfer.ToListAsync();
            var dto = new List<TransactionDto>();

            if (!dbResult.Any())
            {
                _logger.LogWarning("[{serviceName}] No transactions found in the database", nameof(FinancialService));
                return dto;
            }

            foreach (var res in dbResult)
            {
                dto.Add(new TransactionDto(
                    blockNumber: (uint)res.BlockId,
                    blockDate: res.BlockDate,
                    amount: new Contracts.Dto.Balances.CurrencyDto(res.Amount, null),
                    from: res.From,
                    to: res.To
                ));
            }

            return dto;
        }
    }
}
