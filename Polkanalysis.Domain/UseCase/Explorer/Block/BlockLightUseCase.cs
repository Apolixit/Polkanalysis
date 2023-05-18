using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Dto.Event;
using Microsoft.Extensions.Logging;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.Contracts.Primary.Result;
using MediatR;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Block;

namespace Polkanalysis.Domain.UseCase.Explorer.Block
{
    /// <summary>
    /// Display condensed informations about a block
    /// </summary>
    public class BlockLightUseCase : UseCase<BlockLightUseCase, BlockLightDto, BlockLightQuery>
    {
        private readonly IExplorerRepository _blockRepository;

        public BlockLightUseCase(IExplorerRepository blockRepository, ILogger<BlockLightUseCase> logger) : base(logger)
        {
            _blockRepository = blockRepository;
        }

        public override async Task<Result<BlockLightDto, ErrorResult>> Handle(BlockLightQuery command, CancellationToken cancellationToken)
        {
            if (command == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(command)} is not set");


            BlockLightDto? blockLightDto = null;
            if(!command.IsSet)
                blockLightDto = await _blockRepository.GetLastBlockAsync(cancellationToken);
            else if (command.BlockNumber != null)
                blockLightDto = await _blockRepository.GetBlockLightAsync((uint)command.BlockNumber, cancellationToken);
            else if (!string.IsNullOrEmpty(command.BlockHash))
                blockLightDto = await _blockRepository.GetBlockLightAsync(command.BlockHash, cancellationToken);

            if (blockLightDto == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyModel, $"{nameof(blockLightDto)} is null");

            _logger.LogInformation($"{nameof(blockLightDto)} has been succesfully created.");
            return Helpers.Ok(blockLightDto);
        }
    }
}
