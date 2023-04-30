using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Primary;
using Polkanalysis.Domain.UseCase.Explorer;
using Microsoft.Extensions.Logging;
using OperationResult;
using OperationResult.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Polkanalysis.Domain.Contracts.Primary.Result;
using static Polkanalysis.Domain.Contracts.Primary.Result.ErrorResult;

namespace Polkanalysis.Domain.UseCase
{
    /// <summary>
    /// Abstract use case class to handle mediator incoming request
    /// </summary>
    /// <typeparam name="TLogger">The use case class</typeparam>
    /// <typeparam name="TDto">The DTO returned</typeparam>
    /// <typeparam name="TRequest">Query or command</typeparam>
    public abstract class UseCase<TLogger, TDto, TRequest> : IRequestHandler<TRequest, Result<TDto, ErrorResult>>
        where TLogger : class
        where TDto : class
        where TRequest : IRequest<Result<TDto, ErrorResult>>
    {
        protected readonly ILogger<TLogger> _logger;

        protected UseCase(ILogger<TLogger> logger)
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

        public abstract Task<Result<TDto, ErrorResult>> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
