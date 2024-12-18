using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Hybrid;
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

        public BlockListingHandler(IExplorerService explorerRepository, ILogger<BlockListingHandler> logger, HybridCache cache) : base(logger, cache)
        {
            _explorerRepository = explorerRepository;
        }

        public async override Task<Result<IEnumerable<BlockLightDto>, ErrorResult>> HandleInnerAsync(BlocksQuery request, CancellationToken cancellationToken)
        {
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
