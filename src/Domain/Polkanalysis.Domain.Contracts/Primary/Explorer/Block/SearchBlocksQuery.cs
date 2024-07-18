using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.Explorer.Block
{
    public class SearchBlocksQuery() : IRequest<Result<IQueryable<BlockLightDto>, ErrorResult>> { }
}
