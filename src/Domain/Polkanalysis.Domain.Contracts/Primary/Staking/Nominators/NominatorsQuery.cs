using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Staking.Nominator;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.Staking.Nominators
{
    public class NominatorsQuery : IRequest<Result<IEnumerable<NominatorLightDto>, ErrorResult>>
    {
        public string? ValidatorAddress { get; set; }
    }
}
