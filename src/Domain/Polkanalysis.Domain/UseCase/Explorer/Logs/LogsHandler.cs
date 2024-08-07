﻿using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Event;
using Polkanalysis.Domain.Contracts.Dto.Logs;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Event;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Logs;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.UseCase.Explorer.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Explorer.Logs
{
    public class LogsHandler : Handler<LogsHandler, IEnumerable<LogDto>, LogsQuery>
    {
        private readonly IExplorerService _explorerRepository;

        public LogsHandler(
            IExplorerService explorerRepository,
            ILogger<LogsHandler> logger, IDistributedCache cache) : base(logger, cache)
        {
            _explorerRepository = explorerRepository;
        }

        public override async Task<Result<IEnumerable<LogDto>, ErrorResult>> HandleInnerAsync(LogsQuery request, CancellationToken cancellationToken)
        {
            var result = await _explorerRepository.GetLogsAsync(request.BlockNumber, cancellationToken);

            return Helpers.Ok(result);
        }
    }
}
