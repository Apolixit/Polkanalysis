using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Staking.Reward;
using Polkanalysis.Domain.Contracts.Primary.Result;

namespace Polkanalysis.Domain.Contracts.Primary.Staking.Rewards
{
    public class RewardsQuery : IRequest<Result<IEnumerable<RewardDto>, ErrorResult>>
    {
        public string? ValidatorAddress { get; set; }
    }
}
