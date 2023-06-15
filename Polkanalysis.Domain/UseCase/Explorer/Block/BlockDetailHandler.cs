using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OperationResult;
using MediatR;
using Serilog.Core;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Block;
using Polkanalysis.Domain.Contracts.Service;

namespace Polkanalysis.Domain.UseCase.Explorer.Block
{
    public class BlockDetailHandler : Handler<BlockDetailHandler, BlockDto, BlockDetailsQuery>
    {
        private readonly IExplorerService _explorerRepository;

        public BlockDetailHandler(IExplorerService explorerRepository, ILogger<BlockDetailHandler> logger) : base(logger)
        {
            _explorerRepository = explorerRepository;
        }

        public async override Task<Result<BlockDto, ErrorResult>> Handle(BlockDetailsQuery command, CancellationToken cancellationToken)
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
