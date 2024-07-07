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
        protected readonly IDistributedCache _cache;

        protected Handler(ILogger<TLogger> logger, IDistributedCache cache)
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
            _logger.LogError(errorResult.Description);
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

                var cachedData = await _cache.GetStringAsync(cacheKey, cancellationToken);
                if (cachedData is not null)
                {
                    _logger.LogDebug($"Cache hit for key: {cacheKey}");
                    var cachedResult = JsonSerializer.Deserialize<TDto>(cachedData);
                    return Helpers.Ok(cachedResult!);
                }

                _logger.LogDebug($"Cache miss for key: {cacheKey}");

                var result = await HandleInnerAsync(request, cancellationToken);

                if (result.IsSuccess)
                {
                    // Serialize the result and store it in the cache
                    var cacheOptions = new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(cachedRequest.CacheDurationInMinutes)
                    };
                    await _cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(result.Value), cacheOptions, cancellationToken);
                }

                return result;
            }

            return await HandleInnerAsync(request, cancellationToken);
        }

        public abstract Task<Result<TDto, ErrorResult>> HandleInnerAsync(TRequest request, CancellationToken cancellationToken);
    }
}
