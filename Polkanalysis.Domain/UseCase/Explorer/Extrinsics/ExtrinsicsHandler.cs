using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Extrinsic;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Extrinsic;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Polkanalysis.Domain.UseCase.Explorer.Extrinsics
{
    public class ExtrinsicsHandler : Handler<ExtrinsicsHandler, IEnumerable<ExtrinsicDto>, ExtrinsicsQuery>
    {
        private readonly IExplorerService _explorerRepository;

        public ExtrinsicsHandler(
            IExplorerService explorerRepository,
            ILogger<ExtrinsicsHandler> logger) : base(logger)
        {
            _explorerRepository = explorerRepository;
        }

        public async override Task<Result<IEnumerable<ExtrinsicDto>, ErrorResult>> Handle(ExtrinsicsQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var result = await _explorerRepository.GetExtrinsicsAsync(request.BlockNumber, cancellationToken);

            return Helpers.Ok(result);
        }
    }
}
