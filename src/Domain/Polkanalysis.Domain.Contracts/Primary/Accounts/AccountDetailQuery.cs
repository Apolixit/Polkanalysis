using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Common;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary.Result;

namespace Polkanalysis.Domain.Contracts.Primary.Accounts
{
    public class AccountDetailQuery : IRequest<Result<AccountDto, ErrorResult>>, ICached
    {
        public required string AccountAddress { get; set; }
        public AccountType? AccountRole { get; set; }

        public int CacheDurationInMinutes => Settings.Constants.Cache.MediumCache;

        public string GenerateCacheKey()
            => $"AccountDetailQuery_{AccountAddress}";
    }
}
