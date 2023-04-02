using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Primary;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Secondary.Repository;

namespace Polkanalysis.Domain.UseCase.Explorer.Block
{
    public class BlockDetailUseCase : UseCase<BlockDetailUseCase, BlockDto, BlockCommand>
    {
        private readonly IExplorerRepository _blockRepository;

        public BlockDetailUseCase(IExplorerRepository blockRepository, ILogger<BlockDetailUseCase> logger) : base(logger)
        {
            _blockRepository = blockRepository;
        }

        public override async Task<Result<BlockDto, ErrorResult>> ExecuteAsync(BlockCommand blockCommand, CancellationToken cancellationToken)
        {
            if (blockCommand == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(blockCommand)} is not set");

            BlockDto? blockDto = null;
            if (blockCommand.BlockNumber != null)
                blockDto = await _blockRepository.GetBlockDetailsAsync((uint)blockCommand.BlockNumber, cancellationToken);
            else if (!string.IsNullOrEmpty(blockCommand.BlockHash))
                blockDto = await _blockRepository.GetBlockDetailsAsync(blockCommand.BlockHash, cancellationToken);

            if (blockDto == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyModel, $"{nameof(blockDto)} is null");

            _logger.LogInformation($"{nameof(blockDto)} has been succesfully created.");
            return Helpers.Ok(blockDto);
        }
    }
}
