using FluentValidation;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Financial;
using Polkanalysis.Domain.Contracts.Primary.FInancial;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Helper.Enumerables;

namespace Polkanalysis.Domain.UseCase.Finance
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

        public GlobalFinanceHandler(IFinancialService financialService, ILogger<GlobalFinanceHandler> logger, IExplorerService explorerService) : base(logger)
        {
            _financialService = financialService;
            _explorerService = explorerService;
        }

        public async override Task<Result<GlobalFinanceDto, ErrorResult>> Handle(GlobalFinanceQuery request, CancellationToken cancellationToken)
        {
            if (request.From is not null && request.To is not null && request.From.Value > request.To.Value)
            {
                return UseCaseError(ErrorResult.ErrorType.BusinessError, $"{request.From} is greater than {request.To}");
            }
            
            var transactions = await _financialService.GetTransactionsAsync(request.From, request.To, cancellationToken);
            var volume = transactions.Sum(x => x.Amount.Native);

            // Need to aggregage datetime from the transaction and his value
            //var extendedTransactions = await transactions
            //    .ExtendWith(x => _explorerService.GetDateTimeFromTimestampAsync(x.BlockNumber, cancellationToken))
            //    .WaitAllAndGetResultAsync();

            var volumePerDay = transactions
                .GroupBy(x => x.BlockDate)
                .Select(x => new { Date = x.Key, Volume = x.Sum(x => x.Amount.Native) });

            var averageAmountPerDay = transactions
                .GroupBy(x => x.BlockDate)
                .Select(x => new { Date = x.Key, Volume = x.Average(x => x.Amount.Native) });

            var dto = new GlobalFinanceDto(
                transactions.ToList(),
                new Contracts.Dto.Balances.CurrencyDto(volume, null),
                volumePerDay
                    .Select(x => new AmountPerDateRangeDto<double>(x.Volume, x.Date, x.Date)).ToList(),
                averageAmountPerDay
                    .Select(x => new AmountPerDateRangeDto<double>(x.Volume, x.Date, x.Date)).ToList(),
                request.From,
                request.To);

            return Helpers.Ok(dto);
        }
    }
}
