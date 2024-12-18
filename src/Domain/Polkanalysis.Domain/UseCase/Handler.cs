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
using Polkanalysis.Domain.Contracts.Common;
using Polkanalysis.Domain.Contracts.Dto.Staking.Nominator;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Enum;
using Microsoft.Extensions.Caching.Hybrid;

namespace Polkanalysis.Domain.UseCase
{
    /// <summary>
    /// Abstract use case class to handle mediator incoming request
    /// </summary>
    /// <typeparam name="TLogger">The use case class</typeparam>
    /// <typeparam name="TDto">The DTO returned</typeparam>
    /// <typeparam name="TRequest">Query or command</typeparam>
    public abstract class Handler<TLogger, TDto, TRequest> : IRequestHandler<TRequest, Result<TDto, ErrorResult>>
        where TLogger : class
        where TRequest : IRequest<Result<TDto, ErrorResult>>
    {
        protected readonly ILogger<TLogger> _logger;
        protected readonly HybridCache _cache;

        /// <summary>
        /// Current child handler name
        /// </summary>
        protected string HandlerName => GetType().Name;

        protected Handler(ILogger<TLogger> logger, HybridCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        protected ErrorTag<ErrorResult> UseCaseError(ErrorType errorType, string reason, ErrorCriticity criticity)
        {
            return UseCaseError(new ErrorResult()
            {
                Status = errorType,
                Description = reason,
                Criticity = criticity
            });
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
            return Helpers.Error(errorResult);
        }

        public async Task<Result<TDto, ErrorResult>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            if (EqualityComparer<TRequest>.Default.Equals(request, default))
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            // Log the cache key if the request is cache
            if (request is ICached cachedRequest)
            {
                var cacheKey = cachedRequest.GenerateCacheKey();

                var cachedResult = await _cache.GetOrCreateAsync(cacheKey, async entry =>
                {
                    return await CallInnerHandleAsync(request, cancellationToken);
                }, new HybridCacheEntryOptions()
                {
                    LocalCacheExpiration = TimeSpan.FromMinutes(cachedRequest.CacheDurationInMinutes),
                    Expiration = TimeSpan.FromMinutes(cachedRequest.CacheDurationInMinutes)
                }, tags: [], cancellationToken);

                return cachedResult!;
            }

            return await CallInnerHandleAsync(request, cancellationToken);
        }

        /// <summary>
        /// Call the child handler and wrap it with a try {} catch {} to handle exceptions
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Result<TDto, ErrorResult>> CallInnerHandleAsync(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await HandleInnerAsync(request, cancellationToken);
            } catch(Exception ex)
            {
                _logger.LogError(ex, "[{handler}] Exception thrown by HandlerInnerAsync", HandlerName);
                return UseCaseError(ErrorType.BusinessError, $"An error occured", ErrorCriticity.High);
            }
            
        }

        public abstract Task<Result<TDto, ErrorResult>> HandleInnerAsync(TRequest request, CancellationToken cancellationToken);
    }
}
