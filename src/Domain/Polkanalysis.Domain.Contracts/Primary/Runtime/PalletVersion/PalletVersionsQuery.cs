using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Dto.Price;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.RuntimeModule.PalletVersion
{
    public class PalletVersionsQuery : IRequest<Result<IEnumerable<PalletVersionDto>, ErrorResult>>
    {
        public required string PalletName { get; set; }
    }
}
