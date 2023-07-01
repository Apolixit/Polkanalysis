using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Block;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Explorer.Block
{
    public class BlockListingHandler : Handler<BlockListingHandler, IEnumerable<BlockLightDto>, BlocksQuery>
    {
        private readonly IExplorerService _explorerRepository;

        public BlockListingHandler(IExplorerService explorerRepository, ILogger<BlockListingHandler> logger) : base(logger)
        {
            _explorerRepository = explorerRepository;
        }

        public async override Task<Result<IEnumerable<BlockLightDto>, ErrorResult>> Handle(BlocksQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            if(request.NbLastBlocksToFetch == default)
            {
                request.NbLastBlocksToFetch = 100;
            }

            var result = await _explorerRepository.GetLastBlocksAsync(request.NbLastBlocksToFetch, cancellationToken);

            if (result == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyModel, $"{nameof(result)} has no data");

            return Helpers.Ok(result);
        }
    }
}
