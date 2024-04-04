using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Dto.Stats;
using FluentValidation;
using Polkanalysis.Domain.Adapter.Block;
using Polkanalysis.Domain.Contracts.Primary.Statistics;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Infrastructure.Database.Repository.Events.Balances;
using Polkanalysis.Infrastructure.Blockchain.Contracts;

namespace Polkanalysis.Domain.UseCase.Statistics
{
    public class GlobalStatsQueryValidator : AbstractValidator<GlobalStatsQuery>
    {
        public bool IsAccountValid(string accountAddress)
        {
            return accountAddress.Length >= 10 && accountAddress.Length <= 50;
        }

        public GlobalStatsQueryValidator(ISubstrateService _substrateService)
        {
            RuleFor(c => c.fromAccount)
                .Must((_, account) => account == null || IsAccountValid(account));

            RuleFor(c => c.toAccount)
                .Must((_, account) => account == null || IsAccountValid(account));

            RuleFor(c => c.fromBlock)
                .MustAsync(async (_, block, _) => block == null || await ((BlockParameterLike)block).EnsureBlockNumberIsValidAsync(_substrateService));

            RuleFor(c => c.toBlock)
                .MustAsync(async (_, block, _) => block == null || await ((BlockParameterLike)block).EnsureBlockNumberIsValidAsync(_substrateService));
        }
    }

    public class GlobalStatsHandler : Handler<GlobalStatsHandler, GlobalStatsDto, GlobalStatsQuery>
    {
        private readonly BalancesTransferRepository _balancesTransferRepository;

        public GlobalStatsHandler(
            ILogger<GlobalStatsHandler> logger,
            BalancesTransferRepository balancesTransferRepository) : base(logger)
        {
            _balancesTransferRepository = balancesTransferRepository;
        }

        public async override Task<Result<GlobalStatsDto, ErrorResult>> Handle(GlobalStatsQuery request, CancellationToken cancellationToken)
        {
            var res = await _balancesTransferRepository.GetAllAsync(cancellationToken);

            var globalStatsDto = new GlobalStatsDto()
            {
                TransfersVolume = res.Sum(x => x.Amount),
                ActiveAccounts = 0,
                RuntimeUpgrades = 0,
                StakingPools = 0
            };
            return Helpers.Ok(globalStatsDto);
        }
    }
}
