using Ajuna.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Dto.Event;
using Polkanalysis.Domain.Contracts.Primary;
using Microsoft.Extensions.Logging;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Secondary.Repository;

namespace Polkanalysis.Domain.UseCase.Explorer.Block
{
    /// <summary>
    /// Display condensed informations about a block
    /// </summary>
    public class BlockLightUseCase : UseCase<BlockLightUseCase, BlockLightDto, BlockCommand>
    {
        private readonly IExplorerRepository _blockRepository;

        public BlockLightUseCase(IExplorerRepository blockRepository, ILogger<BlockLightUseCase> logger) : base(logger)
        {
            _blockRepository = blockRepository;
        }

        public override async Task<Result<BlockLightDto, ErrorResult>> ExecuteAsync(BlockCommand blockCommand, CancellationToken cancellationToken)
        {
            if (blockCommand == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(blockCommand)} is not set");

            
            BlockLightDto? blockLightDto = null;
            if (blockCommand.BlockNumber != null)
                blockLightDto = await _blockRepository.GetBlockLightAsync((uint)blockCommand.BlockNumber, cancellationToken);
            else if (!string.IsNullOrEmpty(blockCommand.BlockHash))
                blockLightDto = await _blockRepository.GetBlockLightAsync(blockCommand.BlockHash, cancellationToken);

            if (blockLightDto == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyModel, $"{nameof(blockLightDto)} is null");

            _logger.LogInformation($"{nameof(blockLightDto)} has been succesfully created.");
            return Helpers.Ok(blockLightDto);
        }
    }
}
