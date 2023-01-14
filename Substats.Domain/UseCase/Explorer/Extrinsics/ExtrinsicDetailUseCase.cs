using Substats.Domain.Contracts.Dto.Event;
using Substats.Domain.Contracts.Dto.Extrinsic;
using Substats.Domain.Contracts.Primary;
using Substats.Domain.Contracts.Secondary;
using Substats.Domain.UseCase.Explorer.Events;
using Microsoft.Extensions.Logging;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.UseCase.Explorer.Extrinsics
{
    public class ExtrinsicDetailsUseCase : UseCase<ExtrinsicDetailsUseCase, ExtrinsicDto, ExtrinsicCommand>
    {
        private readonly IExplorerRepository _explorerRepository;

        public ExtrinsicDetailsUseCase(
            IExplorerRepository explorerRepository,
            ILogger<ExtrinsicDetailsUseCase> logger) : base(logger)
        {
            _explorerRepository = explorerRepository;
        }

        public override async Task<Result<ExtrinsicDto, ErrorResult>> ExecuteAsync(ExtrinsicCommand extrinsicCommand, CancellationToken cancellationToken)
        {
            if (extrinsicCommand == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(extrinsicCommand)} is not set");

            if (extrinsicCommand.BlockNumber < 1)
                return UseCaseError(ErrorResult.ErrorType.InvalidParam, $"{nameof(extrinsicCommand.BlockNumber)} is not valid (should be > 0)");

            if (extrinsicCommand.ExtrinsicIndex < 1)
                return UseCaseError(ErrorResult.ErrorType.InvalidParam, $"{nameof(extrinsicCommand.ExtrinsicIndex)} is not valid (should be > 0)");

            ExtrinsicDto extrinsicDto = await _explorerRepository.GetExtrinsicAsync(extrinsicCommand.BlockNumber, extrinsicCommand.ExtrinsicIndex, cancellationToken);

            if (extrinsicDto == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyModel, $"{nameof(extrinsicDto)} is null");

            _logger.LogInformation($"{nameof(extrinsicDto)} has been succesfully created.");
            return Helpers.Ok(extrinsicDto);
        }
    }
}
