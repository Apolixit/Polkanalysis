using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Staking.Era;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.Staking.Eras
{
    public class CurrentEraInformationQuery : IRequest<Result<CurrentEraDto, ErrorResult>>
    {
    }
}
