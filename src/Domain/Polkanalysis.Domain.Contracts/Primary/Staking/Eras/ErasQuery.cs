using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Era;
using Polkanalysis.Domain.Contracts.Primary.Result;

namespace Polkanalysis.Domain.Contracts.Primary.Staking.Eras
{
    public class ErasQuery : IRequest<Result<IEnumerable<EraLightDto>, ErrorResult>>
    {
        public string? ValidatorAddress { get; set; }
    }
}
