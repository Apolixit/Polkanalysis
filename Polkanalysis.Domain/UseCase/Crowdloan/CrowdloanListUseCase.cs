using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Parachain.Crowdloan;
using Polkanalysis.Domain.Contracts.Primary.Crowdloan;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Crowdloan
{
    public class CrowdloanListUseCase : UseCase<CrowdloanListUseCase, IEnumerable<CrowdloanListDto>, CrowdloanListQuery>
    {
        private readonly ICrowdloanRepository _crowdloanRepository;
        public CrowdloanListUseCase(
            ICrowdloanRepository crowdloanRepository,
            ILogger<CrowdloanListUseCase> logger) : base(logger)
        {
            _crowdloanRepository = crowdloanRepository;
        }

        public async override Task<Result<IEnumerable<CrowdloanListDto>, ErrorResult>> Handle(CrowdloanListQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var result = await _crowdloanRepository.GetCrowdloansAsync(cancellationToken);

            return Helpers.Ok(result);
        }
    }
}
