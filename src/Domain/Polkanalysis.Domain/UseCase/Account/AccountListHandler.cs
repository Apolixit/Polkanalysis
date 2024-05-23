using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary.Accounts;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Service;

namespace Polkanalysis.Domain.UseCase.Account
{
    public class AccountListHandler : Handler<AccountListHandler, PagedResponseDto<AccountLightDto>, AccountsQuery>
    {
        private readonly IAccountService _accountRepository;
        public AccountListHandler(IAccountService accountRepository, ILogger<AccountListHandler> logger, IDistributedCache cache) : base(logger, cache)
        {
            _accountRepository = accountRepository;
        }

        public async override Task<Result<PagedResponseDto<AccountLightDto>, ErrorResult>> HandleInnerAsync(AccountsQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var res = await _accountRepository.GetAccountsAsync(cancellationToken, request.Pagination);

            var pagesResult = res.OrderByDescending(x => x.Balances.Total).ToPagedResponse(request.Pagination.PageNumber, request.Pagination.PageSize);

            return Helpers.Ok(pagesResult);
        }
    }
}
