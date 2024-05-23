using FluentValidation;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto;
using Polkanalysis.Domain.Contracts.Dto.Financial;
using Polkanalysis.Domain.Contracts.Primary.FInancial;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Helper.Enumerables;

namespace Polkanalysis.Domain.UseCase.Statistics.Finance
{
    public class GlobalFinanceValidator : AbstractValidator<GlobalFinanceQuery>
    {
        public GlobalFinanceValidator()
        {
        }
    }

    public class GlobalFinanceHandler : Handler<GlobalFinanceHandler, GlobalFinanceDto, GlobalFinanceQuery>
    {
        private readonly IFinancialService _financialService;
        private readonly IExplorerService _explorerService;

        public GlobalFinanceHandler(IFinancialService financialService, ILogger<GlobalFinanceHandler> logger, IExplorerService explorerService, IDistributedCache cache) : base(logger, cache)
        {
            _financialService = financialService;
            _explorerService = explorerService;
        }

        public async override Task<Result<GlobalFinanceDto, ErrorResult>> HandleInnerAsync(GlobalFinanceQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            if (request.RangeDate.From is not null && request.RangeDate.To is not null && request.RangeDate.From.Value > request.RangeDate.To.Value)
            {
                return UseCaseError(ErrorResult.ErrorType.BusinessError, $"{request.RangeDate.From} is greater than {request.RangeDate.To}");
            }

            var transactions = await _financialService.GetTransactionsAsync(request.RangeDate.From, request.RangeDate.To, cancellationToken);

            var pagedTransactions = transactions.OrderByDescending(x => x.BlockNumber).ToPagedResponse(request.Pagination.PageNumber, request.Pagination.PageSize);

            var volume = pagedTransactions.Data.Sum(x => x.Amount.Native);

            var volumePerDay = pagedTransactions.Data
                .GroupBy(x => x.BlockDate)
                .OrderBy(x => x.Key)
                .Select(x => new { Date = x.Key, Volume = x.Sum(x => x.Amount.Native) });

            var averageAmountPerDay = pagedTransactions.Data
                .GroupBy(x => x.BlockDate)
                .OrderBy(x => x.Key)
                .Select(x => new { Date = x.Key, Volume = x.Average(x => x.Amount.Native) });

            var dto = new GlobalFinanceDto(
                pagedTransactions,
                new Contracts.Dto.Balances.CurrencyDto(volume, null),
                volumePerDay
                    .Select(x => new AmountPerDateRangeDto<double>(x.Volume, x.Date, x.Date)).ToList(),
                averageAmountPerDay
                    .Select(x => new AmountPerDateRangeDto<double>(x.Volume, x.Date, x.Date)).ToList(),
                request.RangeDate.From,
                request.RangeDate.To);

            return Helpers.Ok(dto);
        }
    }
}
