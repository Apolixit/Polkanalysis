using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Dto.Extrinsic;
using Polkanalysis.Domain.Contracts.Primary.Result;

namespace Polkanalysis.Domain.Contracts.Primary.Explorer.Extrinsic
{
    public class SearchExtrinsicsQuery : IRequest<Result<IQueryable<ExtrinsicLightDto>, ErrorResult>> { }
}
