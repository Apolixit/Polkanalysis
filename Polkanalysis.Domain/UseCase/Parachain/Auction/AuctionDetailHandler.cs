using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Parachain.Auction;
using Polkanalysis.Domain.Contracts.Dto.Parachain.Crowdloan;
using Polkanalysis.Domain.Contracts.Primary.Crowdloan;
using Polkanalysis.Domain.Contracts.Primary.Parachain.Auction;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.UseCase.Parachain.Crowdloan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Parachain.Auction
{
    public class AuctionDetailHandler : Handler<AuctionDetailHandler, AuctionDto, AuctionDetailQuery>
    {
        private readonly IParachainService _parachainRepository;
        public AuctionDetailHandler(
            IParachainService parachainRepository,
            ILogger<AuctionDetailHandler> logger) : base(logger)
        {
            _parachainRepository = parachainRepository;
        }

        public async override Task<Result<AuctionDto, ErrorResult>> Handle(AuctionDetailQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var result = await _parachainRepository.GetAuctionDetailAsync(request.AuctionId, cancellationToken);

            return Helpers.Ok(result);
        }
    }
}
