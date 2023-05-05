using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Statistics.Account;

namespace Polkanalysis.Domain.UseCase.Statistics.Acount
{
    public class HoldersUseCase : UseCase<HoldersUseCase, int, HoldersQuery>
    {
        public HoldersUseCase(
            ILogger<HoldersUseCase> logger) : base(logger)
        {
        }

        public override Task<Result<int, ErrorResult>> Handle(HoldersQuery request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
