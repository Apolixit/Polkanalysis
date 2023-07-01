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
            ILogger<AuctionListHandler> logger) : base(logger)
        {
            _parachainRepository = parachainRepository;
        }

        public async override Task<Result<IEnumerable<AuctionLightDto>, ErrorResult>> Handle(AuctionsQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var result = await _parachainRepository.GetAuctionsAsync(cancellationToken);

            return Helpers.Ok(result);
        }
    }
}
