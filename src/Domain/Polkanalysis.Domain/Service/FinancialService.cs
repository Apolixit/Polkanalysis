using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Dto.Financial;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database;

namespace Polkanalysis.Domain.Service
{
    public class FinancialService : IFinancialService
    {
        private readonly ISubstrateService _substrateService;
        private readonly SubstrateDbContext _dbContext;
        private readonly IAccountService _accountService;
        private readonly ILogger<ExplorerService> _logger;

        public FinancialService(ISubstrateService substrateService, SubstrateDbContext dbContext, IAccountService accountService, ILogger<ExplorerService> logger)
        {
            _substrateService = substrateService;
            _dbContext = dbContext;
            _accountService = accountService;
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

            if(from is not null)
            {
                accountBalancesTransfer = accountBalancesTransfer.Where(x => x.BlockDate >= from.Value);
            }

            if(to is not null)
            {
                accountBalancesTransfer = accountBalancesTransfer.Where(x => x.BlockDate <= to.Value);
            }

            var dbResult = await accountBalancesTransfer.ToListAsync(token);
            var dto = new List<TransactionDto>();
            if(!dbResult.Any())
            {
                return dto;
            }

            foreach(var res in dbResult)
            {
                dto.Add(new TransactionDto(
                    (uint)res.BlockId,
                    new Contracts.Dto.Balances.CurrencyDto(res.Amount, null),
                    res.From,
                    res.To
                ));
            }

            return dto;
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
                    amount: new Contracts.Dto.Balances.CurrencyDto(res.Amount, null),
                    from: res.From,
                    to: res.To
                ));
            }

            return dto;
        }
    }
}
