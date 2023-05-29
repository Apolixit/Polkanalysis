using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Staking.Validator;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Staking.Validators;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.UseCase.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Validator
{
    public class ValidatorsUseCase : UseCase<ValidatorsUseCase, IEnumerable<ValidatorLightDto>, ValidatorsQuery>
    {
        private readonly IStakingRepository _roleMemberRepository;

        public ValidatorsUseCase(IStakingRepository roleMemberRepository, ILogger<ValidatorsUseCase> logger) : base(logger)
        {
            _roleMemberRepository = roleMemberRepository;
        }

        public async override Task<Result<IEnumerable<ValidatorLightDto>, ErrorResult>> Handle(ValidatorsQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var result = await _roleMemberRepository.GetValidatorsAsync(cancellationToken);

            return Helpers.Ok(result);
        }
    }
}
