using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Extrinsic;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Extrinsic;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Polkanalysis.Domain.UseCase.Explorer.Extrinsics
{
    public class ExtrinsicsUseCase : UseCase<ExtrinsicsUseCase, IEnumerable<ExtrinsicDto>, ExtrinsicsQuery>
    {
        private readonly IExplorerRepository _explorerRepository;

        public ExtrinsicsUseCase(
            IExplorerRepository explorerRepository,
            ILogger<ExtrinsicsUseCase> logger) : base(logger)
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
