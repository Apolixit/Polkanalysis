using Substats.Domain.Contracts.Dto.Block;
using Substats.Domain.Contracts.Primary;
using Substats.Domain.UseCase.Explorer;
using Microsoft.Extensions.Logging;
using OperationResult;
using OperationResult.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Substats.Domain.UseCase.ErrorResult;

namespace Substats.Domain.UseCase
{
    public abstract class UseCase<L, Dto, C> 
        where L : class
        where Dto : class
        where C : class
    {
        protected readonly ILogger<L> _logger;

        protected UseCase(ILogger<L> logger)
        {
            _logger = logger;
        }

        protected ErrorTag<ErrorResult> UseCaseError(ErrorType errorType, string reason)
        {
            return UseCaseError(new ErrorResult() {
                Status = errorType,
                Description = reason
            });
        }

        protected ErrorTag<ErrorResult> UseCaseError(ErrorResult errorResult)
        {
            _logger.LogError(errorResult.Description);
            return Helpers.Error(errorResult);
        }

        public abstract Task<Result<Dto, ErrorResult>> ExecuteAsync(C command, CancellationToken cancellationToken);
    }
}
