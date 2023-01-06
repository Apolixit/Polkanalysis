using Ajuna.NetApi.Model.Types.Base;
using Blazscan.Domain.Contracts.Dto.Block;
using Blazscan.Domain.Contracts.Primary;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OperationResult;
using Blazscan.Domain.Contracts.Secondary;

namespace Blazscan.Domain.UseCase
{
    public class BlockUseCase : UseCase
    {
        private readonly IBlockRepository _blockRepository;

        public BlockUseCase(IBlockRepository blockRepository, ILogger<BlockUseCase> logger) : base(logger) 
        {
            _blockRepository = blockRepository;
        }

        public async Task<Result<BlockDto, ErrorResult>> ExecuteAsync(BlockCommand blockCommand, CancellationToken cancellationToken)
        {
            if (blockCommand == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(blockCommand)} is not set");

            BlockDto? blockDto = null;
            if(blockCommand.BlockNumber != null)
            {
                blockDto = await _blockRepository.GetBlockDetailsAsync((uint)blockCommand.BlockNumber, cancellationToken);
            } else if(!string.IsNullOrEmpty(blockCommand.BlockHash))
            {
                var blockHash = new Hash();
                blockHash.Create(blockCommand.BlockHash);
                blockDto = await _blockRepository.GetBlockDetailsAsync(blockHash, cancellationToken);
            }

            if (blockDto == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyModel, $"{nameof(blockDto)} is null");

            return Helpers.Ok(blockDto);
        }
    }
}
