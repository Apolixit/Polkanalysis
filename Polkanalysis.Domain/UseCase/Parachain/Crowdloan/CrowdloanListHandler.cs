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
    public class CrowdloanListHandler : Handler<CrowdloanListHandler, IEnumerable<CrowdloanLightDto>, CrowdloansQuery>
    {
        private readonly IParachainService _parachainRepository;
        public CrowdloanListHandler(
            IParachainService parachainRepository,
            ILogger<CrowdloanListHandler> logger) : base(logger)
        {
            _parachainRepository = parachainRepository;
        }

        public async override Task<Result<IEnumerable<CrowdloanLightDto>, ErrorResult>> Handle(CrowdloansQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var result = await _parachainRepository.GetCrowdloansAsync(cancellationToken);

            return Helpers.Ok(result);
        }
    }
}
