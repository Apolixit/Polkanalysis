using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.Parachain
{
    public class ParachainDetailQuery : IRequest<Result<ParachainDto, ErrorResult>>
    {
        public uint ParachainId { get; set; }
    }
}
