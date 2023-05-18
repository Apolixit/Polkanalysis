using Polkanalysis.Domain.Contracts.Dto.Extrinsic;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Extrinsic;

namespace Polkanalysis.Domain.UseCase.Explorer.Extrinsics
{
    public class ExtrinsicDetailsUseCase : UseCase<ExtrinsicDetailsUseCase, ExtrinsicDto, ExtrinsicQuery>
    {
        private readonly IExplorerRepository _explorerRepository;

        public ExtrinsicDetailsUseCase(
            IExplorerRepository explorerRepository,
            ILogger<ExtrinsicDetailsUseCase> logger) : base(logger)
        {
            _explorerRepository = explorerRepository;
        }

        public override async Task<Result<ExtrinsicDto, ErrorResult>> Handle(ExtrinsicQuery command, CancellationToken cancellationToken)
        {
            if (command == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(command)} is not set");

            if (command.BlockNumber < 1)
                return UseCaseError(ErrorResult.ErrorType.InvalidParam, $"{nameof(command.BlockNumber)} is not valid (should be > 0)");

            if (command.ExtrinsicIndex < 1)
                return UseCaseError(ErrorResult.ErrorType.InvalidParam, $"{nameof(command.ExtrinsicIndex)} is not valid (should be > 0)");

            ExtrinsicDto extrinsicDto = await _explorerRepository.GetExtrinsicAsync(command.BlockNumber, command.ExtrinsicIndex, cancellationToken);

            if (extrinsicDto == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyModel, $"{nameof(extrinsicDto)} is null");

            _logger.LogInformation($"{nameof(extrinsicDto)} has been succesfully created.");
            return Helpers.Ok(extrinsicDto);
        }
    }
}
