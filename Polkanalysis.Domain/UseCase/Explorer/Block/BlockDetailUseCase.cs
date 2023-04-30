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
using MediatR;
using Serilog.Core;
using Polkanalysis.Domain.Contracts.Primary.Result;

namespace Polkanalysis.Domain.UseCase.Explorer.Block
{
    public class BlockDetailUseCase : UseCase<BlockDetailUseCase, BlockDto, BlockDetailsCommand>
    {
        private readonly IExplorerRepository _explorerRepository;

        public BlockDetailUseCase(IExplorerRepository explorerRepository, ILogger<BlockDetailUseCase> logger) : base(logger)
        {
            _explorerRepository = explorerRepository;
        }

        public async override Task<Result<BlockDto, ErrorResult>> Handle(BlockDetailsCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(command)} is not set");

            BlockDto? blockDto = null;
            if (command.BlockNumber != null)
                blockDto = await _explorerRepository.GetBlockDetailsAsync((uint)command.BlockNumber, cancellationToken);
            else if (!string.IsNullOrEmpty(command.BlockHash))
                blockDto = await _explorerRepository.GetBlockDetailsAsync(command.BlockHash, cancellationToken);

            if (blockDto == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyModel, $"{nameof(blockDto)} is null");

            _logger.LogInformation($"{nameof(blockDto)} has been succesfully created.");
            return Helpers.Ok(blockDto);
        }
    }
}
