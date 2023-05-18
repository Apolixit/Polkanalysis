using Polkanalysis.Domain.Contracts.Primary;
using Microsoft.Extensions.Logging;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Accounts;
using Polkanalysis.Domain.Contracts.Secondary.Repository;

namespace Polkanalysis.Domain.UseCase.Validator
{
    public class ValidatorDetailUseCase : UseCase<ValidatorDetailUseCase, ValidatorDto, ValidatorDetailQuery>
    {
        private readonly IRoleMemberRepository _roleMemberRepository;

        public ValidatorDetailUseCase(ILogger<ValidatorDetailUseCase> logger) : base(logger)
        {
        }

        public ValidatorDetailUseCase(IRoleMemberRepository roleMemberRepository, ILogger<ValidatorDetailUseCase> logger) : base(logger)
        {
            _roleMemberRepository = roleMemberRepository;
        }

        public override async Task<Result<ValidatorDto, ErrorResult>> Handle(ValidatorDetailQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var result = await _roleMemberRepository.GetValidatorDetailAsync(request.ValidatorAddress, cancellationToken);
            return Helpers.Ok(result);
        }
    }
}
