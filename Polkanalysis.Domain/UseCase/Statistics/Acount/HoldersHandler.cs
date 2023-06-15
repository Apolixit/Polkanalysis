using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Statistics.Account;

namespace Polkanalysis.Domain.UseCase.Statistics.Acount
{
    public class HoldersHandler : Handler<HoldersHandler, int, HoldersQuery>
    {
        public HoldersHandler(
            ILogger<HoldersHandler> logger) : base(logger)
        {
        }

        public override Task<Result<int, ErrorResult>> Handle(HoldersQuery request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
