using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Parachain.Crowdloan;
using Polkanalysis.Domain.Contracts.Primary.Crowdloan;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Parachain.Crowdloan
{
    public class CrowdloanDetailHandler : Handler<CrowdloanDetailHandler, CrowdloanDto, CrowdloanDetailQuery>
    {
        private readonly IParachainService _parachainRepository;
        public CrowdloanDetailHandler(
            IParachainService parachainRepository,
            ILogger<CrowdloanDetailHandler> logger) : base(logger)
        {
            _parachainRepository = parachainRepository;
        }

        public async override Task<Result<CrowdloanDto, ErrorResult>> Handle(CrowdloanDetailQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var result = await _parachainRepository.GetCrowdloanDetailAsync(request.CrowndloanId, cancellationToken);

            return Helpers.Ok(result);
        }
    }
}
