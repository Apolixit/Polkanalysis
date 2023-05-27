using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Event;
using Polkanalysis.Domain.Contracts.Dto.Logs;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Event;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Logs;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.UseCase.Explorer.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Explorer
{
    public class LogsUseCase : UseCase<LogsUseCase, IEnumerable<LogDto>, LogsQuery>
    {
        private readonly IExplorerRepository _explorerRepository;

        public LogsUseCase(
            IExplorerRepository explorerRepository,
            ILogger<LogsUseCase> logger) : base(logger)
        {
            _explorerRepository = explorerRepository;
        }

        public override async Task<Result<IEnumerable<LogDto>, ErrorResult>> Handle(LogsQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var result = await _explorerRepository.GetLogsAsync(request.BlockNumber, cancellationToken);

            return Helpers.Ok(result);
        }
    }
}
