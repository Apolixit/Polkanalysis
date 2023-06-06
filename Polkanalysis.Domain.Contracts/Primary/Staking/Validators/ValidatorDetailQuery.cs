using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Staking.Validator;
using Polkanalysis.Domain.Contracts.Primary.Result;

namespace Polkanalysis.Domain.Contracts.Primary.Staking.Validators
{
    public class ValidatorDetailQuery : IRequest<Result<ValidatorDto, ErrorResult>>
    {
        public required string ValidatorAddress { get; set; }
    }
}
