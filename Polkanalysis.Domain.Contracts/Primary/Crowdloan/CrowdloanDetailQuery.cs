using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Parachain.Crowdloan;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.Crowdloan
{
    public class CrowdloanQuery : IRequest<Result<CrowdloanDto, ErrorResult>>
    {
        public uint CrowndloanId { get; set; }
    }
}
