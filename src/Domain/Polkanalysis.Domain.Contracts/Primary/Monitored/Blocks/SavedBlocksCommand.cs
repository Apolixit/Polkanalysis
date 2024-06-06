using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Primary.Result;

namespace Polkanalysis.Domain.Contracts.Primary.Monitored.Blocks
{
    public record SavedBlocksCommand(uint BlockNumber) : IRequest<Result<bool, ErrorResult>>
    {
    }
}
