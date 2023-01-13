using Blazscan.Domain.Contracts;
using Blazscan.Domain.Contracts.Secondary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Infrastructure.DirectAccess.Repository
{
    internal class AccountRepository : IAccountRepository
    {
        public Task<AccountDto> GetAccountDetailAsync(string accountAddress, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
