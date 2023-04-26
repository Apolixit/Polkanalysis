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

namespace Polkanalysis.Domain.UseCase.Validator
{
    public class ValidatorDetailUseCase : UseCase<ValidatorDetailUseCase, ValidatorDto, ValidatorCommand>
    {
        public ValidatorDetailUseCase(ILogger<ValidatorDetailUseCase> logger) : base(logger)
        {
        }

        public override async Task<Result<ValidatorDto, ErrorResult>> Handle(ValidatorCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(command)} is not set");

            return null;
        }
    }
}
