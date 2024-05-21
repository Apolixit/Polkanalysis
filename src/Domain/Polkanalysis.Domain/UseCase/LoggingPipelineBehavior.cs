using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase
{
    public class LoggingPipelineBehavior<TReq, TRes> : IPipelineBehavior<TReq, TRes>
        where TReq : IRequest<TRes>
    {
        private readonly ILogger<LoggingPipelineBehavior<TReq, TRes>> _logger;

        public LoggingPipelineBehavior(ILogger<UseCase.LoggingPipelineBehavior<TReq, TRes>> logger)
        {
            _logger = logger;
        }

        public async Task<TRes> Handle(TReq request, RequestHandlerDelegate<TRes> next, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Starting request : {@RequestName}, {@DateTimeUtc}", typeof(TReq).Name, DateTime.UtcNow);

            try 
            {
                var response = await next();

                _logger.LogDebug("Completed request : {@RequestName}, {@DateTimeUtc}", typeof(TReq).Name, DateTime.UtcNow);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured during request : {@RequestName}, {@DateTimeUtc}", typeof(TReq).Name, DateTime.UtcNow);
                throw;
            }
        }
    }
}
