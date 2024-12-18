using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Parachain.Auction;
using Polkanalysis.Domain.Contracts.Primary.Parachain.Auction;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Parachain.Auction
{
    public class AuctionListHandler : Handler<AuctionListHandler, IEnumerable<AuctionLightDto>, AuctionsQuery>
    {
        private readonly IParachainService _parachainRepository;
        public AuctionListHandler(
            IParachainService parachainRepository,
            ILogger<AuctionListHandler> logger, HybridCache cache) : base(logger, cache)
        {
            _parachainRepository = parachainRepository;
        }

        public async override Task<Result<IEnumerable<AuctionLightDto>, ErrorResult>> HandleInnerAsync(AuctionsQuery request, CancellationToken cancellationToken)
        {
            var result = await _parachainRepository.GetAuctionsAsync(cancellationToken);

            return Helpers.Ok(result);
        }
    }
}
