using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Staking.Validator;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.Staking.Validators
{
    public class ValidatorsQuery : IRequest<Result<IEnumerable<ValidatorLightDto>, ErrorResult>>
    {
        public string ElectedByNominator { get; set; } = string.Empty;
    }
}
