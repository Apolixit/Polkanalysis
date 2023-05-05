using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Infrastructure.Common.Database.Repository.Events.Balances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Dto.Stats;
using FluentValidation;
using Polkanalysis.Domain.Adapter.Block;
using System.ComponentModel.DataAnnotations;
using Polkanalysis.Domain.Contracts.Primary.Statistics;

namespace Polkanalysis.Domain.UseCase.Statistics
{
    public class GlobalStatsQueryValidator : AbstractValidator<GlobalStatsQuery>
    {
        public bool IsAccountValid(string accountAddress)
        {
            return accountAddress.Length >= 10 && accountAddress.Length <= 50;
        }

        public GlobalStatsQueryValidator(BlockParameterLike blockParameter)
        {
            RuleFor(c => c.fromAccount)
                .Must((_, account) => account == null || IsAccountValid(account));

            RuleFor(c => c.toAccount)
                .Must((_, account) => account == null || IsAccountValid(account));

            RuleFor(c => c.fromBlock)
                .MustAsync(async (_, block, _) => block == null || await blockParameter.EnsureBlockNumberIsValidAsync((uint)block));

            RuleFor(c => c.toBlock)
                .MustAsync(async (_, block, _) => block == null || await blockParameter.EnsureBlockNumberIsValidAsync((uint)block));
        }
    }

    public class GlobalStatsUseCase : UseCase<GlobalStatsUseCase, GlobalStatsDto, GlobalStatsQuery>
    {
        private readonly BalancesTransferRepository _balancesTransferRepository;

        public GlobalStatsUseCase(
            ILogger<GlobalStatsUseCase> logger,
            BalancesTransferRepository balancesTransferRepository) : base(logger)
        {
            _balancesTransferRepository = balancesTransferRepository;
        }

        public async override Task<Result<GlobalStatsDto, ErrorResult>> Handle(GlobalStatsQuery request, CancellationToken cancellationToken)
        {
            //var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            //if (!validationResult.IsValid)
            //{
            //    return Helpers.Error(new ErrorResult()
            //    {
            //        Status = ErrorResult.ErrorType.InvalidParam,
            //        Description = string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage).ToArray())
            //    });
            //}

            var res = await _balancesTransferRepository.GetAllAsync(cancellationToken);

            var globalStatsDto = new GlobalStatsDto()
            {
                TransfersVolume = res.Sum(x => x.Amount)
            };
            return Helpers.Ok(globalStatsDto);
        }
    }
}
