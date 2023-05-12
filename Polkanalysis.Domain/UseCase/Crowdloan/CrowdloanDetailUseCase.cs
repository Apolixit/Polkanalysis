using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
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
    public class CrowdloanDetailUseCase : UseCase<CrowdloanDetailUseCase, CrowdloanDto, CrowdloanQuery>
    {
        private readonly ICrowdloanRepository _crowdloanRepository;
        public CrowdloanDetailUseCase(
            ICrowdloanRepository crowdloanRepository, 
            ILogger<CrowdloanDetailUseCase> logger) : base(logger)
        {
            _crowdloanRepository = crowdloanRepository;
        }

        public async override Task<Result<CrowdloanDto, ErrorResult>> Handle(CrowdloanQuery request, CancellationToken cancellationToken)
        {
            if(request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            throw new NotImplementedException();
            //_crowdloanRepository.GetCrowdloanDetailAsync()
        }
    }
}
